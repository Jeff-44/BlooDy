using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Repository.IRepository.ITransfusionModule;
using BlooDyWeb.Services.IServices.ITransfusionModule;

namespace BlooDyWeb.Services.TransfusionModule
{
    public class BeneficiaireService : GenericService<Beneficiaire>, IBeneficiaireService
    {
        private readonly IBeneficiaireRepository _repository;
        public BeneficiaireService(IBeneficiaireRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Beneficiaire? RechercherBeneficiaire(long id)
        {
            var beneficiaire = _repository.RechercherBeneficiaire(id);
            return beneficiaire;
        }

        public List<Beneficiaire>? RechercherBeneficiaires()
        {
            return _repository.RechercherBeneficiaires();
        }
    }
}
