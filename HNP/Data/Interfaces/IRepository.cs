using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNP.Data.Interfaces
{
    public interface IRepository<T> where  T :class,IEntity
    {
        Task<T> GetById(string id);
        Task Post(T obj);
        Task Put(T obj);
        Task Delete(string id);
       Task<IEnumerable<T>> GetAll();
        Task SaveChange();
    }
}
