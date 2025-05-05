using LabsRV_Discussion.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LabsRV_Discussion.Controllers;

[ApiController]
[Route("api/v1.0/comments")]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _repository;

    public CommentController(ICommentRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommentRequestDto request)
    {
        var response = await _repository.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = await _repository.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
