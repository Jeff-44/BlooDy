using BlooDyWeb.Models.TransfusionModule;

namespace BlooDyWeb.Services.IServices.ITransfusionModule
{
    public interface IBeneficiaireService : IGenericService<Beneficiaire>
    {
        Beneficiaire? RechercherBeneficiaire(long id);
        public List<Beneficiaire>? RechercherBeneficiaires();
    }
}
