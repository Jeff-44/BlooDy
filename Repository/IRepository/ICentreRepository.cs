using BlooDyWeb.Models;

namespace BlooDyWeb.Repository.IRepository
{
    public interface ICentreRepository
    {
        Centre CreerCentre(Centre model);
        Centre ModifierCentre(Centre model);
        List<Centre>? RechercherCentres();
        Centre? RechercherCentre(long Id);
        Centre? RechercherCentre(string Code);
    }
}
