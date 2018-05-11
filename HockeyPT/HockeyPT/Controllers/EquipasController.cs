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
    public class EquipasController : Controller
    {
        private HockeyBD db = new HockeyBD();

        // GET: Equipas
        public ActionResult Index()
        {
            return View(db.Equipas.ToList());
        }

        // GET: Equipas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            return View(equipas);
        }

        // GET: Equipas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Logotipo,Cidade")] Equipas equipas)
        {
            if (ModelState.IsValid)
            {
                db.Equipas.Add(equipas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipas);
        }

        // GET: Equipas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            return View(equipas);
        }

        // POST: Equipas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Logotipo,Cidade")] Equipas equipas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipas);
        }

        // GET: Equipas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipas equipas = db.Equipas.Find(id);
            if (equipas == null)
            {
                return HttpNotFound();
            }
            return View(equipas);
        }

        // POST: Equipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipas equipas = db.Equipas.Find(id);
            db.Equipas.Remove(equipas);
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
