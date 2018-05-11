using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Comentarios
    {
        public int ID { get; set; }

        public string Texto { get; set; }

        public DateTime dataComentario { get; set; }

        //chave forasteira
        [ForeignKey("Utilizador")]
        public int UtilizadorPK { get; set; }
        public virtual Utilizadores Utilizador { get; set; }

        [ForeignKey("Noticia")]
        public int NoticiaPK { get; set; }
        public virtual Noticias Noticia { get; set; }
    }
}