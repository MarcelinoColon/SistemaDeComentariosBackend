using SistemaDeComentariosBackend.Entitites;
using Shared.DTOs;

namespace SistemaDeComentariosBackend.Services
{
    public interface IImagesServices
    {
        Task<ImageDto?> Add(ImageInsertDto imageInsertDto);
        Task<IEnumerable<ImageDto>?> GetAll();
        Task<ImageDto?> GetById(int id);
    }
}
