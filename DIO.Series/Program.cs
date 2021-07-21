using System;

namespace DIO.Series
{
    class program
    {
            static bool ListaVazia= false;
            static SerieRepositorio repositorio= new SerieRepositorio();
            static void Main(string[] args)
            {
                string opcaoUsuario =ObterOpcaoUsuario();

                while(opcaoUsuario.ToUpper() !="X")
                {
                    switch(opcaoUsuario)
                    {
                        case "1":
                            ListarSeries();
                            if (ListaVazia==true)
                            {
                                opcaoUsuario="X";
                                
                            }
                            break;
                        case "2":
                            InserirSerie();
                            break;
                        case "3":
                            AtualizarSerie();
                            break;
                        case "4":
                            ExcluirSerie();
                            break;
                        case "5":
                            VisualizarSerie();
                            break;
                        case "C":
                            Console.WriteLine("PaSSEI AQUI");
                            Console.Clear();
                            Console.WriteLine("PaSSEI AQUI1");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();

                    }
                    Console.WriteLine("PaSSEI AQUI3");

                    opcaoUsuario =ObterOpcaoUsuario();
                    Console.WriteLine("PaSSEI AQUI4");


                }
              
            }

            private static void VisualizarSerie()
            {
                
                try
                {
                    Console.WriteLine("Digite o Id da série.");
                    int indiceSerie = int.Parse(Console.ReadLine());
                    var serie = repositorio.RetornaPorId(indiceSerie);
                    Console.WriteLine(serie);
                }
                catch (System.Exception )
                {
                    
                   throw new System.Exception ("Erro no processo de Visualizar Série.");
                }
            }

            private static void ExcluirSerie()
            {
                try
                {
                    ListaVazia=false;
                    Console.WriteLine("Digite o Id da série.");
                    int indiceSerie = int.Parse(Console.ReadLine());
                    repositorio.Excluir(indiceSerie);
                }
                catch (System.Exception)
                {
                    
                    throw new System.Exception ("Erro no processo de Excluir Série.");
                }

            }


            private static void AtualizarSerie()
            {
                try
                {
                    ListaVazia=false;
                    Console.WriteLine("Digite o Id da série.");
                    int indiceSerie = int.Parse(Console.ReadLine());
                    Console.WriteLine("----------------");

                    foreach(int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
                    }

                    Console.WriteLine("Digite o gênero entre as opções acima: ");
                    int entradaGenero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o título da série: ");
                    string entradaTitulo = Console.ReadLine();
                    
                    Console.WriteLine("Digite o ano da série: ");
                    int entradaAno = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a descrição da série: ");
                    string entradaDescricao = Console.ReadLine();


                    Serie atualizaSerie = new Serie (id: indiceSerie, 
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);
                    repositorio.Atualizar(indiceSerie, atualizaSerie);
                }
                catch (System.Exception)
                {
                    
                    throw new System.Exception ("Erro no processo de Atualizar Série.");
                }

                
            }

            private static void ListarSeries()
            {
                try
                {
                    
                    Console.WriteLine("Listar séries.");
                    Console.WriteLine("----------------");
                    var lista=repositorio.Lista();
                    if(lista.Count==0)
                    {
                        Console.WriteLine("Nenhuma série cadastrada.");
                        ListaVazia=true;
                        return;
                    }
                    
                    foreach (var serie in lista)
                        {
                            var excluido = serie.retornaExcluido();
                            Console.WriteLine("#ID {0}: - {1} {2}",serie.retornaId(), serie.retornaTitulo(),(excluido ? "*Excluido*" : ""));
                        }
                        ListaVazia=false;
                }
                catch (System.Exception)
                {
                    
                    throw new System.Exception ("Erro no processo de Listar Série.");
                }

            }

            private static void InserirSerie()
            {
                try
                {
                    ListaVazia=false;
                    foreach(int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
                    }
                    Console.WriteLine("Digite o gênero entre as opções acima: ");
                    int entradaGenero=int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o título da série: ");
                    string entradaTitulo=Console.ReadLine();

                    Console.WriteLine("Digite o ano de início da série: ");
                    int entradaAno=int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a descrição da série: ");
                    string entradaDescricao = Console.ReadLine();

                    Serie novaSerie = new Serie (id: repositorio.ProximoId(), 
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);
                    repositorio.Inserir(novaSerie);
                }
                catch (System.Exception)
                {
                    
                    throw new System.Exception ("Erro no processo de Inserir Série.");
                }

            }

            private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("DIO Séries a seu dispor!");
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1: LISTAR SÉRIES");
                Console.WriteLine("2: INSERIR NOVA SÉRIE");
                Console.WriteLine("3: ATUALIZAR SÉRIE");
                Console.WriteLine("4: EXCLUIR SÉRIE");
                Console.WriteLine("5: VISUALIZAR SÉRIE");
                Console.WriteLine("C: LIMPAR TELA");
                Console.WriteLine("X: SAIR");
                Console.WriteLine("----------------------------");
                Console.WriteLine();
                string opcaoUsuario=Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;

            }
    }
}
