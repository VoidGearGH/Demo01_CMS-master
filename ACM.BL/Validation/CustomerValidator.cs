using System;
using CMS.BusinessLayer.Abstractions;

namespace CMS.BusinessLayer.Validation
{
    public class CustomerValidator : IValidator<Customer>
    {
        public bool Validate(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            return !string.IsNullOrWhiteSpace(customer.LastName)
                && !string.IsNullOrWhiteSpace(customer.EmailAddress);
        }
    }
}
