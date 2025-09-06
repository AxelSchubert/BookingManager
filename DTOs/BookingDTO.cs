using BookingManager.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingManager.DTOs
{
    public class BookingDTO
    {   
        public int? Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? NumberOfGuests { get; set; }
        public int? CustomerId { get; set; }
        public int? TableId { get; set; }
    }
}
