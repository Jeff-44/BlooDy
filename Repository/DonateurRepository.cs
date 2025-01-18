using BlooDyWeb.Data;
using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository
{
    public class DonateurRepository : IDonateurRepository
    {
        private readonly BlooDyContext _context;
        public DonateurRepository(BlooDyContext context)
        {
            _context = context;
        }
        public Donateur CreerDonateur(Donateur model)
        {
            _context.Donateurs.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Personne CreerPersonne(Personne model)
        {
            _context.Personnes.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Donateur ModifierDonateur(Donateur model)
        {
            _context.Donateurs.Update(model);
            _context.SaveChanges();
            return model;
        }

        public Donateur? RechercherDonateur(long Id)
        {
            return _context.Donateurs.Include(d => d.Personne).AsNoTracking().FirstOrDefault(donateur => donateur.Id == Id);
        }

        public Donateur? RechercherDonateur(string Code)
        {
            return _context.Donateurs.FirstOrDefault(donateur => donateur.Code == Code);
        }

        public List<Donateur>? RechercherDonateurs()
        {
            return _context.Donateurs.Include(d => d.Personne).ToList();
        }
    }
}
