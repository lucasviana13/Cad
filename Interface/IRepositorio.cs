using System.Collections.Generic;

namespace Catalogo.Interface
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId (int id);
         void Insert(T entidade);
         void Delete(int id);
         void Reload(int id, T entidade);
         int Proximo();
    }
}