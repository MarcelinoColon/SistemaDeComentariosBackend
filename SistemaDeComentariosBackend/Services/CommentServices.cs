using SistemaDeComentariosBackend.Entitites;
using SistemaDeComentariosBackend.Repository;

namespace SistemaDeComentariosBackend.Services
{
    public class CommentServices : ICommentServices
    {
        private readonly IImageRepository _imageRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUsersServices _userServices;
        public CommentServices(IImageRepository imageRepository,
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
