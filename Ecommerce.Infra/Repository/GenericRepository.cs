using Ecommerce.Domain.IRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContexts _context;
        public GenericRepository(ApplicationDbContexts context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
                
        }

        public  async Task Delete(T entity)
        {
            var result = _context.Remove(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> Condition)
        {
           var result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(Condition);
            return result;
        }
    }
}
