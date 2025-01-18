using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Repository.IRepository.ITransfusionModule;
using BlooDyWeb.Services.IServices.ITransfusionModule;

namespace BlooDyWeb.Services.TransfusionModule
{
    public class MedecinService : GenericService<Medecin>, IMedecinService
    {
        private readonly IMedecinRepository _repository;
        public MedecinService(IMedecinRepository repository) : base(repository) 
        {
            _repository = repository;
        }

        public Medecin? RechercherMedecin(long id)
        {
            return _repository.RechercherMedecin(id);
        }

        public List<Medecin>? RechercherMedecins()
        {
            return _repository.RechercherMedecins();
        }
    }
}
