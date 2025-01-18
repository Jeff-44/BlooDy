using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;

namespace BlooDyWeb.Services
{
    public class CentreService : ICentreService
    {
        private readonly ICentreRepository _repository;

        public CentreService(ICentreRepository repository)
        {
            _repository = repository;
        }
        public Centre CreerCentre(Centre model)
        {
            if(model == null) throw 
                    new ArgumentNullException("Vous devez fournir des informations pour enregistrer un Centre");
            model.Code = Guid.NewGuid().ToString();
            model.CreeLe = DateTime.Now;

            return _repository.CreerCentre(model);
        }

        public Centre ModifierCentre(Centre model)
        {
            var centre = _repository.RechercherCentre(model.Id);
            if (centre == null) throw new 
               InvalidOperationException("Vous devez indiquer les donnees du centre qu'il faudrait modifier");
            centre.NomCentre = model.NomCentre;
            centre.TypeCentre = model.TypeCentre;
            centre.Code = model.Code;
            centre.ModifieLe = DateTime.Now;
            return _repository.ModifierCentre(centre);
        }

        public Centre? RechercherCentre(long Id)
        {
            if (Id <= 0) throw new InvalidOperationException("");
            var centre = _repository.RechercherCentre(Id);
            if (centre == null) throw new Exception($"Il n'y a pas de centre avec cet Id: {Id}");
            return centre;
        }

        public Centre? RechercherCentre(string Code)
        {
            if (string.IsNullOrEmpty(Code)) throw new InvalidOperationException("Vous devez fournir le code du centre");
            var centre = _repository.RechercherCentre(Code);
            if (centre == null) throw new Exception($"Il n'y a pas de centre avec ce Code: {Code}");
            return centre;  
        }

        public List<Centre>? RechercherCentres()
        {
            return _repository.RechercherCentres();
        }
    }
}
