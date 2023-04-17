using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clube_da_Leitura.ModuloAmigo
{
    public class RepositorioAmigo
    {
        Dictionary<int, Amigo> amigos;
        int contador;
        public RepositorioAmigo()
        {
            amigos = new Dictionary<int, Amigo>();
            contador = 0;
        }
        public bool InserirAmigo(Amigo amigo)
        {
            if (ExisteAmigo(amigo.nome))
            {
                return false;
            }
            amigo.id = contador;
            amigos.Add(contador, amigo);
            contador++;
            return true;
        }
        public Amigo[] ObterAmigos()
        {
            Amigo[] amigos = new Amigo[contador];
            for (int i = 0; i < contador; i++)
            {
                amigos[i] = this.amigos[i + 1];
            }
            return amigos;
        }
        public Amigo ObterAmigo(int id)
        {
            if (id > contador)
            {
                return null;
            }
            return amigos[id];
        }
        public Amigo ObterAmigo(string nome)
        {
            foreach (var amigo in amigos)
            {
                if (amigo.Value.nome == nome)
                    return amigo.Value;
            }
            return null;
        }
        public bool EditarAmigo(int id, Amigo amigo)
        {
            if (ExisteAmigo(amigo.nome))
            {
                return false;
            }
            amigo.id = id;
            amigos[id] = amigo;
            return true;
        }
        public bool ExcluirAmigo(String nome)
        {
            if (!ExisteAmigo(nome))
            {
                return false;
            }
            foreach (var amigo in amigos)
            {
                if (amigo.Value.nome == nome)
                {
                    amigos.Remove(amigo.Key);
                    return true;
                }
            }
            return false;
        }
        public bool ExcluirAmigo(int id)
        {
            if (id > contador || !ExisteAmigo(id))
            {
                return false;
            }
            amigos.Remove(id);
            return true;
        }
        public int ObterIdAmigo(String nome)
        {
            foreach (var amigo in amigos)
            {
                if (amigo.Value.nome == nome)
                    return amigo.Key;
            }
            return -1;
        }
        public bool ExisteAmigo(String nome)
        {
            foreach (var amigo in amigos)
            {
                if (amigo.Value.nome == nome)
                    return true;
            }
            return false;
        }
        public bool ExisteAmigo(int id)
        {
            if (id > contador)
            {
                return false;
            }
            return true;
        }

    }
}