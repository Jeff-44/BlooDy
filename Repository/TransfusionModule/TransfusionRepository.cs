using BlooDyWeb.Data;
using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Repository.IRepository.ITransfusionModule;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository.TransfusionModule
{
    public class TransfusionRepository : GenericRepository<Transfusion>, ITransfusionRepository
    {
        private readonly BlooDyContext _context;
        public TransfusionRepository(BlooDyContext context) : base(context)
        {
            _context = context;
        }

        public Transfusion? RechercherTransfusion(long id)
        {
            return _context.Transfusions
                           .Include(e => e.Beneficiaire)
                           .Include(e => e.Composante)
                           .Include(e => e.Medecin)
                           .Single(e => e.Id == id);
        }

        public List<Transfusion>? RechercherTransfusions()
        {
            throw new NotImplementedException();
        }
    }
}
