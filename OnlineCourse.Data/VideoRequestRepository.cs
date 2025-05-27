//using Microsoft.EntityFrameworkCore;
//using OnlineCourse.Core.Entities;

//namespace OnlineCourse.Data
//{
//    public class VideoRequestRepository : IVideoRequestRepository
//    {
//        private readonly OnlineCourseDbContext onlineCourseDbContext;

//        public VideoRequestRepository(OnlineCourseDbContext onlineCourseDbContext)
//        {
//            this.onlineCourseDbContext = onlineCourseDbContext;
//        }
//        public async Task<VideoRequest> AddAsync(VideoRequest videoRequest)
//        {
//            onlineCourseDbContext.VideoRequests.Add(videoRequest);
//            await onlineCourseDbContext.SaveChangesAsync();
//            return videoRequest;
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var videoRequest = await GetVideoByIdAsync(id);
//            if (videoRequest != null)
//            {
//                onlineCourseDbContext.VideoRequests.Remove(videoRequest);
//                await onlineCourseDbContext.SaveChangesAsync();
//            }
//        }

//        public async Task<IEnumerable<VideoRequest>> GetAllAsync()
//        {
//            return await onlineCourseDbContext.VideoRequests.Include(x => x.User).ToListAsync();
//        }

//        public Task<VideoRequest?> GetVideoByIdAsync(int id)
//        {
//            return onlineCourseDbContext.VideoRequests.Include(x => x.User)
//                .FirstOrDefaultAsync(y => y.VideoRequestId == id);
//        }

//        public async Task<IEnumerable<VideoRequest>> GetVideoByUserIdAsync(int userId)
//        {
//            return await onlineCourseDbContext.VideoRequests.Include(x => x.User).Where(y => y.UserId == userId).ToListAsync();
//        }

//        public async Task<VideoRequest> UpdateAsync(VideoRequest videoRequest)
//        {
//            onlineCourseDbContext.VideoRequests.Update(videoRequest);
//            await onlineCourseDbContext.SaveChangesAsync();
//            return videoRequest;
//        }
//    }
//}
