using BlooDyWeb.Models.DistributionModule;

namespace BlooDyWeb.Repository.IRepository.IDistributionModule
{
    public interface IChauffeurRepository : IGenericRepository<Chauffeur>
    {
        Chauffeur? RechercherChauffeur(long id);
    }
}
