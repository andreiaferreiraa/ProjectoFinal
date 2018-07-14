using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Utilizadores
    {
        public Utilizadores()
        {
            ListaDeComentarios = new HashSet<Comentarios>();
            ListaDeNoticias = new HashSet<Noticias>();
        }

        [Key]
        public int ID { get; set; }

        //atributos do utilizador
        [StringLength(24)]
        public string Username { get; set; }
        
        public string NomeCompleto { get; set; }

        [StringLength(24)]
        public string Email { get; set; }

        public string ContactoTelefonico { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Foto { get; set; }
        
        //completa o relacionamento de um utilizador com os comentarios a ele relacionados
        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
        public virtual ICollection<Noticias> ListaDeNoticias { get; set; }

    }
}