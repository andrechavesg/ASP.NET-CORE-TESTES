using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.API.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostDAO dao;

        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }

        // GET: api/Post
        [HttpGet]
        public IActionResult Get()
        {
            IList<Post> posts = dao.Lista();

            return Ok(posts);
        }

        // GET: api/Post/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Post post = dao.BuscaPorId(id);
            return Ok(post);
        }

        // POST: api/Post
        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            dao.Adiciona(post);
            return CreatedAtAction("BuscaPostPorId", new { id = post.Id }, post);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            Post postBanco = dao.BuscaPorId(id);
            if(postBanco == null)
            {
                return NotFound();
            }
            postBanco.Titulo = post.Titulo;
            postBanco.Resumo = post.Resumo;
            postBanco.Categoria = post.Categoria;
            postBanco.DataPublicacao = post.DataPublicacao;
            dao.Atualiza(postBanco);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(dao.BuscaPorId(id) == null)
            {
                return NotFound();
            }
            dao.Remove(id);
            return NoContent();
        }
    }
}
