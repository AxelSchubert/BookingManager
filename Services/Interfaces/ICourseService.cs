using BookingManager.DTOs;
using BookingManager.Models;

namespace BookingManager.Services
{
    public interface ICourseService
    {
        Task<List<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> UpdateCourseAsync(CourseDTO course, int id);
        Task<CourseDTO> CreateCourseAsync(CreateCourseDTO course);
        Task<CourseDTO?> GetCourseByIdAsync(int id);
        Task<bool> DeleteCourseAsync(int id);
    }
}
