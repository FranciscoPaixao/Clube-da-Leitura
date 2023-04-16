using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloCaixa
{
    public class Caixa
    {
        public  int id;
        public  string cor;
        public  string etiqueta;
        public Caixa(string cor, string etiqueta)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
        }
        public Caixa(){
            
        }
    }

}