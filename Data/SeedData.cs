using BookingManager.Data;
using BookingManager.Models;
using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(BookingManagerDBContext context)
    {
        // Apply migrations automatically (optional)
        context.Database.Migrate();

        // Check if any courses exist
        if (context.Bookings.Any())
        {
            return; // DB has been seeded
        }

        // Add initial courses
        context.Courses.AddRange(
            new Course
            {
                CourseName = "Pad Thai",
                Price = 120,
                Description = "Stekta risnudlar med räkor, tofu och jordnötter",
                IsPopular = true
            },
            new Course
            {
                CourseName = "Grön Curry",
                Price = 130,
                Description = "Stark grön curry med kyckling och kokosmjölk",
                IsPopular = true
            },
            new Course
            {
                CourseName = "Tom Yum Soppa",
                Price = 120,
                Description = "Het och sur soppa med räkor och citrongräs",
                IsPopular = false
            },
            new Course
            {
                CourseName = "Stekt Ris",
                Price = 110,
                Description = "Stekt ris med kyckling, biff, räkor eller tofu",
                IsPopular = true
            }
        );
        
        context.SaveChanges();


        context.Tables.AddRange(
            new Table { Capacity = 2 },
            new Table { Capacity = 4 },
            new Table { Capacity = 4 },
            new Table { Capacity = 6 },
            new Table { Capacity = 8 }
        );

        context.SaveChanges();

        context.Customers.AddRange(
           new Customer
           {
               Name = "John Doe",
               Email = "john.doe@example.com"
           },
           new Customer
           {
               Name = "Jane Smith",
               Email = "jane.smith@example.com"
           },
           new Customer
           {
               Name = "Alice Johnson",
               Email = "alice.johnson@example.com"
           }
           );

        context.SaveChanges();


        context.Bookings.AddRange(
           new Booking
           {
               Start = DateTime.Now.AddDays(1).AddHours(18),
               End = DateTime.Now.AddDays(1).AddHours(20),
               NumberOfGuests = 2,
               CustomerId = context.Customers.First(c => c.Name == "John Doe").Id,
               TableId = context.Tables.First(t => t.Capacity == 2).Id
           },
           new Booking
           {
               Start = DateTime.Now.AddDays(2).AddHours(19),
               End = DateTime.Now.AddDays(2).AddHours(21),
               NumberOfGuests = 4,
               CustomerId = context.Customers.First(c => c.Name == "Jane Smith").Id,
               TableId = context.Tables.First(t => t.Capacity == 4).Id
           },
           new Booking
           {
               Start = DateTime.Now.AddDays(3).AddHours(17),
               End = DateTime.Now.AddDays(3).AddHours(19),
               NumberOfGuests = 6,
               CustomerId = context.Customers.First(c => c.Name == "Alice Johnson").Id,
               TableId = context.Tables.First(t => t.Capacity == 6).Id
           }
       );

       context.SaveChanges();
    }
}

