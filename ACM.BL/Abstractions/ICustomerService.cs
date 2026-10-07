using System.Collections.Generic;

namespace CMS.BusinessLayer.Abstractions
{
    public interface ICustomerService : IEntityService<Customer>
    {
        IReadOnlyList<Customer> RetrieveAll();
    }
}
