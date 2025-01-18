using BlooDyWeb.Models.TransfusionModule;

namespace BlooDyWeb.Services.IServices.ITransfusionModule
{
    public interface ITransfusionService : IGenericService<Transfusion>
    {
        Transfusion? RechercherTransfusion(long id);
        List<Transfusion>? RechercherTransfusions();
    }
}
