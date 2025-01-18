using BlooDyWeb.Data;
using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BlooDyWeb.Services
{
    public class DonateurService : IDonateurService
    {
        private readonly IDonateurRepository _donateurRepository;

        public DonateurService(IDonateurRepository donateurRepository)
        {
            _donateurRepository = donateurRepository;
        }
        public Donateur CreerDonateur(Donateur model)
        {
            if (model == null) throw new
                    ArgumentNullException("Vous devez fournir les informations de bases pour un donateur");

            return _donateurRepository.CreerDonateur(model);
        }

        public Personne CreerPersonne(Personne model)
        {
            if (model == null) throw new
                ArgumentNullException("Vous devez fournir les informations de bases pour un donateur");
            return _donateurRepository.CreerPersonne(model);
        }

        public Donateur ModifierDonateur(Donateur model)
        {
            var donateurAModifier = _donateurRepository.RechercherDonateur(model.Id);
            if (donateurAModifier == null)
                throw new Exception($"Il n'existe pas de donateur pour cet Id: {model.Id}");

            donateurAModifier.Personne = model.Personne;
            donateurAModifier.GroupeSanguin = model.GroupeSanguin;
            donateurAModifier.PersonneDeContact = model.PersonneDeContact;
            donateurAModifier.ModifieLe = DateTime.Now;

            return _donateurRepository.ModifierDonateur(donateurAModifier);
        }

        public Donateur? RechercherDonateur(long Id)
        {
            if (Id <= 0) throw new ArgumentOutOfRangeException("Id invalide");
            var donateur = _donateurRepository.RechercherDonateur(Id);
            if (donateur == null) throw new Exception($"Impossible de trouver un donateur pour cet Id: {Id}");
            return donateur;
        }

        public Donateur? RechercherDonateur(string Code)
        {
            if (string.IsNullOrEmpty(Code)) throw new Exception("Code invalide");
            var donateur = _donateurRepository.RechercherDonateur(Code);
            if (donateur == null) throw new Exception($"Impossible de trouver un donateur pour cet Id: {Code}");
            return donateur;
        }

        public List<Donateur>? RechercherDonateurs()
        {
            return _donateurRepository.RechercherDonateurs();
        }
    }
}
