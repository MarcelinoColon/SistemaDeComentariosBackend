using System.ComponentModel.DataAnnotations;

namespace SistemaDeComentariosBackend.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        [Required]
        public required string? Body { get; set; }
        [Required]
        public DateTime Date { get; set; }

    }
}
