using System.ComponentModel.DataAnnotations;

namespace BookingManager.DTOs
{
    public class CreateCourseDTO
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsPopular { get; set; }
    }
}
