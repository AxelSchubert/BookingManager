using BookingManager.Data;
using BookingManager.Models;
using BookingManager.Models;
using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(BookingManagerDBContext context)
    {
        // Apply migrations automatically (optional)
        context.Database.Migrate();

        // Check if any courses exist
        if (context.Courses.Any())
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
    }
}
