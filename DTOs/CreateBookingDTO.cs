using System.ComponentModel.DataAnnotations;

namespace BookingManager.DTOs
{
    public class CreateBookingDTO
    {
        [Required]
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int TableId { get; set; }
    }
}
