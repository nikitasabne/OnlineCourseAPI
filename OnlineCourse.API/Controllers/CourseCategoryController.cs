using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Core.Models;
using OnlineCourse.Service;

namespace OnlineCourse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryService courseCategoryService;

        public CourseCategoryController(ICourseCategoryService courseCategoryService)
        {
            this.courseCategoryService = courseCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await courseCategoryService.GetAllCourseAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var category = await courseCategoryService.GetByIdAsync(id);
            return Ok(category);
        }
    }
}
