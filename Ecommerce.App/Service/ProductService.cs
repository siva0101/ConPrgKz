using AutoMapper;
using Ecommerce.App.Dto.ProductDto;
using Ecommerce.App.Service.Interface;
using Ecommerce.Domain.IRepo;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto)
        {
            var result = _mapper.Map<Products>(createProductDto);
            var data = await _repository.CreateAsync(result);
            var entity = _mapper.Map<ProductDto>(data);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _repository.GetByIdAsync(x => x.ProductId == id);
            await _repository.Delete(result);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var result = await _repository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(x => x.ProductId == id);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            var result = _mapper.Map<Products>(updateProductDto);
            await _repository.UpdateAsync(result);

        }

    }
}