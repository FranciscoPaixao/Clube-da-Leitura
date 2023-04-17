using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clube_da_Leitura.ModuloAmigo;
using Clube_da_Leitura.ModuloRevista;

namespace Clube_da_Leitura.ModuloEmprestimo
{
    public class CLIEmprestimo
    {
        private RepositorioEmprestimo repositorioEmprestimo;
        private RepositorioRevista repositorioRevista;
        private RepositorioAmigo repositorioAmigo;
        public CLIEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioRevista repositorioRevista, RepositorioAmigo repositorioAmigo)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
        }
        public void MenuEmprestimo(){
            Console.Clear();
            Console.WriteLine("Menu Emprestimo");
            Console.WriteLine("Opções disponíveis: ");
            Console.WriteLine("1 - Registrar empréstimo");
            Console.WriteLine("2 - Visualizar empréstimos");
            Console.WriteLine("3 - Devolver revista");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("Digite a opção desejada: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    RegistrarEmprestimo();
                    break;
                case 2:
                    VisualizarEmprestimos("Emprestimos registrados:",null);
                    break;
                case 3:
                    DevolverRevista();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuEmprestimo();
        }
        public void RegistrarEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("Registrar empréstimo");
            Console.WriteLine("Digite o nome do amigo:");
            string nomeAmigo = Console.ReadLine();
            Amigo amigo = repositorioAmigo.ObterAmigo(nomeAmigo);
            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado");
                return;
            }
            Console.WriteLine("Digite o nome da revista:");
            string nomeRevista = Console.ReadLine();
            Revista revista = repositorioRevista.ObterRevista(nomeRevista);
            if (revista == null)
            {
                Console.WriteLine("Revista não encontrada");
                return;
            }
            Console.WriteLine("Digite a data de empréstimo:");
            DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Digite a data de devolução:");
            DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());
            Emprestimo emprestimo = new Emprestimo(dataEmprestimo, amigo.id, revista.codigoDeBarras);
            emprestimo.dataDevolucao = dataDevolucao;
            repositorioEmprestimo.InserirEmprestimo(emprestimo);
            Console.WriteLine("Empréstimo registrado com sucesso");
        }
        public void DevolverRevista(){
            Console.Clear();
            VisualizarEmprestimos("Selecione o empréstimo que deseja finalizar:", "Em andamento");
            Console.WriteLine("Digite o id do empréstimo:");
            int id = Convert.ToInt32(Console.ReadLine());
            if(repositorioEmprestimo.ExisteEmprestimo(id) == false){
                Console.WriteLine("Empréstimo não encontrado");
                return;
            }
            if(repositorioEmprestimo.StatusEmprestimo(id)){
                Console.WriteLine("Empréstimo já finalizado anteriormente!");
                return;
            }
            repositorioEmprestimo.FinalizarEmprestimo(id, DateTime.Now);
            Console.WriteLine("Empréstimo finalizado com sucesso"); 
        }
        public void VisualizarEmprestimos(string mensagem, String status){
            Console.Clear();
            Console.WriteLine(mensagem);
            Emprestimo[] emprestimos = repositorioEmprestimo.ObterEmprestimos();
            foreach (Emprestimo emprestimo in emprestimos)
            {
                if(status == "Em andamento" && emprestimo.dataDevolucao != null){
                    continue;
                }
                Console.WriteLine("--------------------");
                Amigo amigo = repositorioAmigo.ObterAmigo(emprestimo.idAmigo);
                Revista revista = repositorioRevista.ObterRevista(emprestimo.codigoDeBarras);
                Console.WriteLine("Id: " + emprestimo.id);
                Console.WriteLine("Amigo: " + amigo.nome);
                Console.WriteLine("Revista: " + revista.titulo);
                Console.WriteLine("Data de empréstimo: " + emprestimo.dataEmprestimo);
                if(emprestimo.dataDevolucao != null){
                    Console.WriteLine("Data de devolução: " + emprestimo.dataDevolucao);
                }
                Console.WriteLine();
            }
        }
    }
}