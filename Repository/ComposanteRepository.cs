using BlooDyWeb.Data;
using BlooDyWeb.Models.Stock;
using BlooDyWeb.Repository.IRepository;

namespace BlooDyWeb.Repository
{
    public class ComposanteRepository : GenericRepository<Composante>, IComposanteRepository
    {
        public ComposanteRepository(BlooDyContext context) : base(context)
        {
        }
    }
}
