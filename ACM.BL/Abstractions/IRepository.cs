namespace CMS.BusinessLayer.Abstractions
{
    public interface IRepository<T> where T : class
    {
        T Retrieve(int id);
        bool Save(T entity);
    }
}
