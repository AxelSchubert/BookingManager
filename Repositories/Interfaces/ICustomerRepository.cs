using BookingManager.Models;

namespace BookingManager.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomerAsync();
        Task<Customer?> UpdateCustomerAsync(Customer customer);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<bool> DeleteCustomerAsync(int id);

    }
}
