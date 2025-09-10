using BookingManager.Data;
using BookingManager.Models;
using Microsoft.EntityFrameworkCore;


namespace BookingManager.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingManagerDBContext _context;
        public BookingRepository(BookingManagerDBContext context)
        {
            _context = context; 
        }
        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return bookings;
        }
        public async Task<Booking?> UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            return booking;
        }
        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) { return false; }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

