//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using OnlineCourse.Core.DTO;
//using OnlineCourse.Service;

//namespace OnlineCourse.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class VideoRequestController : Controller
//    {
//        public VideoRequestController(IVideoRequestService videoRequestService)
//        {
//            VideoRequestService = videoRequestService;
//        }

//        public IVideoRequestService VideoRequestService { get; }

//        public async Task<ActionResult<IEnumerable<VideoRequestDto>>> GetAllVideo()
//        {
//            List<VideoRequestDto> videoRequests;
//            videoRequests = await VideoRequestService.GetAllAsync();
//            return Ok(videoRequests);
//        }
//    }
//}
