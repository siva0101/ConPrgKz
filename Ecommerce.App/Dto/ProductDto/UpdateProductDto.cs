using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.Dto.ProductDto
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
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
