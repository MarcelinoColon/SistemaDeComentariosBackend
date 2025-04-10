using SistemaDeComentariosBackend.Entitites;

namespace SistemaDeComentariosBackend.Services
{
    public interface IImagesServices
    {
        Task Add(Image image);
        Task<IEnumerable<Image>> GetAll();
        Task<Image> GetById(int id);
    }
}
