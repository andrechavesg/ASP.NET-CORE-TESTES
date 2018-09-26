using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Infra;
using Blog.DAO;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        BlogContext contexto;
        PostDAO dao;
        public HomeController()
        {
            contexto = new BlogContext();
            dao = new PostDAO(contexto);
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                contexto.Dispose();
            }
            base.Dispose(disposing);
        }
        public IActionResult Index()
        {
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }
    }
}
