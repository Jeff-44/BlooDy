using BlooDyWeb.Data;
using BlooDyWeb.Models.Stock;
using BlooDyWeb.Repository.IRepository;

namespace BlooDyWeb.Repository
{
    public class TypeComposanteRepository : GenericRepository<TypeComposante>, ITypeComposanteRepository
    {
        public TypeComposanteRepository(BlooDyContext context) : base(context)
        {
        }
    }
}
