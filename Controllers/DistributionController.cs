using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class DistributionController : Controller
    {
        private readonly IDistributionService _distributionService;
        private readonly IDemandeService _demandeService;
        public DistributionController(
            IDistributionService distributionService,
            IDemandeService demandeService
            )
        {
            _distributionService = distributionService;
            _demandeService = demandeService;

        }
        [HttpGet("distributions")]
        public IActionResult Index()
        {
            IEnumerable<Distribution> distributions = Enumerable.Empty<Distribution>();
            try 
            {
                 distributions = _distributionService.RechercherEntites();
            } catch(Exception ex) { }

            return View(distributions);
        }

        public IActionResult Details(long id)
        {
            Distribution? distribution = new Distribution();
            try
            {
                distribution = _distributionService.RechercherEntite(id);
                if (distribution == null) 
                {
                    return NotFound();
                }
            }
            catch (Exception ex) { }

            return View(distribution);
        }

        
        public IActionResult AjouterDistribution()
        {
            try
            {
                ViewBag.DemandeList = _demandeService.RechercherEntites().Select(e => new SelectListItem
                {
                    Text = "Demande " + e.Id.ToString(),
                    Value = e.Id.ToString()
                });
            }
            catch (Exception ex) { }

            return View();
        }

        [HttpPost]
        public IActionResult AjouterDistribution(Distribution model)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    var result = _distributionService.CreerEntite(model);
                    if (result != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                    return BadRequest();
                }
            }
            catch (Exception ex) { }

            ViewBag.DemandeList = _demandeService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Demande " + e.Id.ToString(),
                Value = e.Id.ToString()
            });

            return View(model);
        }

        
        public IActionResult ModifierDistribution(long id)
        {
            ViewBag.DemandeList = _demandeService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Demande " + e.Id.ToString(),
                Value = e.Id.ToString()
            });
            try
            {
                var result = _distributionService.RechercherEntite(id);
                if (result == null) 
                {
                    return NotFound();
                }

                return View(result);
            }
            catch (Exception ex) { }

            return View();
        }

        [HttpPost]
        public IActionResult ModifierDistribution(Distribution model)
        {
            ViewBag.DemandeList = _demandeService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Demande " + e.Id.ToString(),
                Value = e.Id.ToString()
            });
            try
            {
               if (ModelState.IsValid) 
               {
                    var distribution = _distributionService.RechercherEntite(model.Id);
                    if (distribution == null)
                    {
                        return BadRequest();
                    }

                    distribution.ModifieLe = DateTime.Now;
                    distribution.Statut = model.Statut;
                    distribution.DateDistribution = model.DateDistribution;
                    distribution.Quantite = model.Quantite;
                    distribution.IdContactDestinataire = model.IdContactDestinataire;
                    distribution.IdDemande = model.IdDemande;

                    var result = _distributionService.ModifierEntite(distribution);
                    if(result == null) { return BadRequest(); }

                    return RedirectToAction(nameof(Details), new { id = result.Id });
                }
            }
            catch (Exception ex) { }

            return View();
        }
    }
}
