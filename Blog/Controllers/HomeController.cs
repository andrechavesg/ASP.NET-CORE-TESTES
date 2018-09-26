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
        PostDAO dao;
        public HomeController(PostDAO postDAO)
        {
            dao = postDAO;
        }
        
        public IActionResult Index()
        {
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }
    }
}
