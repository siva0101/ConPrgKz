using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public string Image { get; set; }

    }
}
