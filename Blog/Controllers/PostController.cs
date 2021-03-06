﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private IList<Post> lista;

        public PostController()
        {
            lista = new List<Post>()
            {
                new Post(){ Titulo = "Harry Potter 1",Resumo = "Pedra Filosofal",Categoria = "Filme, Livro" },
                new Post(){ Titulo = "CassinoRoyale",Resumo = "007",Categoria = "Filme" },
                new Post(){ Titulo = "Monge e o Executivo",Resumo = "Romance sobre Liderança",Categoria = "Livro" },
                new Post(){ Titulo = "New York, New York",Resumo = "Sucesso de Frank Sinatra",Categoria = "Música" }
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(lista);
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post){
            lista.Add(post);

            return View("Index", lista);
        }
    }
}
