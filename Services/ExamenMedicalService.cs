using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;

namespace BlooDyWeb.Services
{
    public class ExamenMedicalService : IExamenMedicalService
    {
        public readonly IExamenMedicalRepository _repository;
        public ExamenMedicalService(IExamenMedicalRepository repository)
        {
            _repository = repository;
        }
        public ExamenMedical CreerDossier(ExamenMedical model)
        {
            if (model == null) throw 
                    new ArgumentNullException("Vous devez fournir des informations pour enregistrer un dossier médical pour le donneur");
            model.CreeLe = DateTime.Now;
            var result = _repository.CreerDossier(model);
            return result;
        }

        public ExamenMedical ModifierDossier(ExamenMedical model)
        {
            var dossierExistant = _repository.RechercherDossier(model.Id);
            if (dossierExistant == null) throw new InvalidOperationException($"Il n'y a pas de dossier pour l'Id: {model.Id}");
            dossierExistant.ModifieLe = DateTime.Now;
            dossierExistant.DonateurId = model.DonateurId;
            dossierExistant.Poids = model.Poids;
            dossierExistant.Pouls = model.Pouls;
            dossierExistant.TensionArterielleSystolique = model.TensionArterielleSystolique;
            dossierExistant.TensionArterielleDiastolique = model.TensionArterielleDiastolique;
            dossierExistant.Hemoglobine = model.Hemoglobine;
            dossierExistant.EtatDeSante = model.EtatDeSante;
            
            return _repository.ModifierDossier(dossierExistant);
        }
        public ExamenMedical? RechercherDossier(long Id)
        {
            if (Id <= 0) throw new InvalidOperationException($"L'Id: {Id} est invalide");
            var result = _repository.RechercherDossier(Id);
            if (result == null) throw new Exception($"Il y a aucun dossier pour cet Id: {Id}.");

            return result;
        }

        public ExamenMedical? RechercherDossier(string Code)
        {
            if (string.IsNullOrEmpty(Code)) throw new InvalidOperationException($"Ce code: {Code} est invalide.");
            var result = _repository.RechercherDossier(Code);
            if (result == null) throw new Exception($"Il y a aucun dossier pour ce code: {Code}.");

            return result;
        }

        public List<ExamenMedical>? RechercherDossiers()
        {
            var result = _repository.RechercherDossiers();
            return result;
        }
    }
}
