using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.BusinessLayer;
using CMS.BusinessLayer.Validation;

namespace CMS.BusinessLayerTest
{
    [TestClass]
    public class OrderItemValidatorTest
    {
        private readonly OrderItemValidator _validator = new OrderItemValidator();

        [TestMethod]
        public void ValidateValid()
        {
            var item = new OrderItem { OrderQuantity = 2, ProductId = 3, PurchasePrice = 9.99M };

            Assert.IsTrue(_validator.Validate(item));
        }

        [TestMethod]
        public void ValidateZeroQuantity()
        {
            var item = new OrderItem { OrderQuantity = 0, ProductId = 3, PurchasePrice = 9.99M };

            Assert.IsFalse(_validator.Validate(item));
        }

        [TestMethod]
        public void ValidateMissingProduct()
        {
            var item = new OrderItem { OrderQuantity = 2, PurchasePrice = 9.99M };

            Assert.IsFalse(_validator.Validate(item));
        }

        [TestMethod]
        public void ValidateMissingPrice()
        {
            var item = new OrderItem { OrderQuantity = 2, ProductId = 3 };

            Assert.IsFalse(_validator.Validate(item));
        }
    }
}
