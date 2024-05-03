using Ecommerce.Domain.IRepo;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContexts _context;
        public CategoryRepository(ApplicationDbContexts context) : base(context) 
        {
            _context = context;
        }
        public async Task Update(Category category)
        {
            var result = _context.Update(category);
             await _context.SaveChangesAsync();
            
        }
    }
}
