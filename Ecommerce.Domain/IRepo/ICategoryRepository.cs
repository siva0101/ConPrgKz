using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.IRepo
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task Update(Category category);
    }
}
