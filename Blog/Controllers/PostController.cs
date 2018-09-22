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
        // GET: /<controller>/
        public IActionResult Index()
        {
            var listaDePosts = new List<Post>()
            {
                new Post(){ Titulo = "Harry Potter 1",Resumo = "Pedra Filosofal",Categoria = "Filme, Livro"},
                new Post(){ Titulo = "CassinoRoyale",Resumo = "007",Categoria = "Filme"},
                new Post(){ Titulo = "Monge e o Executivo",Resumo = "Romance sobre Liderança",Categoria = "Livro"},
                new Post(){ Titulo = "New York, New York",Resumo = "Sucesso de Frank Sinatra",Categoria = "Música"}
            };

            return View(listaDePosts);
        }
    }
}