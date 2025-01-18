using BlooDyWeb.Data;
using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository
{
    public class CentreRepository : ICentreRepository
    {
        private readonly BlooDyContext _context;
        public CentreRepository(BlooDyContext context)
        {
            _context = context;
        }
        public Centre CreerCentre(Centre model)
        {
            _context.Centres.Add(model);
            _context.SaveChanges();
            return model;
        }

        public Centre ModifierCentre(Centre model)
        {
            _context.Centres.Update(model);
            _context.SaveChanges();
            return model;
        }

        public Centre? RechercherCentre(long Id)
        {
            return _context.Centres.Single(c => c.Id == Id);
        }

        public Centre? RechercherCentre(string Code)
        {
            return _context.Centres.Single(c => c.Code == Code);
        }

        public List<Centre>? RechercherCentres()
        {
            return _context.Centres.AsNoTracking().ToList();
        }
    }
}
