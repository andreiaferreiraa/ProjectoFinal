using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Torneios
    {
        public Torneios()
        {
            ListaDeEquipas = new HashSet<Equipas>();
        }

        //Atributos do torneios
        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Equipas> ListaDeEquipas { get; set; }
    }
}