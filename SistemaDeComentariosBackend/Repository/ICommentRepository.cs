using SistemaDeComentariosBackend.Entitites;

namespace SistemaDeComentariosBackend.Repository
{
    public interface ICommentRepository
    {
        Task AddComment(Comment comment);
        Task<Comment?> GetImageCommentById(Guid id);
        Task<IEnumerable<Comment>> GetImageComments(int imageId);
        Task Save();
        void UpdateComment(Comment comment);
    }
}
