using BlooDyWeb.Models;
using BlooDyWeb.Services;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlooDyWeb.Controllers
{
    public class CentreController : Controller
    {
        private readonly ICentreService _centreService;
        public CentreController(ICentreService centreService)
        {
            _centreService = centreService;
        }

        [HttpGet("centres")]
        public IActionResult Index()
        {
            var centres = _centreService.RechercherCentres();
            return View(centres);
        }

        public IActionResult DetailsCentre(long Id)
        {
            var centre = _centreService.RechercherCentre(Id);
            return View(centre);
        }

        public IActionResult AjouterCentre() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AjouterCentre(Centre model)
        {
            if (ModelState.IsValid) 
            {
                var centre = _centreService.CreerCentre(model);
                if(centre != null) 
                {
                    return RedirectToAction(nameof(Index), centre);
                }
            }
            return View(model);
        }

        public IActionResult ModifierCentre(long Id)
        {
            try 
            {
                var centre = _centreService.RechercherCentre(Id);
                if (centre != null)
                {
                    return View(centre);
                }
            } catch(Exception ex) { }
            
            return NotFound();
        }

        [HttpPost]
        public IActionResult ModifierCentre(Centre model)
        {
            if (ModelState.IsValid)
            {
                var centre = _centreService.RechercherCentre(model.Id);
                if (centre != null)
                {
                    centre.NomCentre = model.NomCentre;
                    centre.TypeCentre = model.TypeCentre;
                    centre.ModifieLe = DateTime.Now;  
                    var result = _centreService.ModifierCentre(centre);
                    return RedirectToAction(nameof(Index));
                }

                //return NotFound();??
            }
            return View(model);
        }
    }
}
