using LabsRV_Articles.Models.DTO;
using LabsRV_Articles.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabsRV_Articles.Controllers
{
    [ApiController]
    [Route("api/v1.0/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ArticleRequestDto request)
        {
            var response = _articleService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = response.id }, response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _articleService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _articleService.GetById(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ArticleRequestDto request)
        {
            var response = _articleService.Update(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return NoContent();
        }
    }
}
