using ApplicationLayer.Contract;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        public async Task<List<Customer>> GetAll()
        {
            var data =await _customer.GetAllCustomersAsync();
            return data;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> getById(int id)
        {
            var data = await _customer.GetCustomersByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ServiceResponse> AddCustomer([FromBody]Customer customer)
        {
            var result = await _customer.AddCustomerAsync(customer);
            return result;
        }

        [HttpPut]
        public async Task<ServiceResponse> UpdateCustomer([FromBody]Customer customer)
        {
            var result = await _customer.UpdateCustomerAsync(customer);
            return result;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var result = _customer.DeleteCustomerByIdAsync(id);
            return Ok(result);
        }
    }
}
