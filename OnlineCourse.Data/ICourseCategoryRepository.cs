using OnlineCourse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Data
{
    //interface ICourseCategoryRepository
    //{
    //    CourseCategory? GetById(int id);
    //    List<CourseCategory> GetAllCourses();
    //}

    public interface ICourseCategoryRepository
    {
        Task<CourseCategory> GetByIdAsync(int id);
        Task<List<CourseCategory>> GetAllCourse();
    }
}
