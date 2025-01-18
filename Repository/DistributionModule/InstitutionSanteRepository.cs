using BlooDyWeb.Data;
using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;

namespace BlooDyWeb.Repository.DistributionModule
{
    public class InstitutionSanteRepository : GenericRepository<InstitutionSante>, IInstitutionSanteRepository
    {
        public InstitutionSanteRepository(BlooDyContext context) : base(context)
        {

        }
    }
}
