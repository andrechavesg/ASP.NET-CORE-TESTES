using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DAO
{
    public class PostDAO
    {
        private readonly BlogContext contexto;
        public PostDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }
        public IList<Post> Lista()
        {
            var lista = contexto.Posts.ToList();

            return lista;
        }

        public IList<Post> ListaPublicados()
        {
            return contexto.Posts.Where(p => p.Publicado).OrderByDescending(p => p.DataPublicacao).ToList();
        }

        public void Adiciona(Post post)
        {
            contexto.Posts.Add(post);
            contexto.SaveChanges();

        }

        public IList<Post> FiltraPorCategoria(string categoria)
        {
            var lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();

            return lista;

        }

        public void Remove(int id)
        {
            Post post = contexto.Posts.Find(id);
            contexto.Remove(post);
            contexto.SaveChanges();

        }

        public Post BuscaPorId(int id)
        {
            return contexto.Posts.Find(id);
        }

        public void Atualiza(Post post)
        {
            contexto.Entry(post).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Publica(int id)
        {
            Post post = contexto.Posts.Find(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;

            contexto.SaveChanges();
        }
    }
}
