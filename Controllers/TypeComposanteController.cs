using BlooDyWeb.Models.Stock;
using BlooDyWeb.Services;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BlooDyWeb.Controllers
{
    public class TypeComposanteController : Controller
    {
        private readonly ITypeComposanteService _typeComposanteService;
        public TypeComposanteController(
            ITypeComposanteService typeComposanteService
            )
        {
            _typeComposanteService = typeComposanteService;
        }
        [HttpGet("/type-composante")]
        public IActionResult Index()
        {
            try 
            {
                var types = _typeComposanteService.RechercherEntites();
                return View(types);
            }catch ( Exception ex ) { }

            return View();
        }

        [HttpGet]
        public IActionResult AjouterTypeComposante() 
        { return View(); }
        [HttpPost]
        public IActionResult AjouterTypeComposante(TypeComposante model) 
        {
            try 
            {
                if (ModelState.IsValid) 
                {
                    model.CreeLe = DateTime.Now;
                    var type = _typeComposanteService.CreerEntite(model);
                    if (type != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = type.Id });
                    }
                    return BadRequest();
                }
            } catch (Exception ex) { }

            return View(model); 
        }

        public IActionResult Details(long id)
        {
            try 
            {
                var type = _typeComposanteService.RechercherEntite(id);
                if (type != null) 
                {
                    return View(type);
                }
                return NotFound();
            } catch (Exception ex) { }

            return BadRequest();
        }

        public IActionResult ModifierTypeComposante(long id) 
        {
            try 
            {
                var type = _typeComposanteService.RechercherEntite(id);
                if (type != null) 
                {
                    return View(type);
                }
                return NotFound();
            } catch (Exception ex) { }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult ModifierTypeComposante(TypeComposante model) 
        {
            try 
            {
                if (ModelState.IsValid) 
                {
                    var type = _typeComposanteService.RechercherEntite(model.Id);
                    if (type != null)
                    {
                        type.ModifieLe = DateTime.Now;
                        type.Libelle = model.Libelle;
                        type.DureeVie = model.DureeVie;
                        type.Temperature = model.Temperature;
                        var result = _typeComposanteService.ModifierEntite(type);

                        if (result != null) 
                        {
                            return RedirectToAction(nameof(Details), new { id = result.Id });
                        }
                        
                        return BadRequest();
                    }
                }
            } catch (Exception ex) { }

            return View(model);
        }
    }
}
