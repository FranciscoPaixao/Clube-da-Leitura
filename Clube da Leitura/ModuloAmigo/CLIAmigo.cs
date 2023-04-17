using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloAmigo
{
    public class CLIAmigo
    {
        private RepositorioAmigo repositorioAmigo;
        public CLIAmigo(RepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }
        public void MenuAmigo()
        {
            Console.Clear();
            Console.WriteLine("Menu Amigo");
            Console.WriteLine("Opções disponíveis: ");
            Console.WriteLine("1 - Inserir Amigo");
            Console.WriteLine("2 - Editar Amigo");
            Console.WriteLine("3 - Excluir Amigo");
            Console.WriteLine("4 - Visualizar Amigos");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine("Digite a opção desejada: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    InserirAmigo();
                    break;
                case 2:
                    EditarAmigo();
                    break;
                case 3:
                    ExcluirAmigo();
                    break;
                case 4:
                    VisualizarAmigos("Amigos cadastrados: ");
                    Console.ReadLine();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuAmigo();
        }
        public void InserirAmigo()
        {
            Console.Clear();
            
            Console.WriteLine("Inserir Amigo");
            Console.WriteLine("Digite o nome do amigo: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();
            Console.WriteLine("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();
            Console.WriteLine("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();
            Amigo amigo = new Amigo(nome, nomeResponsavel, telefone, endereco);
            if (repositorioAmigo.InserirAmigo(amigo))
            {
                Console.WriteLine("Amigo inserido com sucesso");
            }
            else
            {
                Console.WriteLine("Erro ao inserir amigo");
            }
        }
        public void EditarAmigo()
        {
            Amigo amigo;
            Console.Clear();
            VisualizarAmigos("Amigos disponíveis para edição: ");
            Console.WriteLine("Digite o id do amigo que deseja editar: ");
            string idOuNome = Console.ReadLine();
            int id;
            bool idValido = int.TryParse(idOuNome, out id);
            if (idValido)
            {
                amigo = repositorioAmigo.ObterAmigo(id);
            }
            else
            {
                amigo = repositorioAmigo.ObterAmigo(idOuNome);
                id = amigo.id;
            }
            if (amigo != null)
            {
                Console.WriteLine("Digite o novo nome do amigo: ");
                amigo.nome = Console.ReadLine();
                Console.WriteLine("Digite o novo nome do responsável: ");
                amigo.nomeResponsavel = Console.ReadLine();
                Console.WriteLine("Digite o novo telefone do amigo: ");
                amigo.telefone = Console.ReadLine();
                Console.WriteLine("Digite o novo endereço do amigo: ");
                amigo.endereco = Console.ReadLine();
                if (repositorioAmigo.EditarAmigo(id, amigo))
                {
                    Console.WriteLine("Amigo editado com sucesso");
                }
                else
                {
                    Console.WriteLine("Erro ao editar amigo");
                }
            }
            else
            {
                Console.WriteLine("Amigo não encontrado");
            }
        }
        public void ExcluirAmigo()
        {
            Console.Clear();
            VisualizarAmigos("Amigos disponíveis para exclusão: ");
            Console.WriteLine("Digite o id do amigo que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (repositorioAmigo.ExcluirAmigo(id))
            {
                Console.WriteLine("Amigo excluído com sucesso");
            }
            else
            {
                Console.WriteLine("Erro ao excluir amigo");
            }
            
        }
        public void VisualizarAmigos(string mensagem)
        {
            Console.Clear();
            Console.WriteLine(mensagem);
            Console.WriteLine("Id - Nome - Nome do Responsável - Telefone - Endereço");
            Amigo[] amigos = repositorioAmigo.ObterAmigos();
            foreach (Amigo amigo in amigos)
            {
                Console.WriteLine(amigo.id + " - " + amigo.nome + " - " + amigo.nomeResponsavel + " - " + amigo.telefone + " - " + amigo.endereco);
            }
        }        
    }
}