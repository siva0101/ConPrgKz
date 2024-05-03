using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.IRepo
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T>CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task Delete(T entity);  
        Task<T> GetByIdAsync(Expression<Func<T, bool>> Condition);
    }
}
