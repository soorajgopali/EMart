using EMart.DA.Repository;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            returnObj.productList= _unit.Product.GetByLeagueId(leagueId);
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
    }
}
