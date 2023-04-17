using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloCaixa
{
    public class CLICaixa
    {
        private RepositorioCaixa repositorioCaixa;
        public CLICaixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
        }
        public void MenuCaixa()
        {
            Console.Clear();
            Console.WriteLine("Menu Caixa");
            Console.WriteLine("Opções disponíveis: ");
            Console.WriteLine("1 - Inserir Caixa");
            Console.WriteLine("2 - Editar Caixa");
            Console.WriteLine("3 - Excluir Caixa");
            Console.WriteLine("4 - Visualizar Caixas");
            Console.WriteLine("5 - Voltar");
            Console.WriteLine("Digite a opção desejada: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    InserirCaixa();
                    break;
                case 2:
                    EditarCaixa();
                    break;
                case 3:
                    ExcluirCaixa();
                    break;
                case 4:
                    VisualizarCaixas("Caixas cadastradas: ");
                    Console.ReadLine();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuCaixa();
        }
        public void InserirCaixa()
        {
            Console.Clear();

            Console.WriteLine("Inserir Caixa");
            Console.WriteLine("Digite a cor da caixa: ");
            string cor = Console.ReadLine();
            Console.WriteLine("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();
            Caixa caixa = new Caixa(cor, etiqueta);
            if (repositorioCaixa.InserirCaixa(caixa))
            {
                Console.WriteLine("Caixa inserida com sucesso");
            }
            else
            {
                Console.WriteLine("Erro ao inserir caixa");
            }
            Console.ReadLine();
        }
        public bool EditarCaixa()
        {
            Caixa caixa;
            Console.Clear();
            VisualizarCaixas("Caixas disponíveis para edição: ");
            Console.WriteLine("Digite o id ou o nome na etiqueta da caixa: ");
            string idOuEtiqueta = Console.ReadLine();
            bool idValido = int.TryParse(idOuEtiqueta, out int id);
            if (idValido)
            {
                caixa = repositorioCaixa.ObterCaixa(id);
            }
            else
            {
                caixa = repositorioCaixa.ObterCaixa(idOuEtiqueta);
            }

            if (caixa == null)
            {
                Console.WriteLine("Caixa não encontrada");
                return false;
            }

            Console.WriteLine("Digite a nova cor da caixa: ");
            string cor = Console.ReadLine();
            Console.WriteLine("Digite a nova etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            caixa.cor = cor;
            caixa.etiqueta = etiqueta;

            if (repositorioCaixa.EditarCaixa(caixa.id, caixa))
            {
                Console.WriteLine("Caixa editada com sucesso");
            }
            else
            {
                Console.WriteLine("Erro ao editar caixa");
            }
            return true;
        }
        public void ExcluirCaixa()
        {
            Console.Clear();
            VisualizarCaixas("Caixas disponíveis para exclusão: ");
            Console.WriteLine("Digite o id ou o nome na etiqueta da caixa que deseja excluir: ");
            string idOuEtiqueta = Console.ReadLine();
            bool idValido = int.TryParse(idOuEtiqueta, out int id);
            if (idValido)
            {
                if (repositorioCaixa.ExcluirCaixa(id))
                {
                    Console.WriteLine("Caixa excluída com sucesso");
                }
                else
                {
                    Console.WriteLine("Erro ao excluir caixa");
                }
            }
            else
            {
                if (repositorioCaixa.ExcluirCaixa(idOuEtiqueta))
                {
                    Console.WriteLine("Caixa excluída com sucesso");
                }
                else
                {
                    Console.WriteLine("Erro ao excluir caixa");
                }
            }
            Console.ReadLine();
        }
        public void VisualizarCaixas(String texto)
        {
            Console.Clear();
            Console.WriteLine(texto);
            Console.WriteLine("Id\t|Cor\t |Etiqueta");
            Caixa[] caixas = repositorioCaixa.ObterCaixas();
            if (caixas.Length == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrada");
            }
            else
            {
                foreach (var caixa in caixas)
                {
                    Console.WriteLine($"Id: {caixa.id} | Cor: {caixa.cor} | Etiqueta: {caixa.etiqueta}");
                }
            }
        }
    }
}