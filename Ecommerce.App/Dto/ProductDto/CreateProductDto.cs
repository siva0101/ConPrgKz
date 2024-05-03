using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Dto.ProductDto
{
    public class CreateProductDto
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public bool Is_New { get; set; }
        public DateTime OfferEnds { get; set; } = DateTime.UtcNow;
        public double Rating { get; set; }
        public int Sale_Count { get; set; }
        public string Full_Description { get; set; }
        public string Short_Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public List<string> ProductCategory { get; set; }
        public List<string> Tag { get; set; }
        public List<CreateVariationDto> Variations { get; set; }





    }
}
