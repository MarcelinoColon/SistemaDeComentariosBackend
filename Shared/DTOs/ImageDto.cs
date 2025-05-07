using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shared.DTOs
{
    public class ImageDto
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        [Url]
        public string? Url { get; set; }
        [Required]
        public int UserId { get; set; }
        public List<CommentDto> Comments { get; set; } = [];
    }
}
