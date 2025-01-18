using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Services.IServices.ITransfusionModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class MedecinController : Controller
    {
        private readonly IMedecinService _medecinService;
        public MedecinController(IMedecinService medecinService)
        {
            _medecinService = medecinService;
        }
        [HttpGet("medecins")]
        public IActionResult Index()
        {
            IEnumerable<Medecin>? medecins = Enumerable.Empty<Medecin>();
            try
            {
                medecins = _medecinService.RechercherMedecins();
            } catch (Exception ex) { }
            
            return View(medecins);
        }
        public IActionResult Details(long id)
        {
            try
            {
                var medecin = _medecinService.RechercherMedecin(id);
                if (medecin == null) 
                {
                    return NotFound();
                }

                return View(medecin);
            }
            catch (Exception ex) { }

            return View();
        }

        public IActionResult AjouterMedecin()
        {
            ViewBag.StatutMatrimonialList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Célibataire",
                    Value = "Célibataire"
                },
                new SelectListItem
                {
                    Text = "Fiancé(e)",
                    Value = "Fiancé(e)"
                },
                new SelectListItem
                {
                    Text = "Marié(e)",
                    Value = "Marié(e)"
                },
                new SelectListItem
                {
                    Text = "Divorcé(e)",
                    Value = "Divorcé(e)"
                },
                new SelectListItem
                {
                    Text = "Union Libre",
                    Value = "Union Libre"
                }
            };
            return View();
        }

        [HttpPost]
        public IActionResult AjouterMedecin(Medecin model)
        {
            try
            {
                if(ModelState.IsValid) 
                {
                    model.CreeLe = DateTime.Now;
                    model.Code = Guid.NewGuid().ToString();
                    var result = _medecinService.CreerEntite(model);
                    if(result != null) 
                    {
                        return RedirectToAction(nameof(Details), new { id = model.Id });
                    }
                }
            } catch (Exception ex) { }

            ViewBag.StatutMatrimonialList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Célibataire",
                    Value = "Célibataire"
                },
                new SelectListItem
                {
                    Text = "Fiancé(e)",
                    Value = "Fiancé(e)"
                },
                new SelectListItem
                {
                    Text = "Marié(e)",
                    Value = "Marié(e)"
                },
                new SelectListItem
                {
                    Text = "Divorcé(e)",
                    Value = "Divorcé(e)"
                },
                new SelectListItem
                {
                    Text = "Union Libre",
                    Value = "Union Libre"
                }
            };

            return View(model);
        }

        public IActionResult ModifierMedecin(long id)
        {
            ViewBag.StatutMatrimonialList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Célibataire",
                    Value = "Célibataire"
                },
                new SelectListItem
                {
                    Text = "Fiancé(e)",
                    Value = "Fiancé(e)"
                },
                new SelectListItem
                {
                    Text = "Marié(e)",
                    Value = "Marié(e)"
                },
                new SelectListItem
                {
                    Text = "Divorcé(e)",
                    Value = "Divorcé(e)"
                },
                new SelectListItem
                {
                    Text = "Union Libre",
                    Value = "Union Libre"
                }
            };

            try
            {
                var medecin = _medecinService.RechercherMedecin(id);
                if (medecin == null)
                {
                    return NotFound();
                }

                return View(medecin);
            }
            catch (Exception ex) { }

            return View(); 
        }

        [HttpPost]
        public IActionResult ModifierMedecin(Medecin model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var medecin = _medecinService.RechercherEntite(model.Id);
                    if (medecin == null) 
                    {
                        return NotFound();
                    }

                    medecin.ModifieLe = DateTime.Now;
                    medecin.Personne = model.Personne;

                    var result = _medecinService.ModifierEntite(medecin);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            } catch (Exception ex) { }

            ViewBag.StatutMatrimonialList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Célibataire",
                    Value = "Célibataire"
                },
                new SelectListItem
                {
                    Text = "Fiancé(e)",
                    Value = "Fiancé(e)"
                },
                new SelectListItem
                {
                    Text = "Marié(e)",
                    Value = "Marié(e)"
                },
                new SelectListItem
                {
                    Text = "Divorcé(e)",
                    Value = "Divorcé(e)"
                },
                new SelectListItem
                {
                    Text = "Union Libre",
                    Value = "Union Libre"
                }
            };

            return View(model);
        }
    }
}
