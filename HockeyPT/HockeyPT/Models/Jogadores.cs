using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class Jogadores
    {
        [Key]
        public int ID { get; set; }

        //Dados do Jogador

        public string Nome { get; set; }

        public string Posicao { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        public string Nacionalidade { get; set; }

        public double Altura { get; set; }

        public double Peso { get; set; }

        public string Fotografia { get; set; }

        //Construção da Chave Forasteira
        [ForeignKey("Equipa")]
        public int EquipaPK { get; set; }
        public virtual Equipas Equipa { get; set; }
    }
}