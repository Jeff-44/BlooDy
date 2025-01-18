using BlooDyWeb.Data;
using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository.DistributionModule
{
    public class ChauffeurRepository : GenericRepository<Chauffeur>, IChauffeurRepository
    {
        private readonly BlooDyContext _context;
        public ChauffeurRepository(BlooDyContext context) : base(context)
        {
            _context = context;
        }

        public Chauffeur? RechercherChauffeur(long id)
        {
            var chauffeur = _context.Chauffeurs
                .Include(e => e.Personne)
                .Include(e => e.Centre)
                .SingleOrDefault(e => e.Id == id);
            return chauffeur;
        }
    }
}
