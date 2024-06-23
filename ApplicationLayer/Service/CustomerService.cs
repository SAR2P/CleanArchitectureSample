

using ApplicationLayer.Contract;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System.Net.Http.Json;

namespace ApplicationLayer.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;//go to minute 40 and see what is this for

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddCustomerAsync(Customer customer)
        {
            var data = await _httpClient.PostAsJsonAsync("api/Customer", customer);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response;
        }

        public async Task<ServiceResponse> DeleteCustomerByIdAsync(int Id)
        {
            var data = await _httpClient.DeleteAsync($"api/Customer/{Id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return (await _httpClient.GetFromJsonAsync<List<Customer>>("api/Customer"));
        }

        public async Task<Customer> GetCustomersByIdAsync(int Id)
        {
            return (await _httpClient.GetFromJsonAsync<Customer>($"api/Customer/{Id}"));
        }

        public async Task<ServiceResponse> UpdateCustomerAsync(Customer customer)
        {
            var data = await _httpClient.PutAsJsonAsync("api/Customer", customer);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response;
        }
    }
}
