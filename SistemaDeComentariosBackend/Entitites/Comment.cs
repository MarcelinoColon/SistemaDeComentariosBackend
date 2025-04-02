using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeComentariosBackend.Entitites
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public Image? Image { get; set; }
    }
}
