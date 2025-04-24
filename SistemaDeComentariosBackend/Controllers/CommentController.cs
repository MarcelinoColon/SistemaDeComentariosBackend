using Microsoft.AspNetCore.Mvc;
using SistemaDeComentariosBackend.DTOs;
using SistemaDeComentariosBackend.Services;

namespace SistemaDeComentariosBackend.Controllers
{
    [Route("api/image/{imageId:int}/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentsServices _commentsServices;
        private readonly IImagesServices _imagesServices;
        public CommentController(ICommentsServices commentsServices,
                                 IImagesServices imagesServices)
        {
            _commentsServices = commentsServices;
            _imagesServices = imagesServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetImageComments(int imageId)
        {
            var CommentsDto = await _commentsServices.GetImageComments(imageId);

            return CommentsDto == null ? NotFound() : Ok(CommentsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetImageCommentById(int imageId, Guid id)
        {
            var commentDto = await _commentsServices.GetImageCommentById(imageId, id);

            return commentDto == null ? NotFound() : Ok(commentDto);
        }

        [HttpPost]
        public async Task<ActionResult<CommentDto>> AddComment(int imageId, CreateCommentDto createCommentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var commentDto = await _commentsServices.AddComment(imageId, createCommentDto);

            return CreatedAtAction(nameof(GetImageCommentById), new { imageId = imageId, Id = commentDto.Id }, commentDto);
        }

    }
}
