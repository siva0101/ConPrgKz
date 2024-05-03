using AutoMapper;
using Ecommerce.App.Dto.BrandDto;
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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepo _brandRepo;
        private readonly IMapper _mapper;
        public BrandService(IBrandRepo brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }
        public async Task<CreateBrandDto> CreateAysnc(CreateBrandDto createBrandDto)
        {
            var result = _mapper.Map<Brand>(createBrandDto);
            var data = await _brandRepo.CreateAsync(result);
            var entity = _mapper.Map<CreateBrandDto>(data);
            return entity;
        }

        public async Task<IEnumerable<CreateBrandDto>> GetAllAysnc()
        {
           var result = await _brandRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<CreateBrandDto>>(result);
        }
    }
}
