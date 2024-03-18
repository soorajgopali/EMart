using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models.ViewModels
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
        public String ImageUrl { get; set; } = string.Empty;
        public int TeamTypeId { get; set; }
        public string TeamTypeName { get; set; } = string.Empty;
        public int LeagueId { get; set; }
        public string LeagueName { get; set;} = string.Empty;
    }
}
