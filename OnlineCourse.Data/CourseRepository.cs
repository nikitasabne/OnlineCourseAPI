using Microsoft.EntityFrameworkCore;
using OnlineCourse.Core.DTO;
using OnlineCourse.Core.Entities;
using OnlineCourse.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly OnlineCourseDbContext onlineCourseDbContext;

        public CourseRepository(OnlineCourseDbContext onlineCourseDbContext)
        {
            this.onlineCourseDbContext = onlineCourseDbContext;
        }
        public async Task<List<CourseDto>> GetAllCoursesAsync(int? categoryId = null)
        {
            var query = onlineCourseDbContext.Courses
                .Include(x => x.Category)
                .AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }
            var courses = await query
                .Select(s => new CourseDto
                {
                    CourseId = s.CourseId,
                    Title = s.Title,
                    Description = s.Description,
                    Price = s.Price,
                    CourseType = s.CourseType,
                    SeatsAvailable = s.SeatsAvailable,
                    Duration = s.Duration,
                    CategoryId = s.CategoryId,
                    InstructorId = s.InstructorId,
                    //Thumbnail = s.Thumbnail,
                    //InstructorUserId = s.Instructor.UserId,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Category = new CourseCategoryDto
                    {
                        CategoryId = s.Category.CategoryId,
                        CategoryName = s.Category.CategoryName,
                        Description = s.Category.Description
                    },
                    UserRating = new UserRatingDto
                    {
                        CourseId = s.CourseId,
                        AverageRating = s.Reviews.Any() ? Convert.ToDecimal(s.Reviews.Average(r => r.Rating)) : 0,
                        TotalRating = s.Reviews.Count
                    }
                })
                .ToListAsync();

            return courses;
        }

        public async Task<CourseDetailDto> GetCourseDetailAsync(int courseId)
        {
            var course = await onlineCourseDbContext.Courses
                .Include(x => x.Category)
                .Include(x => x.Reviews)
                .Include(x => x.SessionDetails)
                .Where(x => x.CourseId == courseId)
                .Select(x => new CourseDetailDto()
                {
                    CourseId = x.CourseId,
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    CourseType = x.CourseType,
                    SeatsAvailable = x.SeatsAvailable,
                    Duration = x.Duration,
                    CategoryId = x.CategoryId,
                    InstructorId = x.InstructorId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Category = new CourseCategoryDto()
                    {
                        CategoryId = x.Category.CategoryId,
                        CategoryName = x.Category.CategoryName,
                        Description = x.Category.Description
                    },
                    Reviews = x.Reviews.Select(r => new UserReviewDto
                    {
                        CourseId = r.CourseId,
                        ReviewId = r.ReviewId,
                        UserId = r.UserId,
                        UserName = r.User.DisplayName,
                        Rating = r.Rating,
                        Comments = r.Comments,
                        ReviewDate = r.ReviewDate
                    }).OrderByDescending(x => x.Rating).Take(10).ToList(),
                    SessionDetails = x.SessionDetails.Select(sd => new SessionDetailDto
                    {
                        SessionId = sd.SessionId,
                        CourseId = sd.CourseId,
                        Title = sd.Title,
                        Description = sd.Description,
                        VideoUrl = sd.VideoUrl,
                        VideoOrder = sd.VideoOrder
                    }).OrderBy(o => o.VideoOrder).ToList()
                    ,
                    UserRating = new UserRatingDto
                    {
                        CourseId = x.CourseId,
                        AverageRating = x.Reviews.Any() ? Convert.ToDecimal(x.Reviews.Average(r => r.Rating)) : 0,
                        TotalRating = x.Reviews.Count
                    }
                }).FirstOrDefaultAsync();
            return course;
        }
    }
}
