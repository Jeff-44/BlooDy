using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Services.IServices;
using BlooDyWeb.Services.IServices.IDistributionModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class DemandeController : Controller
    {
        private readonly IDemandeService _demandeService;
        private readonly IInstitutionSanteService _institutionSanteService;
        private readonly ITypeComposanteService _typeComposanteService;
        public DemandeController(
            IDemandeService demandeService,
            IInstitutionSanteService institutionSanteService,
            ITypeComposanteService typeComposanteService
            )
        {
            _demandeService = demandeService;
            _institutionSanteService = institutionSanteService;
            _typeComposanteService = typeComposanteService;
        }
        [HttpGet("demandes")]
        public IActionResult Index()
        {
            IEnumerable<Demande> demandes = Enumerable.Empty<Demande>();
            try 
            {
                demandes = _demandeService.RechercherEntites();
            } catch (Exception ex) { }
            return View(demandes);
        }
        public IActionResult Details(long id)
        {
            try
            {
                var demande = _demandeService.RechercherEntite(id);
                if (demande == null)
                {
                    return NotFound();
                }
                return View(demande);
            }
            catch (Exception ex) { }
            return View();
        }

        public IActionResult AjouterDemande()
        {
            ViewBag.InstitutionList = _institutionSanteService.RechercherEntites().Select(e => new SelectListItem 
            {
                Text = e.Code,
                Value = e.Id.ToString()
            });

            ViewBag.TypeComposanteList = _typeComposanteService.RechercherEntites().Select(e => new SelectListItem 
            {
                Text = e.Libelle,
                Value = e.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult AjouterDemande(Demande model)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    var result = _demandeService.CreerEntite(model);
                    if (result != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            }
            catch (Exception ex) { }

            ViewBag.InstitutionList = _institutionSanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Code,
                Value = e.Id.ToString()
            });

            ViewBag.TypeComposanteList = _typeComposanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Libelle,
                Value = e.Id.ToString()
            });
            return View(model);
        }

        public IActionResult ModifierDemande(long id)
        {
            ViewBag.InstitutionList = _institutionSanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Code,
                Value = e.Id.ToString()
            });

            ViewBag.TypeComposanteList = _typeComposanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Libelle,
                Value = e.Id.ToString()
            });

            try
            {
                var demande = _demandeService.RechercherEntite(id);
                if (demande == null)
                {
                    return BadRequest();
                }
                return View(demande);
            }
            catch (Exception ex) { }

            return View();
        }

        [HttpPost]
        public IActionResult ModifierDemande(Demande model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var demande = _demandeService.RechercherEntite(model.Id);
                    if (demande == null) 
                    {
                        return BadRequest();
                    }
                    demande.IdInstitutionSante = model.IdInstitutionSante;
                    demande.GroupeSanguin = model.GroupeSanguin;
                    demande.IdTypeComposante = model.IdTypeComposante;
                    demande.Quantite = model.Quantite;
                    demande.Statut = model.Statut;

                    var result = _demandeService.ModifierEntite(demande);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            }
            catch (Exception ex) { }

            ViewBag.InstitutionList = _institutionSanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Code,
                Value = e.Id.ToString()
            });

            ViewBag.TypeComposanteList = _typeComposanteService.RechercherEntites().Select(e => new SelectListItem
            {
                Text = e.Libelle,
                Value = e.Id.ToString()
            });

            return View(model);
        }
    }
}
