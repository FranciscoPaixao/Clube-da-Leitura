using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clube_da_Leitura.ModuloCaixa;

namespace Clube_da_Leitura
{
    public class MenuCli
    {
        RepositorioCaixa repositorioCaixa;
        CLICaixa cliCaixa;
        public MenuCli()
        {
            repositorioCaixa = new RepositorioCaixa();
            cliCaixa = new CLICaixa(repositorioCaixa);
            
        }
        public void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Menu Principal");
            Console.WriteLine("Opções disponíveis: ");
            Console.WriteLine("1 - Menu Caixa");
            Console.WriteLine("2 - Menu Revista");
            Console.WriteLine("3 - Menu Amiguinho");
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
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}