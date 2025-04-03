using SistemaDeComentariosBackend.Entitites;

namespace SistemaDeComentariosBackend.Repository
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetImageComments(int imageId);
    }
}
