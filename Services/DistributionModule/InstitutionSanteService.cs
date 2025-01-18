using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;

namespace BlooDyWeb.Services.DistributionModule
{
    public class InstitutionSanteService : GenericService<InstitutionSante>, IInstitutionSanteService
    {
        public InstitutionSanteService(IInstitutionSanteRepository repository) : base(repository)
        {
            
        }
    }
}
