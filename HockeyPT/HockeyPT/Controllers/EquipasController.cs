using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HockeyPT.Models;
using IdentitySample.Models;

namespace HockeyPT.Controllers
{
    public class EquipasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Equipas
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var listaDeEquipas = db.Equipas.OrderBy(e => e.ID).ToList();
            return View(listaDeEquipas);
        }

        //*************************************DETAILS****************************************************************
        // GET: Equipas/Details/5
        //[Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            //caso o valor do id seja nulo
            if (id == null)
            {
                //redirecciona para a pagina inicial
                return RedirectToAction("Index");

            }
            //vai procurar o ID da Equipa fornecido
            Equipas equipas = db.Equipas.Find(id);

            //se a Equipa nao for encontrada
            if (equipas == null)
            {
                //redirecciona para o Index
                return RedirectToAction("Index");
            }

            //envia para  a view os dados da Equipa 
            return View(equipas);
        }
        public ActionResult ListarEquipas()
        {
            var model = db.Equipas.ToList();
            return PartialView(model);
        }
        //*****************************************************CREATE********************************************
        // GET: Equipas/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Equipas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "ID,Nome,Logotipo,Cidade")] Equipas equipas,
                                    HttpPostedFileBase ficheiroLogotipo)
        {

            //determinar o ID do novo jogador
            int novoID = 0;

            //verifica se nao ha jogador nenhum na base de dados
            if (db.Equipas.Count() == 0)
            {
                novoID = 1;
            }

            //caso haja, verifica qual é o ID maximo , e acrescenta lhe 1
            else
            {
                novoID = db.Equipas.Max(e => e.ID) + 1;
            }

            //atribuição do novo ID à equipa
            equipas.ID = novoID;

            string nomeLogotipo = "Equipa_" + novoID + ".jpg";
            // indica onde a imagem será guardada
            string caminhoLogotipo = Path.Combine(Server.MapPath("~/EquipasFotos/"), nomeLogotipo);

            //verifica se chega algum ficheiro ao servidor
            if (ficheiroLogotipo != null)
            {
                //guarda o nome da imagem na base de dados
                equipas.Logotipo = nomeLogotipo;
            }
            else
            {
                //nao ha imagem
                ModelState.AddModelError("", "Não foi fornecido nenhum Logotipo da Equipa!"); // gera MSG de erro
                // reenvia os dados da 'Equipa' para a View
                return View(equipas);
            }

            //verifica se o ficheiro é mesmo uma fotografia



            //confronta os dados fornecidos com o modelo, caso nao respeitem as regras do modelo, rejeita-os
            if (ModelState.IsValid)
            {
                try
                {
                    // adiciona na estrutura de dados, na memória do servidor, o objeto Equipas
                    db.Equipas.Add(equipas);
                    // faz 'commit' na BD
                    db.SaveChanges();

                    // guardar a imagem no disco rígido
                    ficheiroLogotipo.SaveAs(caminhoLogotipo);

                    // redireciona o utilizador para a página de início
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    // gerar uma mensagem de erro para o utilizador
                    ModelState.AddModelError("", "Ocorreu um erro não determinado na criação da novo Equipa...");
                }
            }
            // se se chegar aqui, é pq aconteceu algum problema...
            // devolve os dados do agente à View
            return View(equipas);
        }


        //**************************************************************EDIT*******************************************
        // GET: Equipas/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");

            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(equipas);
        }

        // POST: Equipas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "ID,Nome,Logotipo,Cidade")] Equipas equipa,
                                 HttpPostedFileBase novoLogotipo)
        {
            //variaveis auxiliares
            string novoNome = "";
            string nomeAntigo = "";

            if (ModelState.IsValid)
            {
                try
                {
                    if (novoLogotipo != null)
                    {
                        nomeAntigo = equipa.Logotipo;
                        novoNome = "Equipa" + equipa.ID + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetExtension(novoLogotipo.FileName).ToLower(); ;
                        equipa.Logotipo = novoNome;
                        novoLogotipo.SaveAs(Path.Combine(Server.MapPath("~/EquipasFotos/"), novoNome));
                    }

                    db.Entry(equipa).State = EntityState.Modified;
                    db.SaveChanges();

                    if (novoLogotipo != null)
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/EquipasFotos/"), nomeAntigo));

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    // caso haja um erro deve ser enviada uma mensagem para o utilizador
                    ModelState.AddModelError("", string.Format("Ocorreu um erro com a edição dos dados da noticia {0}", equipa.Nome));
                }
            }
            return View(equipa);
        }


        //**************************************************DELETE*********************************************************
        // GET: Equipas/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            return View(equipas);
        }


        // POST: Equipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticias noticia = db.Noticias.Find(id);

            try
            {
                //remover da memoria
                db.Noticias.Remove(noticia);
                //commit na base de dados
                db.SaveChanges();
                //redirecionar para a pagina inicial
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //gerar uma mensagem de erro, a ser apresentada pelo utilizador
                ModelState.AddModelError("",
                                         string.Format("Nao foi possivel remover a Equipa {0}, pois tem {1} Jogadores associados",
                                         noticia.Titulo, noticia.ListaDeEquipas.Count));

            }
            
            return RedirectToAction("Index");
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
    


