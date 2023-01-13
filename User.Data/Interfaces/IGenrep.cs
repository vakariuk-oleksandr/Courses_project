using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main_Project.Interfaces
{
    /// <summary>
    /// Generic interface for CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenrep<T> where T : class
    {
        Task<T> Add(T obj);
        Task<IEnumerable<T>> Get();
        Task<T> GetById(string id);
        Task<T> Update(T obj);
        Task<T> Delete(string id);
    }

}
