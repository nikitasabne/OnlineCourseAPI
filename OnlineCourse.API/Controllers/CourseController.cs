using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Core.DTO;
using OnlineCourse.Service;

namespace OnlineCourse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetAllCourseAsync()
        {
            var course = await courseService.GetAllCourseAsync();
            return Ok(course);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<List<CourseDto>>> GetAllCourseByCategoryIdAsync([FromRoute] int categoryId)
        {
            var course = await courseService.GetAllCourseAsync(categoryId);
            return Ok(course);
        }

        [HttpGet("Detail/{courseid}")]
        public async Task<ActionResult<CourseDetailDto>> GetAllCourseDetailByCourseIdAsync([FromRoute] int courseId)
        {
            var courseDetail = await courseService.GetCourseDetailAsync(courseId);
            return Ok(courseDetail);
        }
    }
}
