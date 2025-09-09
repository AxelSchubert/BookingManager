using System.ComponentModel.DataAnnotations;

namespace BookingManager.DTOs
{
    public class CreateTableDTO
    {
        [Required]
        public int Capacity { get; set; }
    }
}
