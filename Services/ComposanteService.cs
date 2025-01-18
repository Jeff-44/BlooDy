using BlooDyWeb.Models.Stock;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;

namespace BlooDyWeb.Services
{
    public class ComposanteService : GenericService<Composante>, IComposanteService
    {
        public ComposanteService(IComposanteRepository repository) : base(repository)
        {
        }
    }
}
