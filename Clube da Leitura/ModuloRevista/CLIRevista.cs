using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clube_da_Leitura.ModuloCaixa;

namespace Clube_da_Leitura.ModuloRevista
{
    public class CLIRevista
    {
        private RepositorioRevista repositorioRevista;
        private RepositorioCaixa repositorioCaixa;
        public CLIRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;
        }
        public void MenuRevista()
        {
            Console.Clear();
            Console.WriteLine("Menu Revista");
            Console.WriteLine("Opções disponíveis: ");
            Console.WriteLine("1 - Inserir Revista");
            Console.WriteLine("2 - Editar Revista");
            Console.WriteLine("3 - Excluir Revista");
            Console.WriteLine("4 - Visualizar Revistas");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine("Digite a opção desejada: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    InserirRevista();
                    break;
                case 2:
                    EditarRevista();
                    break;
                case 3:
                    ExcluirRevista();
                    break;
                case 4:
                    VisualizarRevistas("Revistas cadastradas: ");
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuRevista();
        }
        public void InserirRevista()
        {
            Console.Clear();
            Console.WriteLine("Inserir Revista");
            Console.WriteLine("Digite o código de barras da revista: ");
            string codigoDeBarras = Console.ReadLine();
            Console.WriteLine("Digite o ano da revista: ");
            int ano = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o título da revista: ");
            string titulo = Console.ReadLine();

            string nomeCaixa;
            int idCaixa = 0;
            do
            {
                Console.WriteLine("Digite o nome da caixa da revista: ");
                nomeCaixa = Console.ReadLine();
                if (repositorioCaixa.ExisteCaixa(nomeCaixa))
                {
                    idCaixa = repositorioCaixa.ObterCaixa(nomeCaixa).id;
                    break;
                }else{
                    Console.WriteLine("Caixa não encontrada");
                }
            } while (true);

            Revista revista = new Revista(codigoDeBarras, ano, titulo, idCaixa);
            if (repositorioRevista.InserirRevista(revista))
            {
                Console.WriteLine("Revista inserida com sucesso");
            }
            else
            {
                Console.WriteLine("Revista não inserida");
            }
            Console.ReadLine();
        }
        public void EditarRevista()
        {
            Console.Clear();
            VisualizarRevistas("Revistas disponíveis para edição: ");
            Console.WriteLine("Digite o código de barras da revista: ");
            string codigoDeBarras = Console.ReadLine();
            Console.WriteLine("Digite o ano da revista: ");
            int ano = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o título da revista: ");
            string titulo = Console.ReadLine();

            string nomeCaixa;
            int idCaixa = 0;
            do
            {
                Console.WriteLine("Digite o nome da caixa da revista: ");
                nomeCaixa = Console.ReadLine();
                if (repositorioCaixa.ExisteCaixa(nomeCaixa))
                {
                    idCaixa = repositorioCaixa.ObterCaixa(nomeCaixa).id;
                }else{
                    Console.WriteLine("Caixa não encontrada");
                }
            } while (!repositorioCaixa.ExisteCaixa(nomeCaixa));
            
            Revista revista = new Revista(codigoDeBarras, ano, titulo, idCaixa);
            if (repositorioRevista.EditarRevista(revista))
            {
                Console.WriteLine("Revista editada com sucesso");
            }
            else
            {
                Console.WriteLine("Revista não editada");
            }
            Console.ReadLine();
        }
        public void ExcluirRevista()
        {
            Console.Clear();
            Console.WriteLine("Excluir Revista");
            Console.WriteLine("Digite o código de barras da revista: ");
            string codigoDeBarras = Console.ReadLine();
            if (repositorioRevista.ExcluirRevista(codigoDeBarras))
            {
                Console.WriteLine("Revista excluída com sucesso");
            }
            else
            {
                Console.WriteLine("Revista não excluída");
            }
            Console.ReadLine();
        }
        public void VisualizarRevistas(string mensagem)
        {
            Console.Clear();
            Console.WriteLine(mensagem);
            Revista[] revistas = repositorioRevista.ObterTodasRevistas();
            for (int i = 0; i < revistas.Length; i++)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Título: " + revistas[i].titulo);
                Console.WriteLine("Ano: " + revistas[i].ano);
                Console.WriteLine("Código de barras: " + revistas[i].codigoDeBarras);
                Console.WriteLine("Id da caixa: " + revistas[i].idCaixa);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}