using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloRevista
{
    public class RepositorioRevista
    {
        private Dictionary<string, Revista> revistas;
        public RepositorioRevista()
        {
            revistas = new Dictionary<string, Revista>();
        }
        public bool InserirRevista(Revista revista)
        {
            if (ExisteRevista(revista.codigoDeBarras))
            {
                return false;
            }
            revistas.Add(revista.codigoDeBarras, revista);
            return true;
        }
        public Revista ObterRevista(string codigoDeBarras)
        {
            if (!ExisteRevista(codigoDeBarras))
            {
                return null;
            }
            return revistas[codigoDeBarras];
        }
        public Revista[] ObterTodasRevistas()
        {  
            Revista[] revistas = new Revista[this.revistas.Count];
            this.revistas.Values.CopyTo(revistas, 0);
            return revistas;
        }
        public bool EditarRevista(Revista revista)
        {
            if (!ExisteRevista(revista.codigoDeBarras))
            {
                return false;
            }
            revistas[revista.codigoDeBarras] = revista;
            return true;
        }
        public bool ExcluirRevista(string codigoDeBarras)
        {
            if (!ExisteRevista(codigoDeBarras))
            {
                return false;
            }
            revistas.Remove(codigoDeBarras);
            return true;
        }
        private bool ExisteRevista(string codigoDeBarras)
        {
            return revistas.Values.Any(revista => revista.codigoDeBarras == codigoDeBarras);
        }
    }
}