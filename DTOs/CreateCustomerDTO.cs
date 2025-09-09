using System.ComponentModel.DataAnnotations;

namespace BookingManager.DTOs
{
    public class CreateCustomerDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
