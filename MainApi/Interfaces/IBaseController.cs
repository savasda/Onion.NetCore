using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MainApi.Interfaces
{
    interface IBaseController<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task PostAsync([FromBody] T entity);
        Task PutAsync(int id, [FromBody] T entity);
        Task DeleteAsync(int id);
        Task<IList<T>> GetPagedAsync(int currentPage, int onPage);
    }
}
