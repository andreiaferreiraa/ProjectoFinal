﻿using System;
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
        /// <summary>
        /// retorna a view index com uma lista de comentários como model
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrador, Moderador, UtilizadorLogado")]
        public ActionResult Index()
        {
            var comentarios = db.Comentarios.Include(c => c.Noticia).Include(c => c.Utilizador);
            return View(comentarios.ToList());
        }

        //******************************************DETAILS*********************************************
        // GET: Comentarios/Details/5
        /// <summary>
        /// Método que permite mostrar os detalhes dos comentários
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrador, Moderador")]
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

        //**************************************************CREATE******************************************************
        // GET: Comentarios/Create
        /// <summary>
        /// GET: Comentarios/Create
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrador, Moderador, UtilizadorLogado")]
        public ActionResult Create()
        {
            ViewBag.NoticiaPK = new SelectList(db.Noticias, "ID", "Titulo");
            ViewBag.UtilizadorPK = new SelectList(db.Utilizadores, "ID", "Username");
            return View();
        }

        // POST: Comentarios/Create
        /// <summary>
        /// Método que permite criar um comentário e enviar resposta para o servidor
        /// </summary>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Texto,UtilizadorPK,NoticiaPK")] Comentarios comentarios)
        {
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
        /// <summary>
        /// GET: Comentarios/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Noticias");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {

                return RedirectToAction("Index", "Noticias");
            }
            if (comentarios.Utilizador.Email.Equals(User.Identity.Name) || User.IsInRole("Administrador") || User.IsInRole("Moderador"))
            {
               
                return View(comentarios);
            }
            ViewBag.NoticiaPK = new SelectList(db.Noticias, "ID", "Titulo", comentarios.NoticiaPK);
            ViewBag.UtilizadorPK = new SelectList(db.Utilizadores, "ID", "Username", comentarios.UtilizadorPK);
            return RedirectToAction("Index", "Noticias");
        }

        // POST: Comentarios/Edit/5
        /// <summary>
        /// Método que permite editar um comentário
        /// </summary>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Texto,DataComentario,UtilizadorPK,NoticiaPK")] Comentarios comentarios)
        {
            //so pode editar os comentarios o utilizador que o realizou
            comentarios.UtilizadorPK =  db.Utilizadores.Where(u => u.Username.Equals(User.Identity.Name)).FirstOrDefault().ID;
           
            try{
                if (ModelState.IsValid)
                {
                    comentarios.DataComentario = DateTime.Now;
                    db.Entry(comentarios).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("","Impossivel editar o comentário!" );
            }

          
            ViewBag.NoticiaPK = new SelectList(db.Noticias, "ID", "Titulo", comentarios.NoticiaPK);
            ViewBag.UtilizadorPK = new SelectList(db.Utilizadores, "ID", "Username", comentarios.UtilizadorPK);
            return View(comentarios);
        }

        //*****************************************************************DELETE*************************************************
        // GET: Comentarios/Delete/5
        /// <summary>
        ///  GET: Comentarios/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return RedirectToAction("Index");
            }
            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        /// <summary>
        ///  Método que permite apagar um comentário e envia resposta ao servidor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentarios comentarios = db.Comentarios.Find(id);

            try
            {
                //remover o jogador da memoria
                db.Comentarios.Remove(comentarios);
                //commit na base de dados
                db.SaveChanges();
                //redirecionar para a pagina inicial
                return RedirectToAction("Details", "Noticias", new { id = comentarios.NoticiaPK});
            }
            catch (Exception)
            {
                //gerar uma mensagem de erro a ser apresentada ao utilizador
                ModelState.AddModelError("", "Nao foi possivel remover ");
            }

            //reenvia os dados para a view
            return View(comentarios);
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
