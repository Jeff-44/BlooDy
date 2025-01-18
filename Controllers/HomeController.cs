using BlooDyWeb.Models;
using BlooDyWeb.Models.ViewModels;
using BlooDyWeb.Services;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlooDyWeb.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly DashboardVM _dashboardVM;
        private readonly ICollecteService _collecteService;
        private readonly IDonateurService _donateurService;
        private readonly IDonService _donService;
        private readonly ICentreService _centreService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(
              ILogger<HomeController> logger,
              ICollecteService collecteService,
              IDonateurService donateurService,
              IDonService donService,
              ICentreService centreService)
        {
            _logger = logger;
            _dashboardVM = new DashboardVM();
            _collecteService = collecteService;
            _donateurService = donateurService;
            _donService = donService;
            _centreService = centreService;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            _dashboardVM.collectes = _collecteService.RechercherCollectes();
            _dashboardVM.Donneurs = _donateurService.RechercherDonateurs();
            _dashboardVM.Dons = _donService.RechercherEntites();
            _dashboardVM.centres = _centreService.RechercherCentres();
            return View(_dashboardVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
