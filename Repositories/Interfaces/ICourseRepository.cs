using BookingManager.Models;

namespace BookingManager.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course?> UpdateCourseAsync(Course course);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course?> GetCourseByIdAsync(int id);
        Task<bool> DeleteCourseAsync(int id);
    }
}
