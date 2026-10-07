using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.BusinessLayer;
using CMS.BusinessLayer.Validation;

namespace CMS.BusinessLayerTest
{
    [TestClass]
    public class OrderValidatorTest
    {
        private readonly OrderValidator _validator = new OrderValidator();

        [TestMethod]
        public void ValidateValid()
        {
            var order = new Order { OrderDate = DateTimeOffset.Now };

            Assert.IsTrue(_validator.Validate(order));
        }

        [TestMethod]
        public void ValidateMissingDate()
        {
            Assert.IsFalse(_validator.Validate(new Order()));
        }
    }
}
