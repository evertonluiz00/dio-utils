using System;
using System.Collections.Generic;
using System.Linq;

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
                    case "3":
                        MediaNotasValidas();
                        break;
                    case "4":
                        NotasMaiores();
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
            Console.WriteLine(" 3 - Média das notas válidas");
            Console.WriteLine(" 4 - Notas maiores");
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


        private static void MediaNotasValidas()
        {
            SectionHeader("3 - Média das notas válidas");

            double nota1 = 0;
            double nota2 = 0;
            bool notaInvalida;

            notaInvalida = true;
            while (notaInvalida)
            {
                Console.Write(" Primeira nota : ");
                nota1 = double.Parse(Console.ReadLine());

                notaInvalida = (nota1 < 0 || nota1 > 10);

                if (notaInvalida)
                {
                    Console.WriteLine(" Nota inválida");
                }
            }

            notaInvalida = true;
            while (notaInvalida)
            {
                Console.Write(" Segunda  nota : ");
                nota2 = double.Parse(Console.ReadLine());

                notaInvalida = (nota2 < 0 || nota2 > 10);

                if (notaInvalida)
                {
                    Console.WriteLine(" Nota inválida");
                }
            }

            double media = (nota1 + nota2) / 2;
            Console.Write($" Média : {media.ToString("N2")}");

            SectionFooter();
        }


        private static void NotasMaiores()
        {
            SectionHeader("4 - Notas Maiores");

            int[] notas = { 90, 71, 82, 93, 75, 82 };
            Console.Write(" Lista de notas  :");

            foreach (var nota in notas)
            {
                Console.Write($" {nota},");
            }

            Console.WriteLine();

            IEnumerable<int> listaNotasMaiores = notas.Where(notas => notas > 80);
            int qtdeNotasMaiores = notas.Where(notas => notas > 80).Count();

            Console.Write(" Notas maioes    :");

            foreach (var nota in listaNotasMaiores)
            {
                Console.Write($" {nota},");
            }

            Console.WriteLine(); ;
            Console.WriteLine($" Qtde de maiores : {qtdeNotasMaiores}");

            SectionFooter();
        }
    }
}
