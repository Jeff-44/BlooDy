using BlooDyWeb.Data;
using BlooDyWeb.Models;

namespace BlooDyWeb.Repository.IRepository
{
    public interface IExamenMedicalRepository
    {
        //ExamenMedical := Dossier
        ExamenMedical CreerDossier(ExamenMedical model);
        ExamenMedical ModifierDossier(ExamenMedical model);
        List<ExamenMedical>? RechercherDossiers();
        ExamenMedical? RechercherDossier(long Id);
        ExamenMedical? RechercherDossier(string Code);
    }
}
