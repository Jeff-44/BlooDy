namespace BlooDyWeb.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        T CreerEntite(T model);
        T ModifierEntite(T model);
        List<T> RechercherEntites();
        T? RechercherEntite(long Id);
        T? SupprimerEntite(T model);
    }
}
