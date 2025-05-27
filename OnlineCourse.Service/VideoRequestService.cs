//using AutoMapper;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using OnlineCourse.Core.DTO;
//using OnlineCourse.Core.Entities;
//using OnlineCourse.Data;

//namespace OnlineCourse.Service
//{
//    public class VideoRequestService : IVideoRequestService
//    {
//        private readonly IVideoRequestRepository _videoRequestRepository;
//        private readonly IMapper mapper;
//        private readonly IConfiguration configuration;
//        private readonly ILogger<VideoRequestService> logger;

//        public VideoRequestService(IVideoRequestRepository videoRequestRepository, IMapper mapper,
//            IConfiguration configuration, ILogger<VideoRequestService> logger)
//        {
//            this._videoRequestRepository = videoRequestRepository;
//            this.mapper = mapper;
//            this.configuration = configuration;
//            this.logger = logger;
//        }

//        public async Task<VideoRequestDto> AddAsync(VideoRequestDto videoRequestDto)
//        {
//            var videoRequest = mapper.Map<VideoRequest>(videoRequestDto);
//            var createdVideorequest = await _videoRequestRepository.AddAsync(videoRequest);
//            return mapper.Map<VideoRequestDto>(createdVideorequest);
//        }

//        public Task DeleteAsync(int id)
//        {
//            return _videoRequestRepository.DeleteAsync(id);
//        }

//        public async Task<List<VideoRequestDto>> GetAllAsync()
//        {
//            var videoRequest = await _videoRequestRepository.GetAllAsync();
//            return mapper.Map<List<VideoRequestDto>>(videoRequest);
//        }

//        public async Task<VideoRequestDto?> GetVideoByIdAsync(int id)
//        {
//            var videoRequest = await _videoRequestRepository.GetVideoByIdAsync(id);
//            return videoRequest == null ? null : mapper.Map<VideoRequestDto>(videoRequest);
//        }

//        public async Task<IEnumerable<VideoRequestDto>> GetVideoByUserIdAsync(int userId)
//        {
//            var videoRequest = await _videoRequestRepository.GetVideoByUserIdAsync(userId);
//            return mapper.Map<IEnumerable<VideoRequestDto>>(videoRequest);
//        }

//        public async Task<VideoRequestDto> UpdateAsync(int id, VideoRequestDto videoRequestDto)
//        {
//            var existingVideoRequest = await _videoRequestRepository.GetVideoByIdAsync(id);
//            if (existingVideoRequest == null)
//            {
//                throw new KeyNotFoundException($"{id} Not Found");
//            }
//            videoRequestDto.UserId = existingVideoRequest.UserId;
//            mapper.Map(videoRequestDto, existingVideoRequest);
//            var updatedVideoRequest = await _videoRequestRepository.UpdateAsync(existingVideoRequest);
//            return mapper.Map<VideoRequestDto>(updatedVideoRequest);
//        }
//    }
//}
