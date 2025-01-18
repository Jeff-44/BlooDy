using BlooDyWeb.Models.TransfusionModule;
using BlooDyWeb.Repository.IRepository.ITransfusionModule;
using BlooDyWeb.Services.IServices.ITransfusionModule;

namespace BlooDyWeb.Services.TransfusionModule
{
    public class TransfusionService : GenericService<Transfusion>, ITransfusionService
    {
        private readonly ITransfusionRepository _repository;
        public TransfusionService(ITransfusionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Transfusion? RechercherTransfusion(long id)
        {
            return _repository.RechercherTransfusion(id);
        }

        public List<Transfusion>? RechercherTransfusions()
        {
            throw new NotImplementedException();
        }
    }
}
