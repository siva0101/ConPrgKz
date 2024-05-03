using Ecommerce.App.Dto.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Service.Interface
{
    public interface IBrandService
    {
        public Task<CreateBrandDto>CreateAysnc(CreateBrandDto createBrandDto);
        public Task<IEnumerable<CreateBrandDto>> GetAllAysnc();
    }
}
