using BookingManager.Models;
using System.ComponentModel.DataAnnotations;

namespace BookingManager.DTOs
{
    public class CustomerDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
