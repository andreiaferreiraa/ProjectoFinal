using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HockeyPT.Models;
using IdentitySample.Models;

namespace HockeyPT.Controllers
{
    public class ComentariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Comentarios
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "UtilizadorLogado")]
        public ActionResult Index()
        {
            var comentarios = db.Comentarios.Include(c => c.Noticia).Include(c => c.Utilizador);
            return View(comentarios.ToList());
        }

        //******************************************DETAILS*********************************************
        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            //caso o valor do id seja nulo
            if (id == null)
            {
                //redireciona para a pagina inicial
                return RedirectToAction("Index");

            }

            //vai procurar o ID do Comentario fornecido
            Comentarios comentarios = db.Comentarios.Find(id);

            //se o comentario nao foi encontrado
            if (comentarios == null)
            {
                //redirecciona para o Index
                return RedirectToAction("Index");
            }

            //envia para  a view o comentario
            return View(comentarios);
        }

        public ActionResult ListaComentarios()
        {
            var model = db.Comentarios.ToList();
            return PartialView(model);
        }

        
        //**************************************************CREATE******************************************************
        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.NoticiaPK = new SelectList(db.Noticias, "ID", "Titulo");
            ViewBag.UtilizadorPK = new SelectList(db.Utilizadores, "ID", "Username");
            return View();
        }

        // POST: Comentarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Texto,UtilizadorPK,NoticiaPK")] Comentarios comentarios)
        {
            //associar o comentario ao utilizador logado
            //caso o utilizador meta comentario
            //adicionar esse comentario a uma noticia
            //adicionar esse comentario ao utilizador

            
           
            if (ModelState.IsValid)
            {
           
                    db.Comentarios.Add(comentarios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }

            ViewBag.NoticiaPK = new SelectList(db.Noticias, "ID", "Titulo", comentarios.NoticiaPK);
            ViewBag.UtilizadorPK = new SelectList(db.Utilizadores, "ID", "Username", comentarios.UtilizadorPK);
            return View(comentarios);
        }

        //************************************************************EDIT****************************************************
        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoticiaPK = new SelectList(db.Noticias, "ID", "Titulo", comentarios.NoticiaPK);
            ViewBag.UtilizadorPK = new SelectList(db.Utilizadores, "ID", "Username", comentarios.UtilizadorPK);
            return View(comentarios);
        }

        // POST: Comentarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Texto,dataComentario,UtilizadorPK,NoticiaPK")] Comentarios comentarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NoticiaPK = new SelectList(db.Noticias, "ID", "Titulo", comentarios.NoticiaPK);
            ViewBag.UtilizadorPK = new SelectList(db.Utilizadores, "ID", "Username", comentarios.UtilizadorPK);
            return View(comentarios);
        }

        //*****************************************************************DELETE*************************************************
        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return HttpNotFound();
            }
            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentarios comentarios = db.Comentarios.Find(id);
            db.Comentarios.Remove(comentarios);
            db.SaveChanges();
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
