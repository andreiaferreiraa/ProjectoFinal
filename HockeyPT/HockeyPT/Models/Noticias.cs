using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Noticias
    {
        public Noticias()
        {
            ListaDeEquipas = new HashSet<Equipas>();
        }

        [Key]
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public string Fotografia { get; set; }


        public virtual ICollection<Equipas> ListaDeEquipas { get; set; }

        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
    }
}
