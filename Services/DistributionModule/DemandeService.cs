using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;

namespace BlooDyWeb.Services.DistributionModule
{
    public class DemandeService : GenericService<Demande>, IDemandeService
    {
        public DemandeService(IDemandeRepository repository) : base(repository)
        {
            
        }
    }
}
