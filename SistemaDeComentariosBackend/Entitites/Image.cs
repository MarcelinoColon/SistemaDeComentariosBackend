using System.ComponentModel.DataAnnotations;

namespace SistemaDeComentariosBackend.Entitites
{
    public class Image
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public int UserId { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
