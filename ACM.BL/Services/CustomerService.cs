using System.Collections.Generic;
using CMS.BusinessLayer.Abstractions;

namespace CMS.BusinessLayer.Services
{
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository, IValidator<Customer> validator)
            : base(repository, validator)
        {
            _customerRepository = repository;
        }

        public IReadOnlyList<Customer> RetrieveAll()
        {
            return _customerRepository.RetrieveAll();
        }
    }
}
