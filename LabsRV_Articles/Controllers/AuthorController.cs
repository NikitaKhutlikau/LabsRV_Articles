using LabsRV_Articles.Models.DTO;
using LabsRV_Articles.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabsRV_Articles.Controllers
{
    [ApiController]
    [Route("api/v1.0/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] AuthorRequestDto request)
        {
            var response = _authorService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.id }, response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _authorService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _authorService.GetById(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AuthorRequestDto request)
        {
            if (request == null)
                return BadRequest(new { errorMessage = "Request body is missing or invalid." });

            if (id <= 0)
                return BadRequest(new { errorMessage = "Invalid ID provided." });

            var response = _authorService.Update(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.Delete(id);
            return NoContent();
        }
    }
}
