using Ecommerce.Domain.IRepo;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Repository
{
    public class ImageRepo : GenericRepository<Images>, IImageRepo
    {
        private readonly ApplicationDbContexts _context;
        public ImageRepo(ApplicationDbContexts context) : base(context)
        {
            _context = context;
        }

        public async Task Update(Images image)
        {
            var result = _context.Update(image);
            await _context.SaveChangesAsync();
        }
    }
}
