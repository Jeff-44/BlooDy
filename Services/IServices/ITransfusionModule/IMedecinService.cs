using BlooDyWeb.Models.TransfusionModule;

namespace BlooDyWeb.Services.IServices.ITransfusionModule
{
    public interface IMedecinService : IGenericService<Medecin>
    {
        Medecin? RechercherMedecin(long id);
        List<Medecin>? RechercherMedecins();
    }
}
