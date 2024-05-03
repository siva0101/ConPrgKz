using Ecommerce.Domain.IRepo;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repository
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepo
    {
        private readonly ApplicationDbContexts _context;
        public BrandRepository(ApplicationDbContexts context) : base(context)
        {
            _context = context;
        }
        public async Task Update(Brand brand)
        {
            var result = _context.Update(brand);
            await _context.SaveChangesAsync();
        }
    }
}
