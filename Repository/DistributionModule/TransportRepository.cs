using BlooDyWeb.Data;
using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;

namespace BlooDyWeb.Repository.DistributionModule
{
    public class TransportRepository : GenericRepository<Transport>, ITransportRepository
    {
        public TransportRepository(BlooDyContext context) : base(context)
        {

        }
    }
}
