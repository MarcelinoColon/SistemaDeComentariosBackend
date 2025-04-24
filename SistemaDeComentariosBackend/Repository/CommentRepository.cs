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
            return await _context.Comments
                .Where(c => c.ImageId == imageId)
                .ToListAsync();
        }

        public async Task<Comment?> GetImageCommentById(Guid id)
            => await _context.Comments.FindAsync(id);
        

        public async Task AddComment(Comment comment)
            => await _context.Comments.AddAsync(comment);

        public void UpdateComment(Comment comment) 
            => _context.Comments.Update(comment);
        public async Task Save() =>
            await _context.SaveChangesAsync();
    }
}
