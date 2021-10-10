using System;

namespace Desafios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainHeader();

            string opcaoUsuario = BuscarOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        IsTweet();
                        break;
                    case "2":
                        ConversorTempo();
                        break;
                    case "C":
                        Console.Clear();
                        MainHeader();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = BuscarOpcaoUsuario();
            }

        }

        private static void MainHeader()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" DIO Desafios!");
            Console.WriteLine("-----------------------------");
        }

        private static void SectionHeader(string menuOption)
        {
            Console.WriteLine("_____________________________");
            Console.WriteLine();
            Console.WriteLine($" {menuOption}");
            Console.WriteLine();
        }

        private static void SectionFooter()
        {
            Console.WriteLine();
            Console.WriteLine("_____________________________");
        }

        private static string BuscarOpcaoUsuario()
        {
            Console.WriteLine();

            Console.WriteLine(" Menu:");
            Console.WriteLine(" 1 - Is Tweet");
            Console.WriteLine(" 2 - Conversor de tempo");
            Console.WriteLine(" C - Limpar tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();
            Console.Write(" Selecionar menu: ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


        private static void IsTweet()
        {
            SectionHeader("1 - Is Tweet");

            Console.Write(" Mensagem : ");
            string entradaMsg = Console.ReadLine();

            Console.WriteLine();

            if (entradaMsg.Length <= 140)
            {
                Console.WriteLine(" RESULT: IS Tweet");
            }
            else
            {
                Console.WriteLine(" RESULT: NOT Tweet");
            }

            SectionFooter();
        }


        private static void ConversorTempo()
        {
            SectionHeader("2 - Conversor de tempo");

            Console.Write(" Tempo em segundos : ");
            int timeInSeconds = int.Parse(Console.ReadLine());

            int horas = (timeInSeconds / 3600);
            int minutos = (timeInSeconds - (3600 * horas)) / 60;
            int segundos = (timeInSeconds - (3600 * horas) - (minutos * 60));

            Console.WriteLine();
            Console.WriteLine($" RESULT: {horas.ToString().PadLeft(2, '0')}:{minutos.ToString().PadLeft(2, '0')}:{segundos.ToString().PadLeft(2, '0')}");

            SectionFooter();
        }
    }
}
