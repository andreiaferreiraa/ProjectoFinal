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
    public class JogadoresController : Controller
    {
        private HockeyBD db = new HockeyBD();

        // GET: Jogadores
        public ActionResult Index()
        {
            var jogadores = db.Jogadores.Include(j => j.Equipa);
            return View(jogadores.ToList());
        }

        // GET: Jogadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            return View(jogadores);
        }

        // GET: Jogadores/Create
        public ActionResult Create()
        {
            ViewBag.EquipaPK = new SelectList(db.Equipas, "ID", "Nome");
            return View();
        }

        // POST: Jogadores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Posicao,DataNascimento,Nacionalidade,Altura,Peso,Fotografia,EquipaPK")] Jogadores jogadores)
        {
            if (ModelState.IsValid)
            {
                db.Jogadores.Add(jogadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipaPK = new SelectList(db.Equipas, "ID", "Nome", jogadores.EquipaPK);
            return View(jogadores);
        }

        // GET: Jogadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipaPK = new SelectList(db.Equipas, "ID", "Nome", jogadores.EquipaPK);
            return View(jogadores);
        }

        // POST: Jogadores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Posicao,DataNascimento,Nacionalidade,Altura,Peso,Fotografia,EquipaPK")] Jogadores jogadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipaPK = new SelectList(db.Equipas, "ID", "Nome", jogadores.EquipaPK);
            return View(jogadores);
        }

        // GET: Jogadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                return HttpNotFound();
            }
            return View(jogadores);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogadores jogadores = db.Jogadores.Find(id);
            db.Jogadores.Remove(jogadores);
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
