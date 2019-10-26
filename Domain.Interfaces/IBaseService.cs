using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseService<T>: IDisposable where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<IList<T>> GetPagedAsync(int skip, int take);
        Task DeleteAsync(int id);
        Task UpdateAsync(int? id, T item);
    }
}
