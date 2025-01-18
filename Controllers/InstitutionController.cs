using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly IInstitutionSanteService _institutionSanteService;
        public InstitutionController(IInstitutionSanteService institutionSanteService)
        {
            _institutionSanteService = institutionSanteService;
        }
        [HttpGet("institutions")]
        public IActionResult Index()
        {
            IEnumerable<InstitutionSante> institutions = Enumerable.Empty<InstitutionSante>();
            try 
            {
                institutions = _institutionSanteService.RechercherEntites();

            } catch (Exception ex) { }

            return View(institutions);  
        }

        public IActionResult Details(long id)
        {
            try
            {
                var institution = _institutionSanteService.RechercherEntite(id);
                if(institution == null) 
                {
                    return NotFound();
                }
                return View(institution);
            }
            catch (Exception ex) { }

            return View();
        }

        public IActionResult AjouterInstitution()
        {
            ViewBag.CategorieList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Hopital",
                    Value = "Hopital"
                },
                new SelectListItem
                {
                    Text = "Centre de Sante",
                    Value = "Centre de Sante"
                }
            };
            return View();
        }

        [HttpPost]
        public IActionResult AjouterInstitution(InstitutionSante model)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    model.Code = Guid.NewGuid().ToString();
                    model.CreeLe = DateTime.Now;
                    var result = _institutionSanteService.CreerEntite(model);
                    if(result != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id});
                    }
                }
            } catch (Exception ex) { }

            ViewBag.CategorieList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Hopital",
                    Value = "Hopital"
                },
                new SelectListItem
                {
                    Text = "Centre de Sante",
                    Value = "Centre de Sante"
                }
            };

            return View(model);
        }

        public IActionResult ModifierInstitution(long id)
        {
            ViewBag.CategorieList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Hopital",
                    Value = "Hopital"
                },
                new SelectListItem
                {
                    Text = "Centre de Sante",
                    Value = "Centre de Sante"
                }
            };

            try
            {
                var institution = _institutionSanteService.RechercherEntite(id);
                if (institution != null) 
                {
                    return View(institution);
                }
            } catch (Exception ex) { }
            return View();
        }

        [HttpPost]
        public IActionResult ModifierInstitution(InstitutionSante model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var institution = _institutionSanteService.RechercherEntite(model.Id);
                    if (institution == null)
                    {
                        return BadRequest();
                    }
                    institution.Nom = model.Nom;
                    institution.Email = model.Email;
                    institution.Categorie = model.Categorie;
                    institution.Adresse = model.Adresse;
                    institution.Telephone = model.Telephone;
                    institution.IdVille = model.IdVille;
                    institution.Statut = model.Statut;
                    institution.ModifieLe = DateTime.Now;

                    var result = _institutionSanteService.ModifierEntite(institution);
                    if (result != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            }
            catch (Exception ex) { }

            ViewBag.CategorieList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Hopital",
                    Value = "Hopital"
                },
                new SelectListItem
                {
                    Text = "Centre de Sante",
                    Value = "Centre de Sante"
                }
            };

            return View(model);
        }
    }
}
