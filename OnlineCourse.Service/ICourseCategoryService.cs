using OnlineCourse.Core.Entities;
using OnlineCourse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCourse.Core.Models;

namespace OnlineCourse.Service
{
    public interface ICourseCategoryService
    {
        Task<CourseCategoryDto?> GetByIdAsync(int id);
        Task<List<CourseCategoryDto>> GetAllCourseAsync();
    }

    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository coursecategoryRepository;

        public CourseCategoryService(ICourseCategoryRepository coursecategoryRepository)
        {
            this.coursecategoryRepository = coursecategoryRepository;
        }
        public async Task<List<CourseCategoryDto>> GetAllCourseAsync()
        {
            var course = await coursecategoryRepository.GetAllCourse();
            var courses = course.Select(x => new CourseCategoryDto()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
            return courses;
        }

        public async Task<CourseCategoryDto?> GetByIdAsync(int id)
        {
            var course = await coursecategoryRepository.GetByIdAsync(id);
            return course == null? null : new CourseCategoryDto() { 
                CategoryId = course.CategoryId,
                CategoryName = course.CategoryName,
                Description = course.Description
            };
        }
    }
}
