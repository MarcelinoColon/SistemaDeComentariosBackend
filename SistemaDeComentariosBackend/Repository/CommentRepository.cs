using Microsoft.EntityFrameworkCore;
using SistemaDeComentariosBackend.Entitites;

namespace SistemaDeComentariosBackend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetImageComments(int imageId)
        {
            return await _context.Comments.Select(comment =>
            new Comment
            {
                Body = comment.Body,
                Date = comment.Date,
                Id = comment.Id,
                ImageId = comment.ImageId,
                UserId = comment.UserId
            }).Where(c => c.ImageId == imageId).ToListAsync();
        }

        public async Task AddComment(Comment comment)
            => await _context.Comments.AddAsync(comment);

    }
}
