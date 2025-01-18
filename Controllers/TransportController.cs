using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class TransportController : Controller
    {
        private readonly ITransportService _transportService;
        private readonly IDistributionService _distributionService;
        private readonly IChauffeurService _chauffeurService;
        public TransportController(
            ITransportService transportService,
            IDistributionService distributionService,
            IChauffeurService chauffeurService
            )
        {
            _transportService = transportService;
            _distributionService = distributionService;
            _chauffeurService = chauffeurService;
        }
        [HttpGet("livraisons")]
        public IActionResult Index()
        {
            IEnumerable<Transport> livraisons = Enumerable.Empty<Transport>();
            try
            {
                livraisons = _transportService.RechercherEntites();

            } catch (Exception ex) { }

            return View(livraisons);
        }

        public IActionResult Details(long id)
        {
            try
            {
                var livraison = _transportService.RechercherEntite(id);
                if (livraison == null) 
                {
                    return NotFound();
                }
                return View(livraison);
            }
            catch (Exception ex) { }

            return View();
        }

        public IActionResult AjouterLivraison()
        {
            ViewBag.DistributionList = _distributionService.RechercherEntites().Select(e => new SelectListItem 
            {
                Text = "Distribution " + e.Id.ToString(),
                Value = e.Id.ToString()
            });

            ViewBag.ChauffeurList = _chauffeurService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Code,
                Value = e.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult AjouterLivraison(Transport model)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    var result = _transportService.CreerEntite(model);
                    if(result != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            } catch (Exception ex) { }
            
            ViewBag.DistributionList = _distributionService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Distribution " + e.Id.ToString(),
                Value = e.Id.ToString()
            });

            ViewBag.ChauffeurList = _chauffeurService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Code,
                Value = e.Id.ToString()
            });
            return View(model);
        }

        public IActionResult ModifierLivraison(long id)
        {
            ViewBag.DistributionList = _distributionService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Distribution " + e.Id.ToString(),
                Value = e.Id.ToString()
            });

            ViewBag.ChauffeurList = _chauffeurService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Code,
                Value = e.Id.ToString()
            });

            try
            {
                var livraison = _transportService.RechercherEntite(id);
                if (livraison == null) 
                {
                    return BadRequest();
                }
                return View(livraison);
            } catch (Exception ex) { }
            
            return View();
        }

        [HttpPost]
        public IActionResult ModifierLivraison(Transport model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var livraison = _transportService.RechercherEntite(model.Id);
                    if (livraison != null) 
                    {
                        livraison.IdDistribution = model.IdDistribution;
                        livraison.ModeTransport = model.ModeTransport;
                        livraison.NumeroVehicule = model.NumeroVehicule;
                        livraison.IdChauffeur = model.IdChauffeur;
                        livraison.HeureDepart = model.HeureDepart;
                        livraison.HeureArrivee = model.HeureArrivee;
                        livraison.Statut = model.Statut;
                        livraison.TemperatureTransport = model.TemperatureTransport;
                        livraison.HeureCheckTemperature = model.HeureCheckTemperature;

                        var result = _transportService.ModifierEntite(livraison);
                        if (result != null)
                        {
                            return RedirectToAction(nameof(Details), new { id = result.Id });
                        }
                    }
                }
            }
            catch (Exception ex) { }

            ViewBag.DistributionList = _distributionService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Distribution " + e.Id.ToString(),
                Value = e.Id.ToString()
            });

            ViewBag.ChauffeurList = _chauffeurService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Code,
                Value = e.Id.ToString()
            });

            return View(model);
        }
    }
}
