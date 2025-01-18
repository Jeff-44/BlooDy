using BlooDyWeb.Models;

namespace BlooDyWeb.Services.IServices
{
    public interface IExamenMedicalService
    {
        //ExamenMedical := Dossier
        ExamenMedical CreerDossier(ExamenMedical model);
        ExamenMedical ModifierDossier(ExamenMedical model);
        List<ExamenMedical>? RechercherDossiers();
        ExamenMedical? RechercherDossier(long Id);
        ExamenMedical? RechercherDossier(string Code);
    }
}
