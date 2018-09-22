using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            var lista = dao.Lista();

            return View(lista);
        }

        public IActionResult Novo()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post){
            PostDAO dao = new PostDAO();
            dao.Adiciona(post);

            return RedirectToAction("Index");
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            PostDAO dao = new PostDAO();

            var lista = dao.FiltraPorCategoria(categoria);

            return View("Index",lista);
        }
    }
}
