
using ApplicationLayer.DTOs;
using DomainLayer.Entities;

namespace ApplicationLayer.Service
{
    public interface ICustomerService
    {
        Task<ServiceResponse> AddCustomerAsync(Customer customer);
        Task<ServiceResponse> UpdateCustomerAsync(Customer customer);
        Task<ServiceResponse> DeleteCustomerByIdAsync(int Id);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomersByIdAsync(int Id);

    }
}
