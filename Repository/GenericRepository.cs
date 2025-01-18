using BlooDyWeb.Data;
using BlooDyWeb.Models;
using BlooDyWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlooDyWeb.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Audit
    {
        private readonly BlooDyContext _context;
        public GenericRepository(BlooDyContext context)
        {
            _context = context;
        }
        public T CreerEntite(T model)
        {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
            return model;
        }

        public T ModifierEntite(T model)
        {
            _context.Set<T>().Update(model);
            _context.SaveChanges();
            return model;
        }

        public T? RechercherEntite(long Id)
        {
            var entity = _context.Set<T>().SingleOrDefault(e => e.Id == Id);
            return entity;
        }

        public List<T> RechercherEntites()
        {
            var entities = _context.Set<T>().AsNoTracking().ToList();
            return entities;
        }

        public T? SupprimerEntite(T model)
        {
            _context.Set<T>().Remove(model);
            _context.SaveChanges();
            return model;
        }
    }
}
