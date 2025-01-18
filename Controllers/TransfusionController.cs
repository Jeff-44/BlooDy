using BlooDyWeb.Models.Stock;
using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Services.IServices;
using BlooDyWeb.Services.IServices.ITransfusionModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class TransfusionController : Controller
    {
        private readonly ITransfusionService _transfusionService;
        private readonly IMedecinService _medecinService;
        private readonly IComposanteService _composanteService;
        private readonly IBeneficiaireService _beneficiaireService;
        public TransfusionController(
                ITransfusionService transfusionService,
                IMedecinService medecinService,
                IComposanteService composanteService,
                IBeneficiaireService beneficiaireService
            )
        {
            _transfusionService = transfusionService;
            _medecinService = medecinService;
            _composanteService = composanteService;
            _beneficiaireService = beneficiaireService;
        }

        [HttpGet("transfusions")]
        public IActionResult Index()
        {
            IEnumerable<Transfusion> transfusions = Enumerable.Empty<Transfusion>();
            try 
            {
                transfusions = _transfusionService.RechercherEntites();
            } catch ( Exception ex ) { }

            return View(transfusions);
        }

        public IActionResult Details(long id) 
        {
            try 
            {
                var transfusion = _transfusionService.RechercherTransfusion(id);
                if ( transfusion == null ) 
                {
                    return NotFound();
                }
                return View(transfusion);
            } catch (Exception ex) { }

            return View();
        }

        public IActionResult AjouterTransfusion() 
        {
            ViewBag.BeneficiaireList = _beneficiaireService
                .RechercherBeneficiaires()?
                .Select(e => new SelectListItem { Text = e.Code, Value = e.Id.ToString() });

            ViewBag.MedecinList = _medecinService
                .RechercherMedecins()?
                .Select(e => new SelectListItem { Text = e.Code, Value = e.Id.ToString() });

            ViewBag.ComposanteList = _composanteService
                .RechercherEntites()?
                .Select(e => new SelectListItem { Text = "Composante " + e.Id.ToString(), Value = e.Id.ToString() });
            return View();
        }

        [HttpPost]
        public IActionResult AjouterTransfusion(Transfusion model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    model.CreeLe = DateTime.Now;
                    var result = _transfusionService.CreerEntite(model);
                    if (result != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            }
            catch (Exception ex) { }

            ViewBag.BeneficiaireList = _beneficiaireService
    .RechercherBeneficiaires()?
    .Select(e => new SelectListItem { Text = e.Code, Value = e.Id.ToString() });

            ViewBag.MedecinList = _medecinService
                .RechercherMedecins()?
                .Select(e => new SelectListItem { Text = e.Code, Value = e.Id.ToString() });

            ViewBag.ComposanteList = _composanteService
                .RechercherEntites()?
                .Select(e => new SelectListItem { Text = "Composante " + e.Id.ToString(), Value = e.Id.ToString() });

            return View(model);
        }
        public IActionResult ModifierTransfusion(long id) 
        {
            ViewBag.BeneficiaireList = _beneficiaireService
                                       .RechercherBeneficiaires()?
                                       .Select(e => new SelectListItem 
                                       { 
                                           Text = e.Code,
                                           Value = e.Id.ToString()
                                       });

            ViewBag.MedecinList = _medecinService
                .RechercherMedecins()?
                .Select(e => new SelectListItem { Text = e.Code, Value = e.Id.ToString() });

            ViewBag.ComposanteList = _composanteService
                .RechercherEntites()?
                .Select(e => new SelectListItem { Text = "Composante " + e.Id.ToString(), Value = e.Id.ToString() });
            try
            {
                var transfusion = _transfusionService.RechercherTransfusion(id);
                if (transfusion == null)
                {
                    return NotFound();
                }
                return View(transfusion);
            }
            catch (Exception ex) { }

            return View();
        }

        [HttpPost]
        public IActionResult ModifierTransfusion(Transfusion model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var transfusion = _transfusionService.RechercherEntite(model.Id);
                    if (transfusion == null) 
                    { 
                        return NotFound();
                    }
                    transfusion.ModifieLe = DateTime.Now;
                    transfusion.GroupeSanguin = model.GroupeSanguin;
                    transfusion.BeneficiaireId = model.BeneficiaireId;
                    transfusion.ComposanteId = model.ComposanteId;
                    transfusion.MedecinId = model.MedecinId;
                    transfusion.InstitutionSanteId = model.InstitutionSanteId;
                    transfusion.Quantite = model.Quantite;
                    transfusion.DateTransfusion = model.DateTransfusion;
                    transfusion.Statut = model.Statut;
                    transfusion.Notes = model.Notes;

                    var result = _transfusionService.ModifierEntite(transfusion);
                    if (result != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            }
            catch (Exception ex) { }

            ViewBag.BeneficiaireList = _beneficiaireService
            .RechercherBeneficiaires()?
            .Select(e => new SelectListItem { Text = e.Code, Value = e.Id.ToString() });

            ViewBag.MedecinList = _medecinService
                .RechercherMedecins()?
                .Select(e => new SelectListItem { Text = e.Code, Value = e.Id.ToString() });

            ViewBag.ComposanteList = _composanteService
                .RechercherEntites()?
                .Select(e => new SelectListItem { Text = "Composante " + e.Id.ToString(), Value = e.Id.ToString() });

            return View(model);
        }
    }
}
