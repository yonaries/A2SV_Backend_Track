using Microsoft.AspNetCore.Mvc;
using Blog.Data;
using Blog.Services;
using Blog.Entities;

namespace Blog.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
	private readonly PostService _postService;

    public PostController(PostService postService)
    {
        _postService = postService;
    }

    // GET api/posts
    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        List<Post> posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    // GET api/posts/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        Post post = await _postService.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    // POST api/posts
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] Post newPost)
    {
        if (newPost == null)
        {
            return BadRequest();
        }

        await _postService.CreateNewPostAsync(newPost);
        return CreatedAtAction(nameof(GetPostById), new { id = newPost.Id }, newPost);
    }

    // PUT api/posts/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] Post updatedPost)
    {
        if (updatedPost == null || id != updatedPost.Id)
        {
            return BadRequest();
        }

        var existingPost = await _postService.GetPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        await _postService.UpdateExistingPostAsync(updatedPost);
        return NoContent();
    }

    // DELETE api/posts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var existingPost = await _postService.GetPostByIdAsync(id);
        if (existingPost == null)
        {
            return NotFound();
        }

        await _postService.DeletePostAsync(id);
        return NoContent();
    }
}