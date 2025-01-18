using BlooDyWeb.Models;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class CollecteController : Controller
    {
        private readonly ICollecteService _collecteService;
        private readonly ICentreService _centreService;
        public CollecteController(
            ICollecteService collecteService,
            ICentreService centreService
            )
        {
            _collecteService = collecteService;
            _centreService = centreService;
        }
        [HttpGet("collectes")]
        public IActionResult Index()
        {
            IEnumerable<Collecte> result = Enumerable.Empty<Collecte>();
            try 
            {
                result = _collecteService.RechercherCollectes();
            }
            catch(Exception ex) { }

            return View(result);
        }

        public IActionResult DetailsCollecte(long id)
        {
            Collecte? result = new();

            try
            {
                result = _collecteService.RechercherCollecte(id);
                if (result == null)
                {
                    return NotFound(id);
                }
            }
            catch (Exception ex) { }

            return View(result);
        }
        
        public IActionResult AjouterCollecte() 
        {
            ViewBag.CentreList = _centreService.RechercherCentres().Select(centre => new SelectListItem 
            {
                Text = centre.Code,
                Value = centre.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult AjouterCollecte(Collecte model)
        {
            try 
            {
                if(ModelState.IsValid) 
                {
                    Collecte result = _collecteService.CreerEntite(model);
                    return RedirectToAction(nameof(Index));
                }
            }catch(Exception ex) { }

            ViewBag.CentreList = _centreService.RechercherCentres().Select(centre => new SelectListItem
            {
                Text = centre.Code,
                Value = centre.Id.ToString()
            });

            return View(model);
        }

        public IActionResult ModifierCollecte(long id)
        {
            ViewBag.CentreList = _centreService.RechercherCentres().Select(centre => new SelectListItem
            {
                Text = centre.Code,
                Value = centre.Id.ToString()
            });

            try 
            {
                Collecte? result = _collecteService.RechercherEntite(id);
                if (result == null) 
                {
                    return NotFound();
                }

                return View(result);
            } catch(Exception ex) { }

            return View();
        }

        [HttpPost]
        public IActionResult ModifierCollecte(Collecte model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Collecte? result = _collecteService.ModifierCollecte(model);

                    if (result != null) 
                    {
                        return RedirectToAction(nameof(DetailsCollecte), new { id = result.Id });
                    }
                    return BadRequest();
                }
            }
            catch (Exception ex) { }

            ViewBag.CentreList = _centreService.RechercherCentres().Select(centre => new SelectListItem
            {
                Text = centre.Code,
                Value = centre.Id.ToString()
            });

            return View(model);
        }

    }
}
