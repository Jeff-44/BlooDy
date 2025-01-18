using BlooDyWeb.Data;
using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Repository.IRepository.ITransfusionModule;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository.TransfusionModule
{
    public class BeneficiaireRepository : GenericRepository<Beneficiaire>, IBeneficiaireRepository
    {
        private readonly BlooDyContext _context;
        public BeneficiaireRepository(BlooDyContext context) : base(context)
        {
            _context = context;
        }

        public Beneficiaire? RechercherBeneficiaire(long id)
        {
            return _context.Beneficiaires
                           .Include(e => e.Personne)
                           .Single(i => i.Id == id);
        }

        public List<Beneficiaire>? RechercherBeneficiaires() 
        {
            return _context.Beneficiaires
               .Include(e => e.Personne).ToList();
        }
    }
}
