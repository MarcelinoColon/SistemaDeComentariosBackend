using SistemaDeComentariosBackend.Entitites;
using SistemaDeComentariosBackend.Repository;

namespace SistemaDeComentariosBackend.Services
{
    public class CommentsServices : ICommentsServices
    {
        private readonly IImageRepository _imageRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUsersServices _userServices;
        public CommentsServices(IImageRepository imageRepository,
                               ICommentRepository commentRepository,
                               IUsersServices usersServices)
        {
            _imageRepository = imageRepository;
            _commentRepository = commentRepository;
            _userServices = usersServices;
        }
        public async Task AddComment(int imageId, Comment comment)
        {
            
        }
    }
}
