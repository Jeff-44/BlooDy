using BlooDyWeb.Models.TransfusionModule;

namespace BlooDyWeb.Repository.IRepository.ITransfusionModule
{
    public interface ITransfusionRepository : IGenericRepository<Transfusion>
    {
        Transfusion? RechercherTransfusion(long id);
        List<Transfusion>? RechercherTransfusions();
    }
}
