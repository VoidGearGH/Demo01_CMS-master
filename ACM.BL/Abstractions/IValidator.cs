namespace CMS.BusinessLayer.Abstractions
{
    public interface IValidator<T> where T : class
    {
        bool Validate(T entity);
    }
}
