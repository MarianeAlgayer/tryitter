using Tryitter.Models;
using Tryitter.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Tryitter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            try
            {
                var posts = _context.Posts.ToList();

                if (posts is null)
                {
                    return NotFound("Nenhum post encontrado.");
                }

                return Ok(posts);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado.");
            }
        }

        [HttpGet("{id:int}", Name = "GetPost")]
        public ActionResult<Post> GetPost(int id)
        {
            try
            {
                var post = _context.Posts.FirstOrDefault(p => p.PostId == id);

                if (post is null)
                {
                    return NotFound("Post não encontrado.");
                }

                return Ok(post);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado.");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult PostPost(Post post)
        {
            if (post is null) return BadRequest("Dados inválidos.");

            _context.Posts.Add(post);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetPost", new { id = post.PostId }, post);
        }

        [HttpPut("{id:int}")]
        [Authorize]
        public ActionResult PutPost(int id, Post post)
        {
            if (id != post.PostId) return BadRequest("Id não encontrado.");

            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(post);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public ActionResult DeletePost(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);

            if (post is null) return NotFound("Post não encontrado.");

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return Ok(post);
        }
    }
}
