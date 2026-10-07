using System.Collections.Generic;

namespace CMS.BusinessLayer.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IReadOnlyList<Customer> RetrieveAll();
    }
}
