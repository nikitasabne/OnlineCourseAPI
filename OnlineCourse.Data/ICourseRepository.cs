using OnlineCourse.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Data
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>> GetAllCoursesAsync(int? categoryId = null);
        Task<CourseDetailDto> GetCourseDetailAsync(int courseId);

    }
}
