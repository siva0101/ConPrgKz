using Ecommerce.App.Mapping;
using Ecommerce.App.Service;
using Ecommerce.App.Service.Interface;
using Ecommerce.Domain.IRepo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App
{
    public static class AppRegistration
    {
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();

            return services;
        }
    }
}
