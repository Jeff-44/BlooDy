using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;

namespace BlooDyWeb.Services.DistributionModule
{
    public class TransportService : GenericService<Transport>, ITransportService
    {
        public TransportService(ITransportRepository repository) : base(repository)
        {
            
        }
    }
}
