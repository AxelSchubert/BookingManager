using Microsoft.EntityFrameworkCore;
using BookingManager.Models;

namespace BookingManager.Data
{
    public class BookingManagerDBContext : DbContext
    {
        public BookingManagerDBContext(DbContextOptions<BookingManagerDBContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
