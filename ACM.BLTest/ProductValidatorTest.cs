using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.BusinessLayer;
using CMS.BusinessLayer.Validation;

namespace CMS.BusinessLayerTest
{
    [TestClass]
    public class ProductValidatorTest
    {
        private readonly ProductValidator _validator = new ProductValidator();

        [TestMethod]
        public void ValidateValid()
        {
            var product = new Product { ProductName = "Sunflowers", CurrentPrice = 15.96M };

            Assert.IsTrue(_validator.Validate(product));
        }

        [TestMethod]
        public void ValidateMissingName()
        {
            var product = new Product { CurrentPrice = 15.96M };

            Assert.IsFalse(_validator.Validate(product));
        }

        [TestMethod]
        public void ValidateMissingPrice()
        {
            var product = new Product { ProductName = "Sunflowers" };

            Assert.IsFalse(_validator.Validate(product));
        }
    }
}
