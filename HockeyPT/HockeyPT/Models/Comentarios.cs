using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Comentarios
    {
        public int ID { get; set; }

        public string Texto { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DataComentario { get; set; }

        //chave forasteira
        [ForeignKey("Utilizador")]
        public int UtilizadorPK { get; set; }
        public virtual Utilizadores Utilizador { get; set; }

        [ForeignKey("Noticia")]
        public int NoticiaPK { get; set; }
        public virtual Noticias Noticia { get; set; }
    }
}