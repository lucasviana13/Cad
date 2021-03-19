using System;
using System.Collections.Generic;
using Catalogo.Interface;

namespace Catalogo.classes
{
    public class SeriadoRepositorio : IRepositorio<Seriado>
    {
       private List<Seriado> listaseriado = new List<Seriado>(); //Futuramente trocar por um BD
        public void Delete(int id)
        {
            listaseriado[id].Exclue();
        }

        public void Insert(Seriado entidade)
        {
            listaseriado.Add(entidade);
        }

        public List<Seriado> Lista()
        {
            return listaseriado;
        }

        public int Proximo()
        {
            return listaseriado.Count;
        }

        public void Reload(int id, Seriado entidade)
        {
            listaseriado[id] = entidade;
        }

        public Seriado RetornaPorId(int id)
        {
            return listaseriado[id];
        }
    }
}