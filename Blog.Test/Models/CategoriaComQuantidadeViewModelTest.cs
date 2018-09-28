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
                Titulo = "Senhor dos Aneis",
                Resumo = "As duas torres",
                Categoria = "Filme "
            };

            List<Post> posts = new List<Post>() { filmeMulerMaravilha, filmeSenhorAneis };

            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            int quantidadeDeFilmes = categoriaComQuantidade.GetQuantidadeDePostsDa("Filme");

            Assert.Equal(2, quantidadeDeFilmes);
        }

        [Fact]
        public void listaVaziaDeveDevolverListaDeCategoriasVazia()
        {
            List<Post> posts = new List<Post>() {};

            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            IList<String> categorias = categoriaComQuantidade.GetCategorias();

            Assert.Equal(0, categorias.Count);
        }

        [Fact]
        public void listaComUmPostDeveDevolverUmaCategoria()
        {
            Post filmeMulerMaravilha = new Post()
            {
                Titulo = "Mulher maravilha",
                Resumo = "Filme de origem da princesa Diana",
                Categoria = "Filme"
            };

            List<Post> posts = new List<Post>() { filmeMulerMaravilha };

            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            int quantidadeDeFilmes = categoriaComQuantidade.GetQuantidadeDePostsDa("Filme");

            Assert.Equal(1, quantidadeDeFilmes);
            Assert.Equal(1, categoriaComQuantidade.GetCategorias().Count);
        }

        [Fact]
        public void listaComPostsDeMaisDeUmaCategoriaDeveDevolverMaisDeUmaCategoria()
        {
            Post filmeMulherMaravilha = new Post()
            {
                Titulo = "Mulher maravilha",
                Resumo = "Filme de origem da princesa Diana",
                Categoria = "Filme"
            };

            Post filmeSenhorAneis = new Post()
            {
                Titulo = "Senhor dos Aneis",
                Resumo = "As duas torres",
                Categoria = "Filme "
            };

            Post livroSenhorAneisAsDuasTorres = new Post()
            {
                Titulo = "Senhod dos Aneis",
                Resumo = "O retorno do rei",
                Categoria = "Livro "
            };

            Post qualquerMusica = new Post()
            {
                Titulo = "Musica",
                Resumo = "hit do verao",
                Categoria = "Musica"
            };

            List<Post> posts = new List<Post>() { filmeMulherMaravilha, filmeSenhorAneis,livroSenhorAneisAsDuasTorres,qualquerMusica };

            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            
            Assert.Equal(3, categoriaComQuantidade.GetCategorias().Count);
        }

        [Fact]
        public void listaDeCategoriasDeveVirEmOrdemAlfabetica()
        {
            Post filmeSenhorAneisAsDuasTorres = new Post()
            {
                Titulo = "Senhod dos Aneis",
                Resumo = "O retorno do rei",
                Categoria = "Livro "
            };

            Post filmeMulerMaravilha = new Post()
            {
                Titulo = "Mulher maravilha",
                Resumo = "Filme de origem da princesa Diana",
                Categoria = "Filme"
            };

            Post filmeSenhorAneis = new Post()
            {
                Titulo = "Senhor dos Aneis",
                Resumo = "As duas torres",
                Categoria = "Filme "
            };

            Post qualquerMusica = new Post()
            {
                Titulo = "Musica",
                Resumo = "hit do verao",
                Categoria = "Musica"
            };

            List<Post> posts = new List<Post>() {filmeSenhorAneisAsDuasTorres, filmeMulerMaravilha, filmeSenhorAneis,qualquerMusica };

            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            IList<string> categorias = categoriaComQuantidade.GetCategorias();

            Assert.Equal("Filme",categorias[0]);
            Assert.Equal("Livro",categorias[1]);
            Assert.Equal("Musica",categorias[2]);
        }
    }
}
