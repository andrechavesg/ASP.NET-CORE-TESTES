using Blog.Models;
using Blog.Models.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Blog.Test.Models
{
    public class CategoriaComQuantidadeViewModelTest
    {
        [Fact]
        public void aListaDeCategoriasDeveIgnorarEspacosAEsquerdaEAdireitaDoNomeQuandoAgrupar()
        {
            Post filmeMulerMaravilha = new Post()
            {
                Titulo = "Mulher maravilha",
                Resumo = "Filme de origem da princesa Diana",
                Categoria = "Filme"
            };

            Post filmeSenhorAneis = new Post()
            {
                Titulo = "Senhod dos Aneis",
                Resumo = "As duas torres",
                Categoria = "Filme "
            };

            List<Post> posts = new List<Post>() { filmeMulerMaravilha, filmeSenhorAneis };

            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            int quantidadeDeFilmes = categoriaComQuantidade.GetQuantidadeDePostsDa("Filme");

            Assert.Equal(2, quantidadeDeFilmes);
        }
    }
}
