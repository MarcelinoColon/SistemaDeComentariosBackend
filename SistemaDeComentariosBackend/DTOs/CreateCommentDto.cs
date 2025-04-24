using System.ComponentModel.DataAnnotations;

namespace SistemaDeComentariosBackend.DTOs
{
    public class CreateCommentDto
    {
        [Required]
        public required string Body {  get; set; }
    }
}
