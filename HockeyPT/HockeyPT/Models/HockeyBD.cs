using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HockeyPT.Models
{
    public class HockeyBD: DbContext
    {
        public HockeyBD() : base("HoqueiDbConnectionString")
        { }

        public virtual DbSet<Jogadores> Jogadores { get; set; }
        public virtual DbSet<Equipas> Equipas { get; set; }
        public virtual DbSet<Torneios> Torneios { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Utilizadores> Utilizadores { get; set; }

        /// <summary>
        /// configura a forma como as tabelas são criadas
        /// </summary>
        /// <param name="modelBuilder"> objeto que referencia o gerador de base de dados </param>      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}