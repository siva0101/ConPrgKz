using Ecommerce.App.Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Service.Interface
{
    public interface IImageService
    {
        public Task<CreateImageDto> CreateAsync(CreateImageDto imageDto);
        public Task<IEnumerable<CreateImageDto>> GetAllAsync();
    }
}
