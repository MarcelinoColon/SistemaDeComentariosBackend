using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeComentariosBackend.Entitites
{
    public class Comment
    {
        public Guid Id { get; set; }
        [Required]
        public required string Body { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public Image? Image { get; set; }
    }
}
