using BlooDyWeb.Data;
using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository
{
    public class ExamenMedicalRepository : IExamenMedicalRepository
    {
        private readonly BlooDyContext _context;

        public ExamenMedicalRepository(BlooDyContext context)
        {
            _context = context;
        }

        public ExamenMedical CreerDossier(ExamenMedical model)
        {
            _context.Dossiers.Add(model);
            _context.SaveChanges();
            return model;
        }

        public ExamenMedical ModifierDossier(ExamenMedical model)
        {
            _context.Dossiers.Update(model);
            _context.SaveChanges();
            return model;
        }

        public ExamenMedical? RechercherDossier(long Id)
        {
            ExamenMedical? dossier = _context.Dossiers.Include(dossier => dossier.Donateur)
                                                      .Include(dossier => dossier.Donateur.Personne)
                                                      .SingleOrDefault(d => d.Id == Id);
            return dossier;
        }

        public ExamenMedical? RechercherDossier(string Code)
        {
            ExamenMedical? dossier = _context.Dossiers.Include(d=>d.Donateur).SingleOrDefault(d => d.Donateur.Code == Code);
            return dossier;
        }

        public List<ExamenMedical>? RechercherDossiers()
        {
            var dossiers = _context.Dossiers.Include(dossier => dossier.Donateur).Include(dossier => dossier.Donateur.Personne).AsNoTracking().ToList();
            return dossiers;
        }
    }
}
