using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Data
{
    //public class CourseCategoryRepository : ICourseCategoryRepository
    //{
    //    private readonly OnlineCourseDbContext onlineCourseDbContext;

    //    public CourseCategoryRepository(OnlineCourseDbContext onlineCourseDbContext)
    //    {
    //        this.onlineCourseDbContext = onlineCourseDbContext;
    //    }
    //    public List<CourseCategory> GetAllCourses()
    //    {
    //        return onlineCourseDbContext.CourseCategories.ToList();
    //    }

    //    public CourseCategory? GetById(int id)
    //    {
    //        var course = onlineCourseDbContext.CourseCategories.Find(id);
    //        return course;
    //    }
    //}

    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly OnlineCourseDbContext onlineCourseDbContext;

        public CourseCategoryRepository(OnlineCourseDbContext onlineCourseDbContext)
        {
            this.onlineCourseDbContext = onlineCourseDbContext;
        }
        public Task<List<CourseCategory>> GetAllCourse()
        {
            return onlineCourseDbContext.CourseCategories.ToListAsync();
        }

        public Task<CourseCategory> GetByIdAsync(int id)
        {
            var course = onlineCourseDbContext.CourseCategories.FindAsync(id).AsTask();
            return course;
        }
    }
}
