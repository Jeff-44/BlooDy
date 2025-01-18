using BlooDyWeb.Models.Stock;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;

namespace BlooDyWeb.Services
{
    public class TypeComposanteService : GenericService<TypeComposante>, ITypeComposanteService
    {
        public TypeComposanteService(ITypeComposanteRepository repository) : base(repository)
        {
        }
    }
}
