using System;
using CMS.BusinessLayer.Abstractions;

namespace CMS.BusinessLayer.Validation
{
    public class ProductValidator : IValidator<Product>
    {
        public bool Validate(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return !string.IsNullOrWhiteSpace(product.ProductName)
                && product.CurrentPrice != null;
        }
    }
}
