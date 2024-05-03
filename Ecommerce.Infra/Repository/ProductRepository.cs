using Ecommerce.Domain.IRepo;
using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repository
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        private readonly ApplicationDbContexts _context;
        public ProductRepository(ApplicationDbContexts context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _context.ProductsDb.Include(x => x.Category)
                .Include(x => x.Brand).Include(a=>a.Variations).ThenInclude(b=>b.Size).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Products product)
        {
            var result = _context.Update(product);
            await _context.SaveChangesAsync();



        }
    }
}
