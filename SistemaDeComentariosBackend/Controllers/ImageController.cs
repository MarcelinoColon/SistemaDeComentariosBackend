using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeComentariosBackend.Entitites;
using SistemaDeComentariosBackend.Repository;
using SistemaDeComentariosBackend.Services;

namespace SistemaDeComentariosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImagesServices _imagesServices;
        private readonly IImageRepository _imageRepository;
        public ImageController(IImagesServices imagesServices,
                               IImageRepository imageRepository)
        {
            _imagesServices = imagesServices;
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetAll()
        {
            var Images = await _imagesServices.GetAll();

            return Ok(Images);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Image>> GetById(int id)
        {
            var image = await _imagesServices.GetById(id);

            if(image is null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _imagesServices.Add(image);

            await _imageRepository.Save();

            return Ok();
        }
    }
}
