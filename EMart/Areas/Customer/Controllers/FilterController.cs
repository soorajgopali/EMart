using EMart.DA.Repository;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMart.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class FilterController : Controller
    {
        private readonly IUnitOfWork _unit;

        public FilterController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index(int leagueId)
        {
            var returnObj = new ParentViewModel();
            returnObj.productList = _unit.Product.GetByLeagueId(leagueId);
            returnObj.TeamList = _unit.Team.GetListByLeague(leagueId);
            returnObj.LeagueList = _unit.League.GetList();
            return View(returnObj);

        }

        public IActionResult Team(int teamId)
        {
            var returnObj = new ParentViewModel();
            returnObj.productList = _unit.Product.GetByTeamId(teamId);
            returnObj.TeamList = _unit.Team.GetById(teamId);
            return View(returnObj);
        }

        public IActionResult Type(int editionId, int specificId, int brandId)
        {
            var products = _unit.Product.GetByType(editionId, specificId, brandId);

            var editionName = _unit.Edition.Get(e => e.Id == editionId)?.Name;
            var specificName = _unit.Specific.Get(s => s.Id == specificId)?.Name;
            var brandName = _unit.Brand.Get(b => b.Id == brandId)?.Name;

            ViewBag.EditionName = editionName;
            ViewBag.SpecificName = specificName;
            ViewBag.BrandName = brandName;

            return View("Type", products);
        }


    }
}
