using System;
using System.Diagnostics;
using Catalogo.classes;

namespace Catalogo
{
    class Program
    {
        static SeriadoRepositorio repositorio = new SeriadoRepositorio();
        static void Main(string[] args)
        {
            string opcao;
            opcao = Coleta_Opcao();

while (opcao.ToUpper()!="F")
            {
                switch(opcao)
                {
                    case "1":
                        ListarSeriados();
                    break;

                    case "2":
                        InsertSeriados();
                    break;

                    case "3":
                        ReloadSeriados();
                    break;

                    case "4":
                        DeleteSeriados();
                    break;

                    case "5":
                        VisualizarSeriado();
                    break;

                    case "L":
                        Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = Coleta_Opcao();
            }
        
        }
            private static string Coleta_Opcao()
            {
                Console.WriteLine("Olá, Bem Vindo ao Catálogo de séries \n");
                Console.WriteLine("Para começarmos digite a opção que lhe interesse:");
                Console.WriteLine("1- Lista das Séries");
                Console.WriteLine("2- Inserir novas Séries");
                Console.WriteLine("3- Atualizar informações da Série");
                Console.WriteLine("4- Excluir alguma Série");
                Console.WriteLine("5- Visualizar alguma Série");
                Console.WriteLine("L- Limpar sua Tela");            
                Console.WriteLine("F- Finalizar");
                Console.WriteLine();

                string opcao = Console.ReadLine().ToUpper();
                return opcao;
            }

            private static void ListarSeriados()
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("\tSéries:\n");

                var lista = repositorio.Lista();

                if (lista.Count ==0)
                {
                    Console.WriteLine("Nenuma Série Encontrada");
                }
                foreach (var serie in lista)
                {
                    var deletado = serie.retornaExcluido();

                    Console.WriteLine("ID: {0}\tNome: {1} \t{2} ", serie.retornaid(), serie.retornaNome(), (deletado ? "Excluido" : ""));
                    Console.WriteLine();
                }
                Console.WriteLine("------------------------------------\n\n");
            }


            private static void Dados(ref string title, ref int gen, ref int ano, ref string desc)
            {
                Console.WriteLine("Inserir:\n");

                Console.WriteLine("Nome da Série:");
                title = Console.ReadLine();
                Console.WriteLine("");

                foreach (int x in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine($"{x} - {Enum.GetName(typeof(Genero),x)}");
                } 
                Console.WriteLine("Gênero de acordo com as opções dadas acima:");
                gen = int.Parse(Console.ReadLine());

                Console.WriteLine("Ano de Lançamento:");
                ano = int.Parse(Console.ReadLine());

                Console.WriteLine("Sinopse: ");
                desc = Console.ReadLine();
            }

            private static void InsertSeriados()
            {
                string ntitle = " ";
                int ngen = 1;
                int nano = 1;
                string ndesc = " ";
                Dados(ref ntitle, ref ngen, ref nano, ref ndesc);
                Seriado novoSeriado = new Seriado(id:repositorio.Proximo(),
                                                  genero: (Genero)ngen,
                                                  nome: ntitle,
                                                  ano_lançamento: nano,
                                                  sinopse: ndesc       
                                                 );
            repositorio.Insert(novoSeriado);
            }

            private static void ReloadSeriados()
            {
                string ntitle = " ";
                int ngen = 1;
                int nano = 1;
                string ndesc = " ";

                Console.WriteLine("Digite o id da Série que você deseja alterar: ");
                int id_alterar = int.Parse(Console.ReadLine());
                Dados(ref ntitle, ref ngen, ref nano, ref ndesc);

                Seriado reloadseriado = new Seriado(id:id_alterar,
                                                    genero: (Genero)ngen,
                                                    nome: ntitle,
                                                    ano_lançamento: nano,
                                                    sinopse: ndesc       
                                                   );
                repositorio.Reload(id_alterar, reloadseriado);
            }

            private static void DeleteSeriados()
            {
              Console.WriteLine("Digite o id da Série que você deseja Excluir: ");
              int id_alterar = int.Parse(Console.ReadLine());
              
              Console.WriteLine($"Deseja mesmo excluir a série de ID = {id_alterar}? \nF para não e V para sim");
              string ok = Console.ReadLine();
            
              if (ok.ToUpper() == "F")
              {
                Console.WriteLine("Exclusão Cancelada");
              }
              else
              {
               repositorio.Delete(id_alterar);   
              }
            }

            private static void VisualizarSeriado()
            {
                Console.WriteLine("Digite o ID da Série:");
                int id_alterar = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(id_alterar);

                Console.WriteLine (serie);
            }




    }
}
