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
    public class UtilizadoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Utilizadores
        public ActionResult Index()
        {
            return View(db.Utilizadores.ToList());
        }

        // GET: Utilizadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        /// <summary>
        /// Método que permite criar um utilizador
        /// </summary>
        /// <param name="utilizadores"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username, NomeCompleto, Apelido,Email,ContactoTelefonico,DataNascimento")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Utilizadores.Add(utilizadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilizadores);
        }

        // GET: Utilizadores/Edit/5
        /// <summary>
        /// GET: Utilizadores/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Edit/5
        /// <summary>
        /// Método que permite editar um utilizador
        /// </summary>
        /// <param name="utilizadores"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,NomeCompleto, Email,ContactoTelefonico,DataNascimento")] Utilizadores utilizadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            return View(utilizadores);
        }

        // GET: Utilizadores/Delete/5
        /// <summary>
        /// GET: Utilizadores/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizadores utilizadores = db.Utilizadores.Find(id);
            if (utilizadores == null)
            {
                return HttpNotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Delete/5
        /// <summary>
        /// Método que permite apagar um utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizadores utilizadores = db.Utilizadores.Find(id);
            db.Utilizadores.Remove(utilizadores);
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
