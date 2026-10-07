using System.Collections.Generic;
using CMS.BusinessLayer;
using CMS.BusinessLayer.Abstractions;

namespace CMS.BusinessLayerTest
{
    internal class FakeRepository<T> : IRepository<T> where T : class
    {
        public T ItemToReturn { get; set; }
        public bool SaveResult { get; set; } = true;
        public int RetrieveCalls { get; private set; }
        public int LastRetrievedId { get; private set; }
        public int SaveCalls { get; private set; }
        public T LastSavedEntity { get; private set; }

        public T Retrieve(int id)
        {
            RetrieveCalls++;
            LastRetrievedId = id;
            return ItemToReturn;
        }

        public bool Save(T entity)
        {
            SaveCalls++;
            LastSavedEntity = entity;
            return SaveResult;
        }
    }

    internal class FakeCustomerRepository : FakeRepository<Customer>, ICustomerRepository
    {
        public IReadOnlyList<Customer> AllCustomers { get; set; } = new List<Customer>();
        public int RetrieveAllCalls { get; private set; }

        public IReadOnlyList<Customer> RetrieveAll()
        {
            RetrieveAllCalls++;
            return AllCustomers;
        }
    }

    internal class FakeValidator<T> : IValidator<T> where T : class
    {
        public bool Result { get; set; } = true;
        public int ValidateCalls { get; private set; }

        public bool Validate(T entity)
        {
            ValidateCalls++;
            return Result;
        }
    }
}
