using BookingManager.DTOs;
using BookingManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ITableService _tableService;
        public BookingController(IBookingService bookingService, ITableService tableService)
        {
            _bookingService = bookingService;
            _tableService = tableService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<BookingDTO>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }
        [HttpGet("{id}")]
            //[Authorize]
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

            if (booking.NumberOfGuests <= 0)
            {
                return BadRequest("Number of guests must be greater than zero.");
            }

            if (booking.End == null)
            {
                booking.End = booking.Start.AddHours(2);
            }

            if (booking.Start < DateTime.Now)
            {
                return BadRequest("Booking start time cannot be in the past.");
            }

            if (booking.End <= booking.Start)
            {
                return BadRequest("Booking end time must be after start time.");
            }

            var requestedTable = await _tableService.GetTableByIdAsync(booking.TableId);

            if (requestedTable == null)
            {
                return NotFound("Requested table does not exist.");
            }

            var availableTables = await _tableService.GetAvailableTablesAsync(booking.Start, booking.NumberOfGuests);

            if (!availableTables.Any(t => t.Id == booking.TableId))
            { 
                return Conflict("Requested table unavailable at the specified time.");
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
        //[Authorize]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);
            if (!result) { return NotFound(); }
            return NoContent();
        }
    }
}
