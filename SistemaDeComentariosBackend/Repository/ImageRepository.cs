
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
            await _context.Images.Include(i => i.Comments).ToListAsync();

        public async Task<Image?> GetById(int id) =>
            await _context.Images.Include(i => i.Comments).Where(x => x.Id == id).FirstOrDefaultAsync();
        public void Update(Image image)=> 
            _context.Images.Update(image);

        public async Task<bool> ExistById(int imageId)
            => await _context.Images.AnyAsync(i => i.Id == imageId);

        public async Task Save() =>
            await _context.SaveChangesAsync();
    }
}
