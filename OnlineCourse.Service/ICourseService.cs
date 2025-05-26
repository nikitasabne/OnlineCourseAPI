using OnlineCourse.Core.Entities;
using OnlineCourse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCourse.Core.Models;
using OnlineCourse.Core.DTO;

namespace OnlineCourse.Service
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllCourseAsync(int? CategoryId = null);
        Task<CourseDetailDto> GetCourseDetailAsync(int courseId);
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public Task<List<CourseDto>> GetAllCourseAsync(int? CategoryId = null)
        {
            return courseRepository.GetAllCoursesAsync(CategoryId);
        }

        public Task<CourseDetailDto> GetCourseDetailAsync(int courseId)
        {
            return courseRepository.GetCourseDetailAsync(courseId);
        }
    }
}
