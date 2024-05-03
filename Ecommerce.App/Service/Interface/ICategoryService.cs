using Ecommerce.App.Dto.CategoryDto;
using Ecommerce.App.Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Service.Interface
{
    public interface ICategoryService
    {
        Task<CreateCategoryDto>CreateAsync(CreateCategoryDto category);
        Task<IEnumerable<CreateCategoryDto>> GetAllAsync();
    }
}
