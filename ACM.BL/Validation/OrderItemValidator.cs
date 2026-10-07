using System;
using CMS.BusinessLayer.Abstractions;

namespace CMS.BusinessLayer.Validation
{
    public class OrderItemValidator : IValidator<OrderItem>
    {
        public bool Validate(OrderItem orderItem)
        {
            if (orderItem == null) throw new ArgumentNullException(nameof(orderItem));

            return orderItem.OrderQuantity > 0
                && orderItem.ProductId > 0
                && orderItem.PurchasePrice != null;
        }
    }
}
