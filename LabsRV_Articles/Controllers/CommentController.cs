using LabsRV_Articles.Models.DTO;
using LabsRV_Articles.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabsRV_Articles.Controllers
{
    [ApiController]
    [Route("api/v1.0/comments")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CommentRequestDto request)
        {
            var response = _commentService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.id }, response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _commentService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _commentService.GetById(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CommentRequestDto request)
        {
            var response = _commentService.Update(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentService.Delete(id);
            return NoContent();
        }
    }
}
