using Microsoft.AspNetCore.Mvc;
using Blog.Data;
using Blog.Entities;
using Blog.Services;

namespace Blog.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    // GET api/comments/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(int id)
    {
        Comment comment = await _commentService.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    // GET api/comments/post/{postId}
    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetCommentsByPostId(int postId)
    {
        List<Comment> comments = await _commentService.GetCommentsByPostIdAsync(postId);
        return Ok(comments);
    }

    // POST api/comments
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] Comment newComment)
    {
        if (newComment == null)
        {
            return BadRequest();
        }

        await _commentService.CreateNewCommentAsync(newComment);
        return CreatedAtAction(nameof(GetCommentById), new { id = newComment.Id }, newComment);
    }

    // PUT api/comments/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComment(int id, [FromBody] Comment updatedComment)
    {
        if (updatedComment == null || id != updatedComment.Id)
        {
            return BadRequest();
        }

        var existingComment = await _commentService.GetCommentByIdAsync(id);
        if (existingComment == null)
        {
            return NotFound();
        }

        await _commentService.UpdateExistingCommentAsync(updatedComment);
        return NoContent();
    }

    // DELETE api/comments/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var existingComment = await _commentService.GetCommentByIdAsync(id);
        if (existingComment == null)
        {
            return NotFound();
        }

        await _commentService.DeleteCommentAsync(id);
        return NoContent();
    }
}
