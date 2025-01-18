using BlooDyWeb.Models;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class DossierController : Controller
    {
        private readonly IExamenMedicalService _dossierService;
        private readonly IDonateurService _donateurService;
        public DossierController(
                IExamenMedicalService dossierService,
                IDonateurService donateurService
            )
        {
            _dossierService = dossierService;
            _donateurService = donateurService;
        }
        [HttpGet("/dossiers")]
        public IActionResult Index()
        {
            var dossiers = _dossierService.RechercherDossiers();
            return View(dossiers);
        }

        public IActionResult DetailsDossier(long id)
        {
            try 
            {
                var dossier = _dossierService.RechercherDossier(id);
                if(dossier == null) 
                {
                    return NotFound();
                }

                return View(dossier);
            }
            catch(Exception ex) { }

            return BadRequest();
        }
        [HttpGet("{code}")]
        public IActionResult AjouterDossier(string code)
        {
            try 
            {
                var dossier = _dossierService.RechercherDossier(code);
                if (dossier != null) 
                {
                    return View(dossier);
                }
                
            }catch(Exception ex) { }

            return BadRequest();
        }

        public IActionResult AjouterDossier()
        {
            ViewBag.DonateurList = _donateurService.RechercherDonateurs()?.Select(donateur => new SelectListItem 
            {
                Text = donateur.Code,
                Value = donateur.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult AjouterDossier(ExamenMedical model)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    var dossier = _dossierService.CreerDossier(model);
                    return RedirectToAction(nameof(Index));
                }

            } catch (Exception ex) { }

            ViewBag.DonateurList = _donateurService.RechercherDonateurs()?.Select(donateur => new SelectListItem
            {
                Text = donateur.Code,
                Value = donateur.Id.ToString()
            });

            return View(model);
        }

        public IActionResult ModifierDossier(long id)
        {
            ViewBag.DonateurList = _donateurService.RechercherDonateurs()?.Select(donateur => new SelectListItem
            {
                Text = donateur.Code,
                Value = donateur.Id.ToString()
            });

            var dossier = _dossierService.RechercherDossier(id);
            if (dossier == null) 
            {
                return NotFound();
            }

            return View(dossier);
        }


        [HttpPost]
        public IActionResult ModifierDossier(ExamenMedical model)
        {
            ViewBag.DonateurList = _donateurService.RechercherDonateurs()?.Select(donateur => new SelectListItem
            {
                Text = donateur.Code,
                Value = donateur.Id.ToString()
            });
            try
            {
                if (ModelState.IsValid)
                {
                    var dossier = _dossierService.ModifierDossier(model);
                    return RedirectToAction(nameof(DetailsDossier), new { id = dossier.Id });
                }
            }
            catch (Exception ex) { }

            return View(model);
        }

        public IActionResult ModifierDossierParCode(string code)
        {
            var dossier = _dossierService.RechercherDossier(code);
            if (dossier == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(ModifierDossier), new { id = dossier.Id });
        }

    }
}
