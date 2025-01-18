using BlooDyWeb.Models;

namespace BlooDyWeb.Services.IServices
{
    public interface IDonateurService
    {
        Personne CreerPersonne(Personne model);
        Donateur CreerDonateur(Donateur model);
        Donateur ModifierDonateur(Donateur model);
        List<Donateur>? RechercherDonateurs();
        Donateur? RechercherDonateur(long Id);
        Donateur? RechercherDonateur(string Code);
    }
}
