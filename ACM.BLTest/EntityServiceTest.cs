using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.BusinessLayer;
using CMS.BusinessLayer.Services;

namespace CMS.BusinessLayerTest
{
    [TestClass]
    public class EntityServiceTest
    {
        private FakeRepository<Product> _repository;
        private FakeValidator<Product> _validator;
        private EntityService<Product> _service;

        [TestInitialize]
        public void Setup()
        {
            _repository = new FakeRepository<Product>();
            _validator = new FakeValidator<Product>();
            _service = new EntityService<Product>(_repository, _validator);
        }

        [TestMethod]
        public void SaveValidEntityDelegatesToRepository()
        {
            var product = new Product(1);
            _validator.Result = true;
            _repository.SaveResult = true;

            var actual = _service.Save(product);

            Assert.IsTrue(actual);
            Assert.AreEqual(1, _repository.SaveCalls);
            Assert.AreSame(product, _repository.LastSavedEntity);
        }

        [TestMethod]
        public void SaveInvalidEntityDoesNotTouchRepository()
        {
            _validator.Result = false;

            var actual = _service.Save(new Product(1));

            Assert.IsFalse(actual);
            Assert.AreEqual(0, _repository.SaveCalls);
        }

        [TestMethod]
        public void SaveReturnsRepositoryFailure()
        {
            _validator.Result = true;
            _repository.SaveResult = false;

            var actual = _service.Save(new Product(1));

            Assert.IsFalse(actual);
            Assert.AreEqual(1, _repository.SaveCalls);
        }

        [TestMethod]
        public void RetrieveDelegatesToRepository()
        {
            var product = new Product(7);
            _repository.ItemToReturn = product;

            var actual = _service.Retrieve(7);

            Assert.AreSame(product, actual);
            Assert.AreEqual(7, _repository.LastRetrievedId);
            Assert.AreEqual(0, _validator.ValidateCalls);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveNullEntityThrows()
        {
            _service.Save(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullRepositoryThrows()
        {
            new EntityService<Product>(null, _validator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullValidatorThrows()
        {
            new EntityService<Product>(_repository, null);
        }
    }
}
