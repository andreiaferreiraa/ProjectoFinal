using HockeyPT.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System;

namespace IdentitySample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            iniciaAplicacao();
        }

        public void iniciaAplicacao()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Administrador
            if (!roleManager.RoleExists("Administrador"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);
            }

            //criar role 'Moderador'
            if (!roleManager.RoleExists("Moderador"))
            {
                var role = new IdentityRole();
                role.Name = "Moderador";
                roleManager.Create(role);
            }

            // criar a Role 'UtilizadorLogado'
            if (!roleManager.RoleExists("UtilizadorLogado"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "UtilizadorLogado";
                roleManager.Create(role);
            }
           
            // criar um utilizador 'Administrador'
            var user = new ApplicationUser();
            user.UserName = "andreiaferreira4@mail.pt";
            user.Email = "andreiaferreira4@mail.pt";
            //password do administrador
            string userPWD = "Admin_123";
            var chkUser = userManager.Create(user, userPWD);
            Utilizadores utilizador = new Utilizadores
            {
                Username = user.Email,
                ID = 3,
                NomeCompleto = "Andreia Ferreira",
                DataNascimento = new DateTime(1997, 05, 18),
                Email = user.Email,
                ContactoTelefonico="910914229"          
                };

            //criar um utilizador 'Moderador'
            var moderador = new ApplicationUser();
            moderador.UserName = "ralvesferreira3@hotmail.com";
            moderador.Email = "ralvesferreira3@hotmail.com";
            //password deste moderador
            string moderadorPWD = "Mod_123";
            var chkModerador = userManager.Create(moderador, moderadorPWD);

            //verifica se teve sucesso
            if (chkUser.Succeeded)
            {
                //caso tenha adiciona
                var result1 = userManager.AddToRole(user.Id, "Administrador");
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
                var result2 = userManager.AddToRole(moderador.Id, "Moderador");

            }



        }

    }
}
