using BookingManager.DTOs;
using BookingManager.Models;

namespace BookingManager.Services
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAllBookingsAsync();
        Task<BookingDTO?> UpdateBookingAsync(BookingDTO booking, int id);
        Task<BookingDTO> CreateBookingAsync(CreateBookingDTO booking);
        Task<BookingDTO?> GetBookingByIdAsync(int id);
        Task<bool> DeleteBookingAsync(int id);
    }
}
