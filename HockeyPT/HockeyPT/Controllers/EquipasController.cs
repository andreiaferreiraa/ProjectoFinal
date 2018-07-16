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
        /// <summary>
        ///  Método que apresenta detalhes das equipas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        //**************************************************************EDIT*******************************************
        // GET: Equipas/Edit/5
        /// <summary>
        /// GET: Equipas/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Método que permite editar uma equipa e enviar respostas para o servidor
        /// </summary>
        /// <param name="equipa"></param>
        /// <param name="novoLogotipo"></param>
        /// <returns></returns>
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
                        if (novoLogotipo.ContentType.Contains("image/")) { 
                            nomeAntigo = equipa.Logotipo;
                            novoNome = "Equipa" + equipa.ID + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetExtension(novoLogotipo.FileName).ToLower(); ;
                            equipa.Logotipo = novoNome;
                            novoLogotipo.SaveAs(Path.Combine(Server.MapPath("~/EquipasFotos/"), novoNome));
                        }
                        else
                        {
                            ModelState.AddModelError("", "Erro ao inserir imagem, ficheiro não é uma imagem!");
                            return View(equipa);
                        }
                    }

                    db.Entry(equipa).State = EntityState.Modified;
                    db.SaveChanges();

                    if (novoLogotipo != null && novoLogotipo.ContentType.Contains("/image"))
                    {
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/EquipasFotos/"), nomeAntigo));
                    }
                    
                    return RedirectToAction("Details", "Equipas", new { id = equipa.ID });
                }
                catch (Exception)
                {
                    // caso haja um erro deve ser enviada uma mensagem para o utilizador
                    ModelState.AddModelError("", string.Format("Ocorreu um erro com a edição dos dados da noticia {0}", equipa.Nome));
                }
            }
            return View(equipa);
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
    


