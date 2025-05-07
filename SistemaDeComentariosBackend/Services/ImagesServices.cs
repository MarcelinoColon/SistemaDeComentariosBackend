using SistemaDeComentariosBackend.Entitites;
using SistemaDeComentariosBackend.Repository;
using Shared.DTOs;

namespace SistemaDeComentariosBackend.Services
{
    public class ImagesServices : IImagesServices
    {
        private readonly IImageRepository _imageRepository;
        public ImagesServices(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<ImageDto>?> GetAll()
        {
            var images = await _imageRepository.GetAll();

            if (images is null)
            {
                return null;
            }

            var imagesDto = images.Select(i => new ImageDto
            {
                Id = i.Id,
                Url = i.Url,
                Description = i.Description,
                Title = i.Title,
                UserId = i.UserId,
                Comments = i.Comments.Select(c => new CommentDto
                {
                    Id = c.Id,
                    Body = c.Body,
                    Date = c.Date
                }).ToList()
            });

            return imagesDto;
        }

        public async Task<ImageDto?> GetById(int id)
        {
            var image = await _imageRepository.GetById(id);

            if (image is null)
            {
                return null;
            }

            var imageDto = new ImageDto
            {
                Id = image.Id,
                Url = image.Url,
                Description = image.Description,
                Title = image.Title,
                UserId = image.UserId,
                Comments = image.Comments.Select(c => new CommentDto
                {
                    Id = c.Id,
                    Body = c.Body,
                    Date = c.Date
                }).ToList()
            };

            return imageDto;
        }
        public async Task<ImageDto?> Add(ImageInsertDto imageInsertDto)
        {
            if (imageInsertDto is null)
            {
                return null;
            }

            var image = new Image
            {
                Url = imageInsertDto.Url,
                Description = imageInsertDto.Description,
                Title = imageInsertDto.Title,
                UserId = imageInsertDto.UserId
            };

            await _imageRepository.Add(image);
            await _imageRepository.Save();

            var imageDto = new ImageDto
            {
                Id = image.Id,
                Url = image.Url,
                Description = image.Description,
                Title = image.Title,
                UserId = image.UserId,
                Comments = image.Comments.Select(c => new CommentDto
                {
                    Id = c.Id,
                    Body = c.Body,
                    Date = c.Date
                }).ToList()
            };

            return imageDto;
        }
        public async Task<ImageDto?> Update(int id, ImageUpdateDto imageUpdateDto)
        {
            var image = await _imageRepository.GetById(id);

            if (image == null)
            {
                return null;
            }

            image.Title = imageUpdateDto.Title;
            image.Description = imageUpdateDto.Description;

            _imageRepository.Update(image);
            await _imageRepository.Save();

            var imageDto = new ImageDto
            {
                Id = image.Id,
                Url = image.Url,
                Description = image.Description,
                Title = image.Title,
                UserId = image.UserId,
                Comments = image.Comments.Select(c => new CommentDto
                {
                    Id = c.Id,
                    Body = c.Body,
                    Date = c.Date
                }).ToList()
            };

            return imageDto;
            
        }
    }
}

