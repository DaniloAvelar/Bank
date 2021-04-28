using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();  
        static void Main(string[] args)
        {
            // Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Danilo Avelar");
            // Console.WriteLine(minhaConta.ToString());
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utiliza o DAN Bank, Volte sempre #tmj.");
            Console.ReadLine();

        }

        private static void InserirConta()
        {
            Console.WriteLine("Abrir uma nova Conta :D ");

            Console.Write("Digite [1] para P.Fisica e [2] para P.Jurídica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Como devemos Chamá-lo ?´:");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o seu Saldo Inicial:");
            int entradaSaldo = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor do Crédito:");
            int entradaCredito = int.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Não Existem contas cadastradas!");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta Conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(Conta);
            }
        }

        private static void Sacar()
        {
            Console.Write("Digite o Nº da Conta que deseja Sacar:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor que deseja Sacar:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);

        }
        private static void Depositar()
        {
            Console.Write("Digite o Nº da Conta que deseja Depositar:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor que deseja Depositar:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o Nº da Conta de Origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Para qual conta deseja transferir?:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor que deseja Transferir:");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DAN Bank - Como posso lhe ajudar?");
            Console.WriteLine("Informe o que deseja fazer:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Criar uma nova Conta");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depósito");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


    }
}
