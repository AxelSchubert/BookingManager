using BookingManager.Data;
using BookingManager.Models;
using BookingManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingManager.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly BookingManagerDBContext _context;
        public CourseRepository(BookingManagerDBContext context)
        {
            _context = context;
        }
        public async Task<Course> CreateCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var table = await _context.Courses.FindAsync(id);
            if (table == null) { return false; }

            _context.Courses.Remove(table);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course?> UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
