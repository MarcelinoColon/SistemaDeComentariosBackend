using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
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
        private readonly ICommentsServices _commentsServices;
        public ImageController(IImagesServices imagesServices,
                               ICommentsServices commentsServices)
        {
            _imagesServices = imagesServices;
            _commentsServices = commentsServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetAll()
        {
            var imagesDto = await _imagesServices.GetAll();

            return Ok(imagesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ImageDto>> GetById(int id)
        {
            var imageDto = await _imagesServices.GetById(id);

            if(imageDto is null)
            {
                return NotFound();
            }

            return Ok(imageDto);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ImageInsertDto imageInsertDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var imageDto = await _imagesServices.Add(imageInsertDto);

            if (imageDto is null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new {id= imageDto.Id}, imageDto);
        }
    }
}
