using CustomerApi.Data;
using CustomerApi.Models;

namespace CustomerApi.Services
{
    public class CustomerService
    {
        private readonly AppDBContext _dbContext;
        public CustomerService(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Customer CreateCustomer(Customer customer)
        {
            customer.CustomerId = Guid.NewGuid();
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }
        public void DeleteCustomer(Customer customer)
        {
            _dbContext.Remove(customer);
        }
        public Customer GetCustomerById(Guid customerId)
        {
            return _dbContext.Customers.Find(customerId);
        }
        public IEnumerable<Customer> GetCustomersByAge(int age)
        {
            DateTime today = DateTime.UtcNow;
            DateTime birthDateCutOff = today.AddYears(-age);
            return _dbContext.Customers.Where(c => c.DateOfBirth <= birthDateCutOff);
        }
        public Customer UpdateCustomer(Guid customerId,Customer customer)
        {
            var existingCustomer = _dbContext.Customers.Find(customerId);
            if (existingCustomer != null)
            {
                existingCustomer.FullName = customer.FullName;
                existingCustomer.DateOfBirth = customer.DateOfBirth;
                _dbContext.SaveChanges();
                return existingCustomer;

            }
            return null;
        }

  

        }
    }
