using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HockeyPT.Models;

namespace HockeyPT.Controllers
{
    public class TorneiosController : Controller
    {
        private HockeyBD db = new HockeyBD();

        // GET: Torneios
        public ActionResult Index()
        {
            return View(db.Torneios.ToList());
        }

        // GET: Torneios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneios torneios = db.Torneios.Find(id);
            if (torneios == null)
            {
                return HttpNotFound();
            }
            return View(torneios);
        }

        // GET: Torneios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Torneios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome")] Torneios torneios)
        {
            if (ModelState.IsValid)
            {
                db.Torneios.Add(torneios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(torneios);
        }

        // GET: Torneios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneios torneios = db.Torneios.Find(id);
            if (torneios == null)
            {
                return HttpNotFound();
            }
            return View(torneios);
        }

        // POST: Torneios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome")] Torneios torneios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(torneios);
        }

        // GET: Torneios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneios torneios = db.Torneios.Find(id);
            if (torneios == null)
            {
                return HttpNotFound();
            }
            return View(torneios);
        }

        // POST: Torneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Torneios torneios = db.Torneios.Find(id);
            db.Torneios.Remove(torneios);
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
