using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            MainHeader();

            string opcaoUsuario = BuscarOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CriarConta();
                        break;
                    case "3":
                        Sacar();
                        break;
                    case "4":
                        Depositar();
                        break;
                    case "5":
                        Transferir();
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

            Console.WriteLine();
            Console.WriteLine(" Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }


        private static string BuscarOpcaoUsuario()
        {
            Console.WriteLine();
            
            Console.WriteLine(" Menu:");
            Console.WriteLine(" 1 - Listar contas");
            Console.WriteLine(" 2 - Criar conta");
            Console.WriteLine(" 3 - Sacar");
            Console.WriteLine(" 4 - Depositar");
            Console.WriteLine(" 5 - Transferir");
            Console.WriteLine(" C - Limpar tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();
            Console.Write(" Selecionar menu: ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarContas()
        {
            SectionHeader("1 - Listar contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine(" Nenhuma conta cadastrada.");
            }
            else
            {
                int count = 0;
                foreach (var conta in listContas)
                {
                    Console.WriteLine($" #{count}: {conta.GetNome()} - Saldo: {conta.GetSaldo()}");
                    count++;
                }
            }

            SectionFooter();
        }

        private static void CriarConta()
        {
            SectionHeader("2 - Criar conta");

            Console.WriteLine(" Tipos de conta \r\n 1 - Física \r\n 2 - Jurídica ");
            Console.WriteLine();
            Console.Write(" Tipo de conta    : ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write(" Nome do cliente  : ");
            string entradaNome = Console.ReadLine();

            Console.Write(" Crédito liberado : ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, credito: entradaCredito, nome: entradaNome);

            listContas.Add(novaConta);

            SectionFooter();
        }
        

        private static void Sacar()
        {
            SectionHeader("3 - Sacar");

            Console.Write(" Número da conta  : ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write(" Valor para saque : ");
            double valorSaque = double.Parse(Console.ReadLine());

            Console.WriteLine();

            listContas[indiceConta].Sacar(valorSaque);

            SectionFooter();
        }

        private static void Depositar()
        {
            SectionHeader("4 - Depositar");

            Console.Write(" Número da conta     : ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write(" Valor para depósito : ");
            double valorDeposito = double.Parse(Console.ReadLine());

            Console.WriteLine();

            listContas[indiceConta].Depositar(valorDeposito);

            SectionFooter();
        }

        private static void Transferir()
        {
            SectionHeader("5 - Transferir");

            Console.Write(" Número da conta de origem  : ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write(" Número da conta de destino : ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write(" Valor para transferência   : ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Console.WriteLine();

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

            SectionFooter();
        }


        private static void MainHeader()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" DIO Digital Bank!");
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
    }
}
