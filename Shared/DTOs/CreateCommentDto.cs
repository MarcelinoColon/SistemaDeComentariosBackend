using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class CreateCommentDto
    {
        [Required]
        public required string Body {  get; set; }
    }
}
