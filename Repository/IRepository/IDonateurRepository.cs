using BlooDyWeb.Models;

namespace BlooDyWeb.Repository.IRepository
{
    public interface IDonateurRepository
    {
        Personne CreerPersonne(Personne model);
        Donateur CreerDonateur(Donateur model);
        Donateur ModifierDonateur(Donateur model);
        List<Donateur>? RechercherDonateurs();
        Donateur? RechercherDonateur(long Id);
        Donateur? RechercherDonateur(string Code);
    }
}
