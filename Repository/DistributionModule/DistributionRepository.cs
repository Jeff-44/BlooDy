using BlooDyWeb.Data;
using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;


namespace BlooDyWeb.Repository.DistributionModule
{
    public class DistributionRepository : GenericRepository<Distribution>, IDistributionRepository
    {
        public DistributionRepository(BlooDyContext context) : base(context) 
        {
        }
    }
}
