namespace CMS.BusinessLayer
{
    public class Customer
    {
        public Customer() { }

        public Customer(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EmailAddress { get; set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }
    }
}