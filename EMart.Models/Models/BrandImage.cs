﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models
{
    public class BrandImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

    }
}
