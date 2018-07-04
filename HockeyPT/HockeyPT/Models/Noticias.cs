using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Noticias
    {
        public Noticias()
        {
            ListaDeEquipas = new HashSet<Equipas>();
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public DateTime Data { get; set; }

        public string Fotografia { get; set; }

        public Boolean IsVisible { get; set; }


        [ForeignKey("Utilizador")]
        public int UtilizadorPK { get; set; }
        public virtual Utilizadores Utilizador { get; set; }
        
        public virtual ICollection<Equipas> ListaDeEquipas { get; set; }

        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
    }
}
