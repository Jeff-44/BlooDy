using BlooDyWeb.Data;
using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Repository.IRepository.ITransfusionModule;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository.TransfusionModule
{
    public class MedecinRepository : GenericRepository<Medecin>, IMedecinRepository
    {
        private readonly BlooDyContext _context;
        public MedecinRepository(BlooDyContext context) : base(context)
        {      
            _context = context;
        }

        public Medecin RechercherMedecin(long id)
        {
            return _context.Medecins
                           .Include(e => e.Personne)
                           .Single(e => e.Id == id);
        }

        public List<Medecin>? RechercherMedecins()
        {
            return _context.Medecins
               .Include(e => e.Personne).ToList();
        }
    }
}
