using System.ComponentModel.DataAnnotations;

namespace BookingManager.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
