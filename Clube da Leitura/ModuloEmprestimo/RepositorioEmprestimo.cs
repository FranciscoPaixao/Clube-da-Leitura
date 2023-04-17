using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        Dictionary<int, Emprestimo> emprestimos;
        int contador;
        public RepositorioEmprestimo()
        {
            emprestimos = new Dictionary<int, Emprestimo>();
            contador = 0;
        }
        public bool InserirEmprestimo(Emprestimo emprestimo)
        {
            emprestimo.id = contador;
            emprestimos.Add(contador, emprestimo);
            contador++;
            return true;
        }
        public Emprestimo[] ObterEmprestimos()
        {
            Emprestimo[] emprestimos = new Emprestimo[this.emprestimos.Count];
            this.emprestimos.Values.CopyTo(emprestimos, 0);
            return emprestimos;
        }
        public Emprestimo ObterEmprestimo(int id)
        {
            if (id > contador)
            {
                return null;
            }
            return emprestimos[id];
        }
        public bool FinalizarEmprestimo(int id, DateTime dataDevolucao)
        {
            if (id > contador || ExisteEmprestimo(id) == false)
            {
                return false;
            }
            emprestimos[id].dataDevolucao = dataDevolucao;
            return true;
        }
        public bool ExisteEmprestimo(int id)
        {
            return emprestimos.ContainsKey(id);
        }
        public bool StatusEmprestimo(int id)
        {
            if (id > contador || ExisteEmprestimo(id) == false)
            {
                return false;
            }
            return emprestimos[id].dataDevolucao == default(DateTime);
        }
    }
}