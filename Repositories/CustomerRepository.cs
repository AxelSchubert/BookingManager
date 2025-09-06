using BookingManager.Data;
using BookingManager.Models;
using BookingManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingManager.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookingManagerDBContext _context;
        public CustomerRepository(BookingManagerDBContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) { return false; }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer?> UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
