using BookingManager.DTOs;
using BookingManager.Models;

namespace BookingManager.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO?> UpdateCustomerAsync(CustomerDTO customer, int id);
        Task<CustomerDTO> CreateCustomerAsync(CreateCustomerDTO customer);
        Task<CustomerDTO?> GetCustomerByIdAsync(int id);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
