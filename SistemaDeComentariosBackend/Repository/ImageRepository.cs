
using Microsoft.EntityFrameworkCore;
using SistemaDeComentariosBackend.Entitites;

namespace SistemaDeComentariosBackend.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _context;
        public ImageRepository(AppDbContext context)
        {
            _context = context;   
        }
        public async Task Add(Image image) =>
            await _context.Images.AddAsync(image);

        public async Task<IEnumerable<Image>> GetAll() =>
            await _context.Images.ToListAsync();

        public async Task<Image> GetById(int id) =>
            await _context.Images.FindAsync(id);

        public async Task Save() =>
            await _context.SaveChangesAsync();
    }
}
