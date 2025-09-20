using Backend_PO.DTOs.Requests;
using Backend_PO.Interfaces;
using Backend_PO.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_PO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            var comments = await _commentService.GetAllCommentsAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequest request)
        {
            var comment = new Comment
            {
                Content = request.Content,
                UserId = request.UserId,
                KursId = request.KursId,
                CreatedAt = DateTime.UtcNow
            };

            var createdComment = await _commentService.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = createdComment.Id }, createdComment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] UpdateCommentRequest request)
        {
            var existingComment = await _commentService.GetCommentByIdAsync(id);
            if (existingComment == null)
                return NotFound();

            existingComment.Content = request.Content;
            if (request.UserId.HasValue)
                existingComment.UserId = request.UserId.Value;
            if (request.KursId.HasValue)
                existingComment.KursId = request.KursId.Value;

            var success = await _commentService.UpdateCommentAsync(id, existingComment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var success = await _commentService.DeleteCommentAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}