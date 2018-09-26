using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private PostDAO dao;

        public PostController(PostDAO postDAO)
        {
            dao = postDAO;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var lista = dao.Lista();

            return View(lista);
        }

        public IActionResult Novo()
        {
            var model = new Post();
            return View(model);
        }

        [HttpPost]
        public IActionResult Adiciona(Post post){
            if (ModelState.IsValid)
            {
                dao.Adiciona(post);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Novo",post);
            }
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            var lista = dao.FiltraPorCategoria(categoria);

            return View("Index",lista);
        }

        public IActionResult RemovePost(int id)
        {
            dao.Remove(id);

            return RedirectToAction("Index");
        }

        public IActionResult Visualiza(int id)
        {
            Post post = dao.BuscaPorId(id);

            return View(post);
        }
        [HttpPost]
        public IActionResult EditaPost(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Atualiza(post);

                return RedirectToAction("Index");
            } else
            {
                return View("Visualiza", post);
            }
        }
        
        public IActionResult PublicaPost(int id)
        {
            dao.Publica(id);
            return RedirectToAction("Index");
        }
    }
}
