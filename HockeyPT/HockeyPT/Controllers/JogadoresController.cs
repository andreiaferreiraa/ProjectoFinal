﻿using System;
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
    public class JogadoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jogadores
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var listaDeJogadores = db.Jogadores.OrderBy(j => j.ID).ToList();
            return View(listaDeJogadores);
        }
        //***************************************************DETAILS*************************************************************
        // GET: Jogadores/Details/5
        /// <summary>
        /// Apresenta os detalhes de um jogador
        /// </summary>
        /// <param name="id">apresenta a PK que identifica o Jogador</param>
        /// <returns></returns>
        //[Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            //protege a execução do método contra a não existência de valores nulos
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }

            //vai procurar o jogador cujo ID foi fornecido
            Jogadores jogadores = db.Jogadores.Find(id);

            //se esse jogador não for encontrado
            if (jogadores == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            
            //envia para a View os dados do Jogador
            return View(jogadores);
        }

        //*************************************************************CREATE***************************************************
        // GET: Jogadores/Create
        /// <summary>
        /// GET: Jogadores/Create
        /// </summary>
        /// <param name="EquipaFK"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrador")]
        public ActionResult Create(int EquipaFK)
        {
            ViewBag.EquipaPK = new SelectList(db.Equipas, "ID", "Nome");
            Session["EquipaFK"] = EquipaFK;
            return View();
        }


        // POST: Jogadores/Create
        /// <summary>
        /// Método que permite criar um jogador e enviar para o servidor
        /// </summary>
        /// <param name="jogadores"></param>
        /// <param name="carregaFotografia"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "Nome,Posicao,DataNascimento,Nacionalidade,Altura,Peso,Fotografia")] Jogadores jogadores,
                                    HttpPostedFileBase carregaFotografia){
            //determinar o ID do novo Jogador
            int novoIDJogador = 0;
            //determinar o numero de Jogadores na tabela
            //caso a tabela dos jogadores esteja vazia
            if (db.Jogadores.Count() == 0)
            {
                //o ID no novo jogador será 1
                novoIDJogador = 1;
            }
            //caso a tabela contenha jogadores
            else
            {
                //o novo ID sera o numero maximo do ID existente + 1
                novoIDJogador = db.Jogadores.Max(j => j.ID) + 1;
            }
            //atribuição do novo ID ao jogador
            jogadores.ID = novoIDJogador;
            //atribuiçao da EquipaFK ao jogador
            jogadores.EquipaPK = (int)Session["EquipaFK"];
            string nomeFotografia = "Jogadores_" + novoIDJogador + ".jpg";
            string caminhoFotografia = "";      

            if (carregaFotografia != null)
            {
                //Verificar se o ficheiro é uma imagem
                if (carregaFotografia.ContentType.Contains("image"))
                {
                    //Definir o nome da Capa
                    jogadores.Fotografia = nomeFotografia;
                    //guardar na variavel auxiliar o caminho para onde guardar a imagem
                    caminhoFotografia = Path.Combine(Server.MapPath("~/JogadoresFotos/"), nomeFotografia); // indica onde a imagem será guardada
                }
                else
                {
                    ModelState.AddModelError("", "O ficheiro inserido não é nenhuma imagem!");
                }

            }
            //ficheiro nao inserido
            else
            {
                //gerar mensagem de erro para indicar o utilizador que nao foi inserida nenhuma imagem
                ModelState.AddModelError("", "Não foi inserida uma imagem");
                //redirecionar o utilizador para a View
                return View(jogadores);

            }

            //ModelSatete.IsValid -> confronta os dados fornecidos com o modelo
            //se nao respeitar as regra dos modelo, rejeita os dados
            if (ModelState.IsValid)
            {
                try
                {
                    //adiciona na estrutura de dados, na memoria do servidor, o objeto Jogadores
                    db.Jogadores.Add(jogadores);
                    //faz commit na base de dados
                    db.SaveChanges();
                    //guarda a imagem no disco rigido
                    carregaFotografia.SaveAs(caminhoFotografia);
                    //redireciona o utilizador para a pagina inicial
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    //gera uma mensagem de erro para o utilizador
                    ModelState.AddModelError("", "Ocorreu um erro na criação de um jogador ");
                }
            }

            ViewBag.EquipaPK = new SelectList(db.Equipas, "ID", "Nome");
            return View(jogadores);
        }

        //*****************************************************EDIT******************************************************
        // GET: Jogadores/Edit/5
        /// <summary>
        /// GET: Jogadores/Edit/5
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
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            ViewBag.EquipaPK = new SelectList(db.Equipas, "ID", "Nome", jogadores.EquipaPK);
            return View(jogadores);
        }

        // POST: Jogadores/Edit/5
        /// <summary>
        /// Método que permite editar um jogador
        /// </summary>
        /// <param name="jogador"></param>
        /// <param name="ficheiroFotografiaJogador"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "ID,Nome,Posicao,DataNascimento,Nacionalidade,Altura,Peso,Fotografia,EquipaPK")] Jogadores jogador,
                                 HttpPostedFileBase ficheiroFotografiaJogador)
        {
            //variaveis auxiliares
            string novoNome = "";
            string nomeAntigo = "";
            DateTime dataAtual = DateTime.Now;

            //try
            //{
                //caso a data de nascimento seja maior que a atual
                if (jogador.DataNascimento >= dataAtual)
                {
                    ModelState.AddModelError("", "Erro na data de nascimento!");
                    return View(jogador);
               }


            if (ModelState.IsValid)
            {
                try
                {
                    if (ficheiroFotografiaJogador != null)
                    {
                        if (ficheiroFotografiaJogador.ContentType.Contains("image/"))
                        {
                            nomeAntigo = jogador.Fotografia;
                            novoNome = "Jogador_" + jogador.ID + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetExtension(ficheiroFotografiaJogador.FileName).ToLower(); ;
                            jogador.Fotografia = novoNome;
                            ficheiroFotografiaJogador.SaveAs(Path.Combine(Server.MapPath("~/JogadoresFotos/"), novoNome));
                        }
                        else
                        {
                            ModelState.AddModelError("", "Erro ao inserir imagem, ficheiro não é uma imagem!");
                            return View(jogador);
                        }
                    }

                    db.Entry(jogador).State = EntityState.Modified;
                    db.SaveChanges();

                    if (ficheiroFotografiaJogador != null && ficheiroFotografiaJogador.ContentType.Contains("/image"))
                    {
                       System.IO.File.Delete(Path.Combine(Server.MapPath("~/JogadoresFotos/"), nomeAntigo));
                    }

                    return RedirectToAction("Details", "Equipas", new { id = jogador.EquipaPK });
                }
                catch (Exception)
                {
                    // caso haja um erro deve ser enviada uma mensagem para o utilizador
                    ModelState.AddModelError("", string.Format("Ocorreu um erro com a edição dos dados do jogador {0}", jogador.Nome));
                }
            }
            return View(jogador);
        }



        //***********************************************************DELETE**********************************************
        // GET: Jogadores/Delete/5
        /// <summary>
        /// GET: Jogadores/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return RedirectToAction("Index");
            }
            Jogadores jogadores = db.Jogadores.Find(id);
            if (jogadores == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Index");
            }
            return View(jogadores);
        }

        // POST: Jogadores/Delete/5
        /// <summary>
        /// Método que permite eliminar um jogador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogadores jogadores = db.Jogadores.Find(id);
            try
            {
                //remover o jogador da memoria
                db.Jogadores.Remove(jogadores);
                //commit na base de dados
                db.SaveChanges();
                //redirecionar para a pagina inicial
                return RedirectToAction("Details", "Equipas", new { id = jogadores.EquipaPK });
            }
            catch (Exception)
            {
                //gerar uma mensagem de erro a ser apresentada ao utilizador
                ModelState.AddModelError("", "Nao foi possivel remover ");
            }

            //reenvia os dados para a view
            return View(jogadores);
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
