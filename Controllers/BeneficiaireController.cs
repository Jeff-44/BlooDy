using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Services.IServices.ITransfusionModule;
using Microsoft.AspNetCore.Mvc;

namespace BlooDyWeb.Controllers
{
    public class BeneficiaireController : Controller
    {
        private readonly IBeneficiaireService _beneficiaireService;
        public BeneficiaireController(
                IBeneficiaireService beneficiaireService
            )
        {
            _beneficiaireService = beneficiaireService;
        }
        [HttpGet("beneficiaires")]
        public IActionResult Index()
        {
            IEnumerable<Beneficiaire>? beneficiaires = Enumerable.Empty<Beneficiaire>();

            try
            {
                beneficiaires = _beneficiaireService.RechercherBeneficiaires();
            } catch(Exception ex) { }

            return View(beneficiaires);
        }

        public IActionResult Details(long id)
        {
            try 
            {
                var beneficiaire = _beneficiaireService.RechercherBeneficiaire(id);
                if (beneficiaire == null) 
                {
                    return NotFound();
                }
                return View(beneficiaire);
            } catch(Exception ex) { }

            return View();
        }

        public IActionResult AjouterBeneficiaire()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AjouterBeneficiaire(Beneficiaire model)
        {
            try 
            {
                if(ModelState.IsValid) 
                {
                    model.CreeLe = DateTime.Now;
                    model.Code = Guid.NewGuid().ToString();
                    var result = _beneficiaireService.CreerEntite(model);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            } catch(Exception ex) { }

            return View(model);
        }
        public IActionResult ModifierBeneficiaire(long id)
        {
            try
            {
                var beneficiaire = _beneficiaireService.RechercherBeneficiaire(id);
                if (beneficiaire == null)
                {
                    return NotFound();
                }
                return View(beneficiaire);
            }
            catch (Exception ex) { }

            return View();
        }

        [HttpPost]
        public IActionResult ModifierBeneficiaire(Beneficiaire model)
        {
            try 
            {
                if(ModelState.IsValid) 
                {
                    var beneficiaire = _beneficiaireService.RechercherEntite(model.Id);
                    if (beneficiaire == null) { return NotFound(); }

                    beneficiaire.ModifieLe = DateTime.Now;
                    beneficiaire.Personne = model.Personne;
                    beneficiaire.GroupeSanguin = model.GroupeSanguin;
                    beneficiaire.HistoriqueMedical = model.HistoriqueMedical;
                    beneficiaire.PersonneContactId = model.PersonneContactId;

                    var result = _beneficiaireService.ModifierEntite(beneficiaire);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            } catch(Exception ex) { }

            return View(model);
        }
    }
}
