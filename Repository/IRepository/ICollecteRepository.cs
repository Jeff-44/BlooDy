using BlooDyWeb.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace BlooDyWeb.Repository.IRepository
{
    public interface ICollecteRepository : IGenericRepository<Collecte>
    {
        List<Collecte>? RechercherCollectes();
        Collecte? RechercherCollecte(long id);

    }
}
