using OnlineCourse.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Core.DTO
{
    public class VideoRequestDto
    {
        public int VideoRequestId { get; set; }

        public int UserId { get; set; }

        public string? UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string SubTopic { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string ShortTitle { get; set; } = null!;

        [Required]
        [StringLength(4000)]
        public string RequestDescription { get; set; } = null!;

        [StringLength(4000)]
        public string? Response { get; set; }

        [StringLength(2000)]
        public string? VideoUrls { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("VideoRequests")]
        public virtual UserProfile User { get; set; } = null!;
    }
}
