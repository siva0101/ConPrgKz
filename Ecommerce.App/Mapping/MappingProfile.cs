using AutoMapper;
using Ecommerce.App.Dto.BrandDto;
using Ecommerce.App.Dto.CategoryDto;
using Ecommerce.App.Dto.ProductDto;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Products,CreateProductDto>().ReverseMap();
            CreateMap<Products, UpdateProductDto>().ReverseMap();
            CreateMap<Products, ProductDto>().ForMember(x=>x.Category,opt=>opt.MapFrom(source=>source.Category.Categories))
                .ForMember(x => x.Brand, opt => opt.MapFrom(source => source.Brand.BrandName));
            CreateMap<Variation,CreateVariationDto>().ReverseMap();
            CreateMap<Size_Stocks,CreateSizeStocksDto>().ReverseMap();
            CreateMap<Images,CreateImageDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Brand,CreateBrandDto>().ReverseMap();
                
            
            
        }
    }
}
