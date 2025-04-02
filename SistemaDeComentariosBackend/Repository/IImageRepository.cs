using SistemaDeComentariosBackend.Entitites;

namespace SistemaDeComentariosBackend.Repository
{
    public interface IImageRepository
    {
        public Task<IEnumerable<Image>> GetAll();
        public Task<Image> GetById(int id);
        public Task Add(Image image);
        public Task Save();
    }
}
