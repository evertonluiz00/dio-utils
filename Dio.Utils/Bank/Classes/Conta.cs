using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = 0;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if ((this.Saldo - valorSaque) < (this.Credito * -1))
            {
                Console.WriteLine(" Saldo insuficiente!");
                return false;
            }
            else
            {
                this.Saldo -= valorSaque;
                Console.WriteLine($" Saldo atual da conta de {this.Nome} é {this.Saldo}");
                return true;
            }
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($" Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }


        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public double GetSaldo()
        {
            return this.Saldo;
        }

        public string GetNome()
        {
            return this.Nome;
        }
    }
}
