using BlooDyWeb.Models;

namespace BlooDyWeb.Services.IServices
{
    public interface IDonService : IGenericService<Don>
    {
        Don? ModifierDon(Don model);
        Don? RechercherDon(long id);
    }
}
