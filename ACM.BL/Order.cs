using System;

namespace CMS.BusinessLayer
{
    public class Order
    {
        public Order() { }

        public Order(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; private set; }
        public DateTimeOffset? OrderDate { get; set; }
    }
}