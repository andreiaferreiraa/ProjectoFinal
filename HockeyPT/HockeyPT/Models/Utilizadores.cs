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

        [RegularExpression("[A-ZÂÍ][a-záéíóúãõàèìòùâêîôûäëïöüç.]+(( | de | da | dos | d'|-)[A-ZÂÍ][a-záéíóúãõàèìòùâêîôûäëïöüç.]+){1,3}",
            ErrorMessage = "O nome apenas aceita letras. Cada palavra começa por uma maiúscula, seguida de minúsculas")]
        public string NomeCompleto { get; set; }

        [StringLength(24)]
        public string Email { get; set; }


        [RegularExpression("(9[1236][0-9]) ?([0-9]{3}) ?([0-9]{3})",
            ErrorMessage = "Contacto Telefónico Inválido")]
        public string ContactoTelefonico { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string Foto { get; set; }
        
        //completa o relacionamento de um utilizador com os comentarios a ele relacionados
        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
        public virtual ICollection<Noticias> ListaDeNoticias { get; set; }

    }
}