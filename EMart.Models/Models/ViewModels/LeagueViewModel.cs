using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models.ViewModels
{
    public class LeagueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int TeamTypeId { get; set; }
        public string TeamTypeName { get; set; } = string.Empty;


    }
}
