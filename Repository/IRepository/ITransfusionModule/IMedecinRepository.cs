using BlooDyWeb.Models.TransfusionModule;

namespace BlooDyWeb.Repository.IRepository.ITransfusionModule
{
    public interface IMedecinRepository : IGenericRepository<Medecin>
    {
        Medecin RechercherMedecin(long id);
        List<Medecin>? RechercherMedecins();
    }
}
