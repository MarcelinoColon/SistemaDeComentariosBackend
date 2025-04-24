

using SistemaDeComentariosBackend.DTOs;

namespace SistemaDeComentariosBackend.Services
{
    public interface ICommentsServices
    {
        Task<CommentDto> AddComment(int imageId, CreateCommentDto createCommentDto);
        Task<CommentDto> GetImageCommentById(int imageId, Guid id);
        Task<IEnumerable<CommentDto>> GetImageComments(int imageId);
    }
}
