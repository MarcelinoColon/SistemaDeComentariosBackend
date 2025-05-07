using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class ImageInsertDto
    {
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        [Url]
        public string? Url { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
