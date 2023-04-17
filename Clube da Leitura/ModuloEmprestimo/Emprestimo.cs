using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloEmprestimo
{
    public class Emprestimo
    {
        public int id;
        public int idAmigo;
        public string codigoDeBarras;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public Emprestimo(DateTime dataEmprestimo, int idAmigo, string codigoDeBarras)
        {
            this.dataEmprestimo = dataEmprestimo;
            this.idAmigo = idAmigo;
            this.codigoDeBarras = codigoDeBarras;
            dataDevolucao = default(DateTime);
        }
    }
}