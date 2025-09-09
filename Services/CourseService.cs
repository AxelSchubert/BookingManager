
using BookingManager.DTOs;
using BookingManager.Models;
using BookingManager.Repositories.Interfaces;

namespace BookingManager.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }
        public async Task<CourseDTO> CreateCourseAsync(CreateCourseDTO course)
        {
            var newCourse = new Course
            {
                CourseName = course.CourseName,
                Price = course.Price,
                Description = course.Description,
                IsPopular = course.IsPopular
            };

            await _repository.CreateCourseAsync(newCourse);

            return new CourseDTO
            {
                Id = newCourse.Id,
                CourseName = newCourse.CourseName,
                Price = newCourse.Price,
                Description = newCourse.Description,
                IsPopular = newCourse.IsPopular
            };
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            return await _repository.DeleteCourseAsync(id);
        }

        public async Task<List<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _repository.GetAllCoursesAsync();

            return courses.Select(c => new CourseDTO
            {
                Id = c.Id,
                CourseName = c.CourseName,
                Price = c.Price,
                Description = c.Description,
                IsPopular = c.IsPopular
            }).ToList();
        }

        public async Task<CourseDTO?> GetCourseByIdAsync(int id)
        {
            var course = await _repository.GetCourseByIdAsync(id);
            if (course == null) { return null; }

            return new CourseDTO
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Price = course.Price,
                Description = course.Description,
                IsPopular = course.IsPopular
            };
        }

        public async Task<CourseDTO?> UpdateCourseAsync(CourseDTO course, int id)
        {
            var currentCourse = await _repository.GetCourseByIdAsync(id);
            if (currentCourse == null) { return null; }

            if (course.CourseName != null) { currentCourse.CourseName = course.CourseName; }
            if (course.Price != null) { currentCourse.Price = course.Price.Value; }
            if (course.Description != null) { currentCourse.Description = course.Description; }
            if (course.IsPopular != null) { currentCourse.IsPopular = course.IsPopular.Value; }

            var updatedCourse = await _repository.UpdateCourseAsync(currentCourse);

            return new CourseDTO
            {
                Id = updatedCourse.Id,
                CourseName = updatedCourse.CourseName,
                Price = updatedCourse.Price,
                Description = updatedCourse.Description,
                IsPopular = updatedCourse.IsPopular
            };
        }
    }
}
