using System.ComponentModel.DataAnnotations;

namespace BookingManager.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsPopular { get; set; }
    }
}
