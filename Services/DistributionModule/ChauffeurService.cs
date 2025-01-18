using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;

namespace BlooDyWeb.Services.DistributionModule
{
    public class ChauffeurService : GenericService<Chauffeur>, IChauffeurService
    {
        private readonly IChauffeurRepository _repository;
        public ChauffeurService(IChauffeurRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Chauffeur? RechercherChauffeur(long id) 
        {
            Chauffeur? chauffeur = _repository.RechercherChauffeur(id);
            return chauffeur;   
        }
    }
}
