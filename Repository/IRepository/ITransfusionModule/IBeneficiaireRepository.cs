using BlooDyWeb.Models.TransfusionModule;

namespace BlooDyWeb.Repository.IRepository.ITransfusionModule
{
    public interface IBeneficiaireRepository : IGenericRepository<Beneficiaire>
    {
        Beneficiaire? RechercherBeneficiaire(long id);
        public List<Beneficiaire>? RechercherBeneficiaires();
    }
}
