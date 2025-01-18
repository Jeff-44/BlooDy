using BlooDyWeb.Models;

namespace BlooDyWeb.Services.IServices
{
    public interface ICollecteService : IGenericService<Collecte>
    {
        Collecte? ModifierCollecte(Collecte model);
        Collecte? RechercherCollecte(long id);
        List<Collecte>? RechercherCollectes();
    }
}
