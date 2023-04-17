using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloRevista
{
    public class Revista
    {
        public string codigoDeBarras;
        public int ano;
        public string titulo;
        public int idCaixa;

        public Revista(string codigoDeBarras, int ano, string titulo, int idCaixa)
        {
            this.codigoDeBarras = codigoDeBarras;
            this.ano = ano;
            this.titulo = titulo;
            this.idCaixa = idCaixa;
        }
        public Revista(){}
    }
}