using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.BusinessLayer;
using CMS.BusinessLayer.Services;
using CMS.BusinessLayer.Validation;

namespace CMS.BusinessLayerTest
{
    [TestClass]
    public class CustomerServiceTest
    {
        [TestMethod]
        public void RetrieveAllDelegatesToRepository()
        {
            var repository = new FakeCustomerRepository();
            var customers = new List<Customer> { new Customer(1), new Customer(2) };
            repository.AllCustomers = customers;
            var service = new CustomerService(repository, new FakeValidator<Customer>());

            var actual = service.RetrieveAll();

            Assert.AreSame(customers, actual);
            Assert.AreEqual(1, repository.RetrieveAllCalls);
        }

        [TestMethod]
        public void SaveWithRealValidatorRejectsCustomerWithoutEmail()
        {
            var repository = new FakeCustomerRepository();
            var service = new CustomerService(repository, new CustomerValidator());
            var customer = new Customer { LastName = "Baggins" };

            var actual = service.Save(customer);

            Assert.IsFalse(actual);
            Assert.AreEqual(0, repository.SaveCalls);
        }

        [TestMethod]
        public void SaveWithRealValidatorStoresValidCustomer()
        {
            var repository = new FakeCustomerRepository();
            var service = new CustomerService(repository, new CustomerValidator());
            var customer = new Customer { LastName = "Baggins", EmailAddress = "fbaggins@hobbiton.me" };

            var actual = service.Save(customer);

            Assert.IsTrue(actual);
            Assert.AreSame(customer, repository.LastSavedEntity);
        }
    }
}
