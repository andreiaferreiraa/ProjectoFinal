using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Equipas
    {
        public Equipas()
        { 
            ListaDeNoticias = new HashSet<Noticias>();
            ListaDeJogadores = new HashSet<Jogadores>();
        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Logotipo { get; set; }

        public string Cidade { get; set; }
        
        public virtual ICollection<Noticias> ListaDeNoticias { get; set; }

        public virtual ICollection<Jogadores> ListaDeJogadores { get; set; }

    }
}