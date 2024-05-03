using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.IRepo
{
    public interface IImageRepo : IGenericRepository<Images>
    {
        public Task Update(Images image);
    }
}
