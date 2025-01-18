using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;

namespace BlooDyWeb.Services.IServices.IDistributionModule
{
    public interface IChauffeurService : IGenericService<Chauffeur>
    {
        public Chauffeur? RechercherChauffeur(long id);
    }
}
