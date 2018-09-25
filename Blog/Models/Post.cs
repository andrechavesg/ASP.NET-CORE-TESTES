using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Post
    {
        public int Id {
            get;
            set;
        }

        [Required]
        [StringLength(50)]
        [Display(Name = "Título")]
        public String Titulo
        {
            get;
            set;
        }

        [Required]
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
