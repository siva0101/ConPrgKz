using AutoMapper;
using Ecommerce.App.Dto.CategoryDto;
using Ecommerce.App.Dto.ProductDto;
using Ecommerce.App.Service.Interface;
using Ecommerce.Domain.IRepo;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<CreateCategoryDto> CreateAsync(CreateCategoryDto category)
        {
            var result = _mapper.Map<Category>(category);
            var entity = await _repository.CreateAsync(result);
            var data = _mapper.Map<CreateCategoryDto>(entity);
            return data;
        }

        public async Task<IEnumerable<CreateCategoryDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CreateCategoryDto>>(result);
        }
    }
}
