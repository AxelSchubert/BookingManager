using BookingManager.DTOs;
using BookingManager.Models;
using BookingManager.Repositories;
using BookingManager.Repositories.Interfaces;
namespace BookingManager.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService (IBookingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<BookingDTO>> GetAllBookingsAsync()
        {
            var bookings = await _repository.GetAllBookingsAsync();

            return bookings.Select(b => new BookingDTO
            {
                Id = b.Id,
                Start = b.Start,
                End = b.End,
                NumberOfGuests = b.NumberOfGuests,
                CustomerId = b.CustomerId,
                TableId = b.TableId
            }).ToList();
        }
        public async Task<BookingDTO?> UpdateBooking(BookingDTO booking, int id)
        {
            var currentBooking = await _repository.GetBookingByIdAsync(id);

            if (currentBooking == null) { return null; }
            
            if (booking.Start != null) { currentBooking.Start = booking.Start.Value; }
            if (booking.End != null) { currentBooking.End = booking.End.Value; }
            if (booking.NumberOfGuests != null) { currentBooking.NumberOfGuests = booking.NumberOfGuests.Value; }
            if (booking.CustomerId != null) { currentBooking.CustomerId = booking.CustomerId.Value; }
            if (booking.TableId != null) { currentBooking.TableId = booking.TableId.Value; }

            var updatedBooking = await _repository.UpdateBookingAsync(currentBooking);

            return new BookingDTO
            {
                Id = updatedBooking.Id,
                Start = updatedBooking.Start,
                End = updatedBooking.End,
                NumberOfGuests = updatedBooking.NumberOfGuests,
                CustomerId = updatedBooking.CustomerId,
                TableId = updatedBooking.TableId
            };
        }
        public async Task<BookingDTO> CreateBookingAsync(CreateBookingDTO booking)
        {
            var newBooking = new Booking
            {
                Start = booking.Start,
                End = booking.End.Value,
                NumberOfGuests = booking.NumberOfGuests,
                CustomerId = booking.CustomerId,
                TableId = booking.TableId
            };
            var createdBooking = await _repository.CreateBookingAsync(newBooking);
            return new BookingDTO
            {
                Id = createdBooking.Id,
                Start = createdBooking.Start,
                End = createdBooking.End,
                NumberOfGuests = createdBooking.NumberOfGuests,
                CustomerId = createdBooking.CustomerId,
                TableId = createdBooking.TableId
            };
        }   
        public async Task<BookingDTO?> GetBookingByIdAsync(int id)
        {
            var booking = await _repository.GetBookingByIdAsync(id);
            if (booking == null) { return null; }
            return new BookingDTO
            {
                Id = booking.Id,
                Start = booking.Start,
                End = booking.End,
                NumberOfGuests = booking.NumberOfGuests,
                CustomerId = booking.CustomerId,
                TableId = booking.TableId
            };
        }
        public async Task<bool> DeleteBookingAsync(int id)
        {
            return await _repository.DeleteBookingAsync(id);
        }
    }
}
