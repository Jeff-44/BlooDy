using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Services.DistributionModule;
using BlooDyWeb.Services.IServices;
using BlooDyWeb.Services.IServices.IDistributionModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlooDyWeb.Controllers
{
    public class ChauffeurController : Controller
    {
        private readonly IChauffeurService _chauffeurService;
        private readonly ICentreService _centreService;
        public ChauffeurController(
            IChauffeurService chauffeurService,
            ICentreService centreService)
        {
            _chauffeurService = chauffeurService;
            _centreService = centreService;
        }
        [HttpGet("chauffeurs")]
        public IActionResult Index()
        {
            IEnumerable<Chauffeur> chauffeurs = Enumerable.Empty<Chauffeur>();
            try 
            {
                chauffeurs = _chauffeurService.RechercherEntites();
            } catch (Exception ex) { }

            return View(chauffeurs);
        }

        public IActionResult Details(long id)
        {
            try
            {
                var chauffeur = _chauffeurService.RechercherChauffeur(id);
                if (chauffeur == null) 
                {
                    return NotFound();
                }
                return View(chauffeur);
            }
            catch (Exception ex) { }

            return View();
        }

        public IActionResult AjouterChauffeur()
        {
            ViewBag.CentreList = _centreService.RechercherCentres()?.Select(e => new SelectListItem
            {
                Text = e.NomCentre,
                Value = e.Id.ToString()
            });

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
        public IActionResult AjouterChauffeur(Chauffeur model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    model.Code = Guid.NewGuid().ToString();
                    var result = _chauffeurService.CreerEntite(model);
                    if (result == null)
                    {
                        return BadRequest();
                    }

                    return RedirectToAction(nameof(Details), new { id = result.Id});
                }
            }
            catch (Exception ex) { }

            ViewBag.CentreList = _centreService.RechercherCentres()?.Select(e => new SelectListItem
            {
                Text = e.NomCentre,
                Value = e.Id.ToString()
            });

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

        public IActionResult ModifierChauffeur(long id)
        {
            ViewBag.CentreList = _centreService.RechercherCentres()?.Select(e => new SelectListItem
            {
                Text = e.NomCentre,
                Value = e.Id.ToString()
            });

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
                var chauffeur = _chauffeurService.RechercherChauffeur(id);
                if (chauffeur == null)
                {
                    return BadRequest();
                }
                return View(chauffeur);
            }
            catch (Exception ex) { }
            return View();
        }

        [HttpPost]
        public IActionResult ModifierChauffeur(Chauffeur model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var chauffeur = _chauffeurService.RechercherEntite(model.Id);
                    if (chauffeur == null)
                    {
                        return BadRequest();
                    }

                    chauffeur.CentreId = model.CentreId;
                    chauffeur.Personne = model.Personne;

                    var result = _chauffeurService.ModifierEntite(chauffeur);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Details), new { id = result.Id });
                    }
                }
            }
            catch (Exception ex) { }

            ViewBag.CentreList = _centreService.RechercherCentres()?.Select(e => new SelectListItem
            {
                Text = e.NomCentre,
                Value = e.Id.ToString()
            });

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
