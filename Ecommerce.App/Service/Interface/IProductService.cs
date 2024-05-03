using Ecommerce.App.Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Service.Interface
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(CreateProductDto createProductDto);
        Task<IEnumerable<ProductDto>> GetAllAsync();    
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(int id);
        Task<ProductDto> GetByIdAsync(int id);
    }
}
