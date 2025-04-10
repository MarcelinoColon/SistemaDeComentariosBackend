using SistemaDeComentariosBackend.Entitites;
using SistemaDeComentariosBackend.Repository;

namespace SistemaDeComentariosBackend.Services
{
    public class ImagesServices : IImagesServices
    {
        private readonly IImageRepository _imageRepository;
        public ImagesServices(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            var images = await _imageRepository.GetAll();
            return images;
        }

        public async Task<Image> GetById(int id)
        {
            var image = await _imageRepository.GetById(id);
            return image;
        }
        public async Task Add(Image image)
        {
            await _imageRepository.Add(image);
        }
    }
}
