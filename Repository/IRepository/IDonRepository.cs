using BlooDyWeb.Models;

namespace BlooDyWeb.Repository.IRepository
{
    public interface IDonRepository : IGenericRepository<Don>
    {
        Don? RechercherDon(long id);
    }
}
