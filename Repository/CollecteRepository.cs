using BlooDyWeb.Data;
using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository
{
    public class CollecteRepository : GenericRepository<Collecte>, ICollecteRepository
    {
        private readonly BlooDyContext _context;
        public CollecteRepository(BlooDyContext context) : base(context)
        {
            _context = context;
        }

        public Collecte? RechercherCollecte(long id)
        {
            return _context.Collectes.Include(c => c.Centre).FirstOrDefault(c => c.Id == id);
        }

        public List<Collecte>? RechercherCollectes()
        {
            return _context.Collectes.Include(c => c.Centre).AsNoTracking().ToList();
        }

    }
}
