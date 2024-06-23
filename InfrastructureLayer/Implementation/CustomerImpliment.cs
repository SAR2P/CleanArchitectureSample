using ApplicationLayer.Contract;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Implementation
{
    public class CustomerImpliment : ICustomer
    {
        private readonly AppDbContext _context;
        public CustomerImpliment(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public async Task<ServiceResponse> AddCustomerAsync(Customer customer)
        {
             await _context.Customers.AddAsync(customer);
            await SaveChangesAsync();

            return new ServiceResponse(true, "Customer created");
        }

        public async Task<ServiceResponse> DeleteCustomerByIdAsync(int Id)
        {
            var employee = await _context.Customers.FindAsync(Id);//find by primaryKey
            if (employee == null)
                return new ServiceResponse(false, "customer not found");

             _context.Customers.Remove(employee);
            await SaveChangesAsync();

            return new ServiceResponse(true, "Customer deleted");

        }

        public async Task<List<Customer>> GetAllCustomersAsync()
            => await _context.Customers.AsNoTracking().ToListAsync();

        public async Task<Customer> GetCustomersByIdAsync(int Id)
        {
            return await _context.Customers.FindAsync(Id);
        }
            

        public async Task<ServiceResponse> UpdateCustomerAsync(Customer customer)
        {
            _context.Update(customer);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }

        //private mehtod

        private async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
