using BlooDyWeb.Models;

namespace BlooDyWeb.Services.IServices
{
    public interface ICentreService
    {
        Centre CreerCentre(Centre model);
        Centre ModifierCentre(Centre model);
        List<Centre>? RechercherCentres();
        Centre? RechercherCentre(long Id);
        Centre? RechercherCentre(string Code);
    }
}
