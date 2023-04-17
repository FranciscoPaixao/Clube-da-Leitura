using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloAmigo
{
    public class Amigo
    {
        public int id;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        public Amigo(){}
        
    }
}