using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public class Size_Stocks
    {
       
        public int Id { get; set; }
        public int VariationId {  get; set; }
        public Variation Variation { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

    }
}
