using BookingManager.DTOs;
using BookingManager.Models;
using BookingManager.Repositories;

namespace BookingManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<CustomerDTO> CreateCustomerAsync(CreateCustomerDTO customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
                Email = customer.Email
            };
            var createdCustomer = await _repository.CreateCustomerAsync(newCustomer);
            return new CustomerDTO
            {
                Id = createdCustomer.Id,
                Name = createdCustomer.Name,
                Email = createdCustomer.Email
            };
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await _repository.DeleteCustomerAsync(id);
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _repository.GetAllCustomerAsync();

            return customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email
            }).ToList();
        }

        public async Task<CustomerDTO?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetCustomerByIdAsync(id);
            if (customer == null) { return null; }
            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };
        }

        public async Task<CustomerDTO?> UpdateCustomerAsync(CustomerDTO customer, int id)
        {
            var currentCustomer = await _repository.GetCustomerByIdAsync(id);
            if (currentCustomer == null) { return null; }

            if (customer.Name != null) { currentCustomer.Name = customer.Name; }
            if (customer.Email != null) { currentCustomer.Email = customer.Email; }

            var updatedCustomer = await _repository.UpdateCustomerAsync(currentCustomer);

            return new CustomerDTO
            {
                Id = updatedCustomer.Id,
                Name = updatedCustomer.Name,
                Email = updatedCustomer.Email
            };
        }
    }
}
