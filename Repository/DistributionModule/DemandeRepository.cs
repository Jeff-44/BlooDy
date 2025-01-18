using BlooDyWeb.Data;
using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;

namespace BlooDyWeb.Repository.DistributionModule
{
    public class DemandeRepository : GenericRepository<Demande>, IDemandeRepository
    {
        public DemandeRepository(BlooDyContext context) : base(context)
        {

        }
    }
}
