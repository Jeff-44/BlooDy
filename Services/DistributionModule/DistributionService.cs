using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;

namespace BlooDyWeb.Services.DistributionModule
{
    public class DistributionService : GenericService<Distribution>, IDistributionService
    {
        public DistributionService(IDistributionRepository repository) : base(repository) 
        {
            
        }
    }
}
