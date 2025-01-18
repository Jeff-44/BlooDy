using BlooDyWeb.Models.Stock;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class ComposanteController : Controller
    {
        private readonly IComposanteService _composanteService;
        private readonly IDonService _donService;
        private readonly ITypeComposanteService _typeComposanteService;
        public ComposanteController(
            IComposanteService composanteService,
            IDonService donService,
            ITypeComposanteService typeComposanteService
            )
        {
            _composanteService = composanteService;
            _donService = donService;
            _typeComposanteService = typeComposanteService;
        }

        [HttpGet("/composantes")]
        public IActionResult Index()
        {
            try 
            {
                var composantes = _composanteService.RechercherEntites();
                return View(composantes);
            }
            catch (Exception ex) { }
            return View();
        }
        [HttpGet("composantes/{id}")]
        public IActionResult Details(long id)
        {
            try
            {
                var result = _composanteService.RechercherEntite(id);
                if (result == null)
                {
                    return NotFound();
                }
                return View(result);
            }
            catch (Exception ex) { }

            return BadRequest();
        }

        [HttpGet("/creer-composante")]
        public IActionResult AjouterComposante() 
        {
            try 
            {
                ViewBag.DonList = _donService.RechercherEntites().Select(e => new SelectListItem
                {
                    Text = "Don: " + e.Id.ToString(),
                    Value = e.Id.ToString()
                });

                ViewBag.TypeComposanteList = _typeComposanteService.RechercherEntites().Select(e => new SelectListItem
                {
                    Text = e.Libelle,
                    Value = e.Id.ToString()
                });
                
            } catch (Exception ex) { }  
            return View();
        }

        [HttpPost("/creer-composante")]
        public IActionResult AjouterComposante(Composante model)
        {
            ViewBag.DonList = _donService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Don: " + e.Id.ToString(),
                Value = e.Id.ToString()
            });

            ViewBag.TypeComposanteList = _typeComposanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Libelle,
                Value = e.Id.ToString()
            });

            try 
            {
                if(ModelState.IsValid)
                {
                    model.CreeLe = DateTime.Now;
                    var result = _composanteService.CreerEntite(model);
                    return base.RedirectToAction(nameof(Details), new { id = result.Id });
                }
                return View(model);
            } catch (Exception ex) { }

            return View(model);
        }

        public IActionResult ModifierComposante(long id)
        {
            ViewBag.DonList = _donService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Don: " + e.Id.ToString(),
                Value = e.Id.ToString()
            });

            ViewBag.TypeComposanteList = _typeComposanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Libelle,
                Value = e.Id.ToString()
            });

            try 
            {
                var composante = _composanteService.RechercherEntite(id);
                if(composante == null) NotFound();
                return View(composante);
            } catch (Exception ex) { }
            return View();
        }

        [HttpPost]
        public IActionResult ModifierComposante(Composante model)
        {
            ViewBag.DonList = _donService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = "Don: " + e.Id.ToString(),
                Value = e.Id.ToString()
            });

            ViewBag.TypeComposanteList = _typeComposanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Libelle,
                Value = e.Id.ToString()
            });

            try
            {
                if (ModelState.IsValid)
                {
                    var composante = _composanteService.RechercherEntite(model.Id);
                    if (composante != null) 
                    {
                        composante.ModifieLe = DateTime.Now;
                        composante.TypeComposanteId = model.TypeComposanteId;
                        composante.DonId = model.DonId;
                        composante.Volume = model.Volume;
                        composante.Statut = model.Statut;
                        var result = _composanteService.ModifierEntite(composante);
                        if (result != null)
                        {
                            return RedirectToAction(nameof(Details), new { id = result.Id });
                        }
                    }
                }
                return View(model);
            }
            catch (Exception ex) { }

            return View(model);
        }
    }
}
