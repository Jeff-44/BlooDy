using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlooDyWeb.Controllers
{
    public class DonateurController : Controller
    {
        private readonly IDonateurService _donateurService;
        public DonateurController(IDonateurService donateurService)
        {
            _donateurService = donateurService;
        }

        [HttpGet("donateurs")]
        public IActionResult Index()
        {
            var result = _donateurService.RechercherDonateurs();
            return View(result);
        }

        [HttpGet("details-donateur/{id}")]
        public IActionResult Details(long id)
        {
            var result = _donateurService.RechercherDonateur(id);
            return View(result);
        }

        [HttpGet("donateur/{code}")]
        public IActionResult RechercheParCode(string code)
        {
            var result = _donateurService.RechercherDonateur(code);
            return View(result);
        }

        [HttpGet("nouveau-donateur")]
        public IActionResult Ajouter() 
        {
            return View();
        }

        
        [HttpPost("nouveau-donateur")]
        public IActionResult Ajouter(Donateur model) 
        {
            if(ModelState.IsValid) 
            {
                _donateurService.CreerPersonne(model.Personne);
                model.PersonneId = model.Personne.Id;
                model.CreeLe = DateTime.Now;
                model.Code = Guid.NewGuid().ToString();
                _donateurService.CreerDonateur(model);
                return RedirectToAction(nameof(Details), model.Id);
            }

            return View(model);
        }

        [HttpGet("modifier-donateur/{id}")]
        public IActionResult Modifier(long id)
        {
            var result = _donateurService.RechercherDonateur(id);
            if(result != null) 
            {
                return View(result);
            }
            return View();
        }

        [HttpPost("modifier-donateur")]
        public IActionResult Modifier(Donateur model)
        {
            if (ModelState.IsValid)
            {
                var result = _donateurService.ModifierDonateur(model);
                return RedirectToAction(nameof(Details), result);
            }

            return View(model);
        }
    }
}
