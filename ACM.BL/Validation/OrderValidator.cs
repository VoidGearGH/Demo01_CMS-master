using System;
using CMS.BusinessLayer.Abstractions;

namespace CMS.BusinessLayer.Validation
{
    public class OrderValidator : IValidator<Order>
    {
        public bool Validate(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            return order.OrderDate != null;
        }
    }
}
