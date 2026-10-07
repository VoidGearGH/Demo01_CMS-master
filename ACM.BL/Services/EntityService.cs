using System;
using CMS.BusinessLayer.Abstractions;

namespace CMS.BusinessLayer.Services
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IValidator<T> _validator;

        public EntityService(IRepository<T> repository, IValidator<T> validator)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (validator == null) throw new ArgumentNullException(nameof(validator));

            _repository = repository;
            _validator = validator;
        }

        public T Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public bool Save(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return _validator.Validate(entity) && _repository.Save(entity);
        }
    }
}
