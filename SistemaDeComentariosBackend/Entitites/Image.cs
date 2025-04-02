using System.ComponentModel.DataAnnotations;

namespace SistemaDeComentariosBackend.Entitites
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Url { get; set; }
        [Required]
        public int UserId { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
