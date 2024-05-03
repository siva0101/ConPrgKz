using AutoMapper;
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
    public class ImageService : IImageService
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;
        public ImageService(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }
        public async Task<CreateImageDto> CreateAsync(CreateImageDto imageDto)
        {
            var result = _mapper.Map<Images>(imageDto);
            var data = await _imageRepo.CreateAsync(result);
            var entity = _mapper.Map<CreateImageDto>(data);
            return entity;
        }

        public async Task<IEnumerable<CreateImageDto>> GetAllAsync()
        {
            var result = await _imageRepo.GetAllAsync();
            return _mapper.Map<CreateImageDto[]>(result);
        }
    }
}
