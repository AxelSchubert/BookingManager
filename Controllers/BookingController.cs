using BookingManager.DTOs;
using BookingManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingDTO>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null) { return NotFound(); }
            return Ok(booking);
        }
        [HttpPost]
        public async Task<ActionResult<BookingDTO>> CreateBooking([FromBody] CreateBookingDTO booking)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            
            if (booking.End == null)
            {
                booking.End = booking.Start.AddHours(2);
            }

            var createdBooking = await _bookingService.CreateBookingAsync(booking);
            return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Id }, createdBooking);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BookingDTO>> UpdateBooking(int id, [FromBody] BookingDTO booking)
        {
            if (booking == null) { return BadRequest(); }
            var updatedBooking = await _bookingService.UpdateBookingAsync(booking, id);
            if (updatedBooking == null) { return NotFound(); }
            return Ok(updatedBooking);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);
            if (!result) { return NotFound(); }
            return NoContent();
        }
    }
}
