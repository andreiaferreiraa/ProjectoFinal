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
            var moderador1 = new ApplicationUser();
            moderador1.UserName = "r_a_ferreira3@gmail.com";
            moderador1.Email = "r_a_ferreira3@gmail.com";
            //password deste moderador
            string moderador1PWD = "Mod_123";
            var chkModerador1 = userManager.Create(moderador1, moderador1PWD);

            //verifica se teve sucesso
            if (chkUser.Succeeded)
            {
                //caso tenha adiciona
                var result1 = userManager.AddToRole(user.Id, "Administrador");
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
                var result2 = userManager.AddToRole(moderador1.Id, "Moderador");

            }

            var moderador2 = new ApplicationUser();
            moderador2.UserName = "jcarlopes3@hotmail.com";
            moderador2.Email = "jcarlopes3@hotmail.com";
            //password deste moderador
            string moderador2PWD = "Mod_123";
            var chkModerador2 = userManager.Create(moderador2, moderador2PWD);

            //verifica se teve sucesso
            if (chkUser.Succeeded)
            {
                //caso tenha adiciona
                var result1 = userManager.AddToRole(user.Id, "Administrador");
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
                var result2 = userManager.AddToRole(moderador2.Id, "Moderador");

            }

            var moderador3 = new ApplicationUser();
            moderador3.UserName = "ananunesrib9@gmail.com";
            moderador3.Email = "ananunesrib9@gmail.com";
            //password deste moderador
            string moderador3PWD = "Mod_123";
            var chkModerador3 = userManager.Create(moderador3, moderador3PWD);

            //verifica se teve sucesso
            if (chkUser.Succeeded)
            {
                //caso tenha adiciona
                var result1 = userManager.AddToRole(user.Id, "Administrador");
                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
                var result2 = userManager.AddToRole(moderador3.Id, "Moderador");

            }





        }

    }
}
