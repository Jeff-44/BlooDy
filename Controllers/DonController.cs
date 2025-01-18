using BlooDyWeb.Models;
using BlooDyWeb.Services;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class DonController : Controller
    {
        private readonly IDonService _donService;
        private readonly IDonateurService _donateurService;
        private readonly ICollecteService _collecteService;
        public DonController(
            IDonService donService,
            IDonateurService donateurService,
            ICollecteService collecteService
            )
        {
            _donService = donService;
            _donateurService = donateurService;
            _collecteService = collecteService;
        
        }
        [HttpGet("dons")]
        public IActionResult Index()
        {
            IEnumerable<Don> dons = Enumerable.Empty<Don>();
            try 
            {
                dons = _donService.RechercherEntites();
            } catch (Exception ex) { }

            return View(dons);
        }

        public IActionResult DetailsDon(long id)
        {
            try 
            {
                Don? result = _donService.RechercherDon(id);
                if(result == null) 
                {
                    return NotFound();
                }

                return View(result);
            } catch (Exception ex) { }
            return View();
        }

        public IActionResult AjouterDon()
        {
            ViewBag.DonateurList = _donateurService.RechercherDonateurs().Select(donateur => new SelectListItem 
            {
                Text = donateur.Code,
                Value = donateur.Id.ToString()
            });

            ViewBag.CollecteList = _collecteService.RechercherEntites().Select(collecte => new SelectListItem
            {
                Text ="Collecte " + collecte.Id.ToString(),
                Value = collecte.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public IActionResult AjouterDon(Don model)
        {
            try 
            {
                if (ModelState.IsValid) 
                {
                    Don? result = _donService.CreerEntite(model);
                    if (result != null) 
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            } catch (Exception ex) { }

            ViewBag.DonateurList = _donateurService.RechercherDonateurs().Select(donateur => new SelectListItem
            {
                Text = donateur.Code,
                Value = donateur.Id.ToString()
            });

            ViewBag.CollecteList = _collecteService.RechercherEntites().Select(collecte => new SelectListItem
            {
                Text = "Collecte " + collecte.Id.ToString(),
                Value = collecte.Id.ToString()
            });

            return View(model);
        }

        public IActionResult ModifierDon(long id)
        {
            Don? result = new();

            ViewBag.DonateurList = _donateurService.RechercherDonateurs().Select(donateur => new SelectListItem
            {
                Text = donateur.Code,
                Value = donateur.Id.ToString()
            });

            ViewBag.CollecteList = _collecteService.RechercherEntites().Select(collecte => new SelectListItem
            {
                Text ="Collecte " + collecte.Id.ToString(),
                Value = collecte.Id.ToString()
            });

            try
            {
                result = _donService.RechercherEntite(id);
                if (result == null) 
                {
                    return NotFound();
                }
                
            }catch (Exception ex) { }

            return View(result);
        }

        [HttpPost]
        public IActionResult ModifierDon(Don model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var donExistant = _donService.RechercherEntite(model.Id);
                    if (donExistant == null) 
                    {
                        return NotFound();
                    }

                    Don? result = _donService.ModifierDon(model);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(DetailsDon), new { id = result.Id });
                    }
                }
            }
            catch (Exception ex) { }

            ViewBag.DonateurList = _donateurService.RechercherDonateurs().Select(donateur => new SelectListItem
            {
                Text = donateur.Code,
                Value = donateur.Id.ToString()
            });

            ViewBag.CollecteList = _collecteService.RechercherEntites().Select(collecte => new SelectListItem
            {
                Text = "Collecte " + collecte.Id.ToString(),
                Value = collecte.Id.ToString()
            });

            return View(model);
        }
    }
}
