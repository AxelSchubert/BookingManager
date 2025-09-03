using System.ComponentModel.DataAnnotations;

namespace BookingManager.Models
{
    public class Admin
    {
        [Key]
        public int MyProperty { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
