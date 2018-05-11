using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Utilizadores
    {
        public Utilizadores()
        {
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int ID { get; set; }

        //atributos do utilizador
        [StringLength(15)]
        public string Username { get; set; }

        [StringLength(40)]
        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string ContactoTelefonico { get; set; }

        public DateTime DataNascimento { get; set; }

        //completa o relacionamento de um utilizador com os comentarios a ele relacionados
        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }

    }
}