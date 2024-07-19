using CustomerApi.Models;
using CustomerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomerAsync([FromBody] Customer customer)
        {
            customer.ProfileImageURL = await ProfileService.GenerateProfileImage(customer.FullName);
            var createdCustomer = _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { customerId = createdCustomer.CustomerId }, createdCustomer);
        }

        [HttpGet("{customerId}")]
        public ActionResult<Customer> GetCustomerById(Guid customerId)
        {
            var customer = _customerService.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("{age:int}")]
        public ActionResult<IEnumerable<Customer>> GetCustomersByAge(int age)
        {
            var customers = _customerService.GetCustomersByAge(age);
            return Ok(customers);
        }

        [HttpPatch("{customerId}")]
        public ActionResult<Customer> UpdateCustomer(Guid customerId, [FromBody] Customer customer)
        {
            var updatedCustomer = _customerService.UpdateCustomer(customerId, customer);
            if (updatedCustomer == null)
            {
                return NotFound();
            }
            return Ok(updatedCustomer);
        }
    }
}
