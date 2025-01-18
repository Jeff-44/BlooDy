using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Services.IServices;

namespace BlooDyWeb.Services
{
    public class GenericService<T> : IGenericService<T> where T : Audit
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public T CreerEntite(T model)
        {
            if (model == null) throw 
                    new ArgumentNullException("Vous devez fournir des informations necessaires.");
            model.CreeLe = DateTime.Now;
            
            return _repository.CreerEntite(model);
        }

        public T ModifierEntite(T model)
        {
            if (model == null) throw
                    new ArgumentNullException(nameof(T));
            return _repository.ModifierEntite(model);
        }

        public T? RechercherEntite(long Id)
        {
            if (Id <= 0) throw new InvalidOperationException($"Id: {Id} est invalide.");
            var entity = _repository.RechercherEntite(Id);
            
            return entity;
        }

        public List<T> RechercherEntites()
        {
            var entities = _repository.RechercherEntites();
            return entities;
        }

        public T? SupprimerEntite(T model)
        {
            var entity = RechercherEntite(model.Id);
            if (entity == null) throw new Exception("Operation invalide.");
            return _repository.SupprimerEntite(entity);
        }
    }
}
