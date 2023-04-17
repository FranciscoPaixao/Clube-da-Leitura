using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clube_da_Leitura.ModuloCaixa;
using Clube_da_Leitura.ModuloRevista;
using Clube_da_Leitura.ModuloAmigo;
using Clube_da_Leitura.ModuloEmprestimo;

namespace Clube_da_Leitura
{
    public class MenuCli
    {
        RepositorioCaixa repositorioCaixa;
        CLICaixa cliCaixa;

        RepositorioRevista repositorioRevista;
        CLIRevista cliRevista;

        RepositorioAmigo repositorioAmigo;
        CLIAmigo cliAmigo;

        RepositorioEmprestimo repositorioEmprestimo;
        CLIEmprestimo cliEmprestimo;

        public MenuCli()
        {
            repositorioCaixa = new RepositorioCaixa();
            cliCaixa = new CLICaixa(repositorioCaixa);

            // Teste de inserção de caixa
            //repositorioCaixa.InserirCaixa(new Caixa("Azul", "Cisco")); 

            repositorioRevista = new RepositorioRevista();
            cliRevista = new CLIRevista(repositorioRevista, repositorioCaixa);

            // Teste de inserção de revista
            //repositorioRevista.InserirRevista(new Revista("35209523", 2023, "Superman",0)); 

            repositorioAmigo = new RepositorioAmigo();
            cliAmigo = new CLIAmigo(repositorioAmigo);

            // Teste de inserção de amigo
            //repositorioAmigo.InserirAmigo(new Amigo("Ciclano Filho", "Fulano Responsavel", "123456789", "Rua 1")); 

            repositorioEmprestimo = new RepositorioEmprestimo();
            cliEmprestimo = new CLIEmprestimo(repositorioEmprestimo, repositorioRevista, repositorioAmigo);

            // Teste de inserção e finalização de emprestimo 
            /*
            repositorioEmprestimo.InserirEmprestimo(new Emprestimo(DateTime.Now, 0,"35209523")); // Teste de inserção de emprestimo 1
            repositorioEmprestimo.InserirEmprestimo(new Emprestimo(DateTime.Now, 0,"35209523")); // Teste de inserção de emprestimo 2
            repositorioEmprestimo.FinalizarEmprestimo(1, DateTime.Now.AddDays(7)); // Teste de finalização de emprestimo 2
            */
        }
        public void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Menu Principal");
            Console.WriteLine("Opções disponíveis: ");
            Console.WriteLine("1 - Menu Caixa");
            Console.WriteLine("2 - Menu Revista");
            Console.WriteLine("3 - Menu Amigo");
            Console.WriteLine("4 - Menu Emprestimo");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("Digite a opção desejada: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    cliCaixa.MenuCaixa();
                    break;
                case 2:
                    cliRevista.MenuRevista();
                    break;
                case 3:
                    cliAmigo.MenuAmigo();
                    break;
                case 4:
                    cliEmprestimo.MenuEmprestimo();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuPrincipal();
        }
    }
}