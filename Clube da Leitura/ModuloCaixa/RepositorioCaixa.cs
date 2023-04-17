using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloCaixa
{
    public class RepositorioCaixa
    {
        private Dictionary<int, Caixa> caixas;
        private int contador;
        public RepositorioCaixa()
        {
            caixas = new Dictionary<int, Caixa>();
            contador = 0;
        }
        public bool InserirCaixa(Caixa caixa)
        {
            if (ExisteCaixa(caixa.etiqueta)){
                return false;
            }
            caixa.id = contador;
            caixas.Add(contador, caixa);
            contador++;
            return true;
        }
        public Caixa[] ObterCaixas(){
            Caixa[] caixas = new Caixa[this.caixas.Count];
            this.caixas.Values.CopyTo(caixas, 0);
            return caixas;
        }
        
        public Caixa ObterCaixa(int id)
        {
            if (id > contador){
                return null;
            }
            return caixas[id];
        }
        public Caixa ObterCaixa(string etiqueta)
        {
            foreach (var caixa in caixas)
            {
                if (caixa.Value.etiqueta == etiqueta)
                    return caixa.Value;
            }
            return null;
        }
        public bool EditarCaixa(int id, Caixa caixa)
        {
            if(ExisteCaixa(caixa.etiqueta)){
                return false;
            }
            caixa.id = id;
            caixas[id] = caixa;
            return true;
        }
        public bool ExcluirCaixa(int id)
        {
            if (id > contador){
                return false;
            }
            caixas.Remove(id);
            return true;
        }
        public bool ExcluirCaixa(string etiqueta)
        {
            foreach (var caixa in caixas)
            {
                if (caixa.Value.etiqueta == etiqueta){
                    caixas.Remove(caixa.Key);
                    return true;
                }
            }
            return false;
        }
        public bool ExisteCaixa(String etiqueta)
        {
            foreach (var caixa in caixas)
            {
                if (caixa.Value.etiqueta == etiqueta){
                    return true;
                }
            }
            return false;
        }  
    }
}