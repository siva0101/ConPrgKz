﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.App.APIResponses
{
    public class APIError
    {
        public string Description { get; set; }
        public APIError(String description) 
        {
            Description = description;
        }
    }
}
