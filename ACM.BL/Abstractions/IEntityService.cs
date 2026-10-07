namespace CMS.BusinessLayer.Abstractions
{
    public interface IEntityService<T> where T : class
    {
        T Retrieve(int id);
        bool Save(T entity);
    }
}
