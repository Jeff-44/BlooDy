using BlooDyWeb.Data;
using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository
{
    public class DonRepository : GenericRepository<Don>, IDonRepository
    {
        private readonly BlooDyContext _context;
        public DonRepository(BlooDyContext context) : base(context)
        {
            _context = context;
        }

        public Don? RechercherDon(long id)
        {
            return _context.Dons
                .Include(d => d.donateur)
                .Include(d => d.Collecte.Centre)
                .FirstOrDefault(d => d.Id == id);
        }
    }
}
