using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.App.Dto.ProductDto
{
    public class CreateVariationDto
    {
        public int VariationId { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public List<CreateSizeStocksDto> Size { get; set; }
    }
}
