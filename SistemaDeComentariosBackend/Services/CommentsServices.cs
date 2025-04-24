using Microsoft.AspNetCore.Http.HttpResults;
using SistemaDeComentariosBackend.DTOs;
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
        public async Task<IEnumerable<CommentDto>> GetImageComments(int imageId)
        {
            var image = await _imageRepository.GetById(imageId);

            if (image is null)
            {
                return null;
            }

            var comments = await _commentRepository.GetImageComments(imageId);

            var commentsDto = new List<CommentDto>();

            foreach(var comment in comments)
            {
                commentsDto.Add(new CommentDto
                {
                    Body = comment.Body,
                    Id = comment.Id,
                    Date = comment.Date
                });
            }

            return commentsDto;
        }

        public async Task<CommentDto> GetImageCommentById(int imageId, Guid id)
        {
            var image = _imageRepository.GetById(imageId);

            if(image is null)
            {
                return null;
            }

            var comment = await _commentRepository.GetImageCommentById(id);

            if (comment is null)
            {
                return null;
            }

            var commentDto = new CommentDto
            {
                Id = comment.Id,
                Body = comment.Body,
                Date = comment.Date
            };

            return commentDto;
        }

        public async Task<CommentDto> AddComment(int imageId, CreateCommentDto createCommentDto)
        {
            var usuarioId = _userServices.GetUserId();

            var image = await _imageRepository.GetById(imageId);

            if (image is null)
            {
                return null;
            }

            if (createCommentDto is null)
            {
                return null;
            }

            var comment = new Comment
            {
                Body = createCommentDto.Body,
                Date = DateTime.UtcNow,
                ImageId = imageId,
                UserId = usuarioId
            };

            await _commentRepository.AddComment(comment);
            await _commentRepository.Save();

            var commentDto = new CommentDto
            {
                Id = comment.Id,
                Body = comment.Body,
                Date = DateTime.UtcNow
            };


            return commentDto;
  
        }
    }
}
