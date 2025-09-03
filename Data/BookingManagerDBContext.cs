using Microsoft.EntityFrameworkCore;
using BookingManager.Models;

namespace BookingManager.Data
{
    public class BookingManagerDBContext : DbContext
    {
        public BookingManagerDBContext(DbContextOptions<BookingManagerDBContext> options) : base(options)
        { }
        DbSet<Customer> customers;
        DbSet<Table> tables;
        DbSet<Booking> bookings;
        DbSet<Course> courses;
        DbSet<Admin> admins;
    }
}
