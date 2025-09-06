using BookingManager.Models;

namespace BookingManager.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking?> UpdateBookingAsync(Booking booking); 
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<Booking?> GetBookingByIdAsync(int id);
        Task<bool> DeleteBookingAsync(int id);
    }
}
