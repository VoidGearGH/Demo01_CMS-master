using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.BusinessLayer;
using CMS.BusinessLayer.Validation;

namespace CMS.BusinessLayerTest
{
    [TestClass]
    public class CustomerValidatorTest
    {
        private readonly CustomerValidator _validator = new CustomerValidator();

        [TestMethod]
        public void ValidateValid()
        {
            var customer = new Customer { LastName = "Baggins", EmailAddress = "fbaggins@hobbiton.me" };

            Assert.IsTrue(_validator.Validate(customer));
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            var customer = new Customer { EmailAddress = "fbaggins@hobbiton.me" };

            Assert.IsFalse(_validator.Validate(customer));
        }

        [TestMethod]
        public void ValidateMissingEmailAddress()
        {
            var customer = new Customer { LastName = "Baggins" };

            Assert.IsFalse(_validator.Validate(customer));
        }

        [TestMethod]
        public void ValidateWhitespaceLastName()
        {
            var customer = new Customer { LastName = "   ", EmailAddress = "fbaggins@hobbiton.me" };

            Assert.IsFalse(_validator.Validate(customer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullThrows()
        {
            _validator.Validate(null);
        }
    }
}
