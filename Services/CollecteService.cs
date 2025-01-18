using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;

namespace BlooDyWeb.Services
{
    public class CollecteService : GenericService<Collecte>, ICollecteService
    {
        private readonly ICollecteRepository _repository;
        public CollecteService(ICollecteRepository repository) : base(repository) 
        {
            _repository = repository;
        }

        public Collecte? ModifierCollecte(Collecte model) 
        {
            var collecteExistant = _repository.RechercherEntite(model.Id);
            if (collecteExistant == null) 
            throw new InvalidOperationException($"Il n'y a pas de collecte pour cet Id: {model.Id}");
            collecteExistant.ModifieLe = DateTime.Now;
            collecteExistant.CentreId = model.CentreId;
            collecteExistant.DateCollecte = model.DateCollecte;
            collecteExistant.Organisateur = model.Organisateur;
            
            return _repository.ModifierEntite(collecteExistant);
        }

        public Collecte? RechercherCollecte(long id)
        {
            var collecte = _repository.RechercherCollecte(id);
            if (collecte == null) 
                throw new InvalidOperationException($"Il n'y a pas de collecte pour cet Id: {id}");
            return collecte;
        }

        public List<Collecte>? RechercherCollectes()
        {
            return _repository.RechercherCollectes();
        }
    }
}
