﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models.ViewModels
{
    public class ParentViewModel
    {
        public List<ProductViewModel> productList { get; set; }
        public List<LeagueViewModel> LeagueList { get; set; }
    }
}
