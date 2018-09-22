using System;
namespace Blog.Models
{
    public class Post
    {
        public int Id {
            get;
            set;
        }

        public String Titulo
        {
            get;
            set;
        }

        public String Resumo
        {
            get;
            set;
        }   

        public String Categoria
        {
            get;
            set;
        }

        public DateTime? DataPublicacao {
            get;
            set;
        }

        public bool Publicado {
            get;
            set;
        }

        public Post()
        {
        }
    }
}
