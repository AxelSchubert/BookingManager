using BookingManager.DTOs;

using BookingManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) { return NotFound(); }
            return Ok(course);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CourseDTO>> CreateCourse([FromBody] CreateCourseDTO course)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var createdCourse = await _courseService.CreateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.Id }, createdCourse);
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<CourseDTO>> UpdateCourse(int id, [FromBody] CourseDTO course)
        {
            if (course == null) { return BadRequest(); }
            var updatedCourse = await _courseService.UpdateCourseAsync(course, id);
            if (updatedCourse == null) { return NotFound(); }
            return Ok(updatedCourse);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourseAsync(id);
            if (!result) { return NotFound(); }
            return NoContent();
        }
    }
}
