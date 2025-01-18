using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;

namespace BlooDyWeb.Services
{
    public class DonService : GenericService<Don>, IDonService
    {
        private readonly IDonRepository _repository;
        public DonService(IDonRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public Don? ModifierDon(Don model)
        {
            var donExistant = _repository.RechercherEntite(model.Id);
            if (donExistant == null)
                throw new InvalidOperationException($"Il n'y a pas de don pour cet Id: {model.Id}");
            donExistant.ModifieLe = DateTime.Now;
            donExistant.DonateurId = model.DonateurId;
            donExistant.CollecteId = model.CollecteId;
            donExistant.Volume = model.Volume;
            donExistant.TestePositifPourMaladie = model.TestePositifPourMaladie;

            return _repository.ModifierEntite(donExistant);
        }

        public Don? RechercherDon(long id)
        {
            var don = _repository.RechercherDon(id);
            if(don == null) throw new InvalidOperationException($"Il n'y a pas de don pour cet Id: {id}");

            return don;
        }
    }
}
