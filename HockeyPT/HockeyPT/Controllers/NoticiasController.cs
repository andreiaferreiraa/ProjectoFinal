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
    
    public class NoticiasController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Noticias
        public ActionResult Index()
        {
            IEnumerable<Noticias> listaDeNoticias = db.Noticias.OrderBy(n => n.ID).ToList();
            return View(listaDeNoticias);

        }
        //******************************************DETAILS*******************************************************
        // GET: Noticias/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return RedirectToAction("Index");
            }
            return View(noticias);
        }

        //POST: Noticias/Detail/
        /// <summary>
        /// POST: Noticias/Details/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Moderador, UtilizadorLogado")]
        public ActionResult Details(int id, string ComentarioBox)
        {
            Comentarios comentario = new Comentarios();
            comentario.DataComentario = DateTime.Now;
            comentario.NoticiaPK = id;
            comentario.Texto = ComentarioBox;
            //permite ir buscar o id do utilizador que esta logado e que faz o comentario
            comentario.UtilizadorPK = db.Utilizadores.Where(model => model.Username==User.Identity.Name).FirstOrDefault().ID;

            if (comentario.Texto == "")
            {
                return RedirectToAction("Details");
            }

            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(comentario);

        }


        //**************************************CREATE***********************************************************
        // GET: Noticias/Create

        [Authorize(Roles = "Administrador, Moderador")]
        public ActionResult Create()
        {
            ViewBag.listaEquipas = db.Equipas.ToList();
            return View();
        }

        // POST: Noticias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Conteudo,Fotografia")] Noticias noticias,
                            HttpPostedFileBase ficheiroFotoNoticia, 
                            string[] checkBoxEquipas)
        {
            var idNovaNoticia = 0;

            if (db.Noticias.Count() == 0)
            {
                idNovaNoticia = 1;
            }
            else
            {
                idNovaNoticia = db.Noticias.Max(n => n.ID) + 1;
            }
            noticias.ID = idNovaNoticia;

            noticias.Data = DateTime.Now;

            string nomeFotografia = "Noticia" + idNovaNoticia + ".jpg";
            string caminhoFotografia = Path.Combine(Server.MapPath("~/NoticiasFotos/"), nomeFotografia); // indica onde a imagem será guardada

            var tipo = "";
            tipo = ficheiroFotoNoticia.ContentType;
            

            //verificar se chega efetivamente um ficheiro ao servidor
            if (ficheiroFotoNoticia != null)
            {
                //se chgeou, verficar se é uma fotografia
                if (tipo == "image/jpeg" || tipo == "image/jpg" || tipo == "image/png" || tipo == "image/bmp")
                {
                    //guardar o nome da imagem na base de dados
                    noticias.Fotografia = nomeFotografia;
                }
                else
                {
                    ModelState.AddModelError("", "Não foi fornecida nenhuma imagem"); //gera uma mensagem de erro
                }
                
            }
            else
            {
                //se nao ha imagem
                ModelState.AddModelError("", "Não foi fornecida nenhuma imagem"); //gera uma mensagem de erro
                //reenvia os dados para a view
                return View(noticias);
            }

            //verificar a lista de jogadores
            if (checkBoxEquipas != null)
            {
                for(var i=0; i < checkBoxEquipas.Length; i++)
                {
                    var x = db.Equipas.Find(Int32.Parse(checkBoxEquipas[i]));
                    noticias.ListaDeEquipas.Add(x);

                    x.ListaDeNoticias.Add(noticias);

                }
            }
            else
            {
                ModelState.AddModelError("", "Não foi fornecida nenhuma Equipa!");
                ViewBag.listaEquipas = db.Equipas.ToList();
                return View(noticias);
            }

            //ModelSatete.IsValid -> confronta os dados fornecidos com o modelo
            //se nao respeitar as regra dos modelo, rejeita os dados
            if (ModelState.IsValid)
            {
                try
                {
                    //adiciona na estrutura de dados, na memoria do servidor, o objeto Jogadores
                    db.Noticias.Add(noticias);
                    //faz commit na base de dados
                    db.SaveChanges();
                    //guarda a imagem no disco rigido
                    ficheiroFotoNoticia.SaveAs(caminhoFotografia);
                    //redireciona o utilizador para a pagina inicial
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    //gera uma mensagem de erro para o utilizador
                    ModelState.AddModelError("", "Ocorreu um erro na criação de uma noticia ");
                }
            }
            ViewBag.listaEquipas = db.Equipas.ToList();
            return View(noticias);
        }

        //************************************************EDIT************************************************
        // GET: Noticias/Edit/5
        [Authorize(Roles = "Administrador, Moderador")]
        public ActionResult Edit(int? id)
        {
            Session["id"] = id;
            ViewBag.listaEquipas = db.Equipas.ToList();
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return RedirectToAction("Index");
            }
            return View(noticias);
        }

        // POST: Noticias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Moderador")]
        public ActionResult Edit(FormCollection formulario,
                            HttpPostedFileBase carregaFotoNoticia)
        {
            string novoNome = "";
            string nomeAntigo = "";
            Noticias noticia = db.Noticias.Find((int)Session["id"]);
            noticia.Data = DateTime.Now;

            var tipo = "";
            tipo = carregaFotoNoticia.ContentType;

            if (ModelState.IsValid)
            {
                try
                {
                    //se a imagem nao for nula
                    if (carregaFotoNoticia != null)
                    {
                        //verificar se é mesmo uma imagem
                        if(tipo == "image/jpeg" || tipo=="image/jpg" || tipo=="image/png" || tipo== "image/bmp")
                        {
                            nomeAntigo = noticia.Fotografia;
                            novoNome = "Noticia" + noticia.ID + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetExtension(carregaFotoNoticia.FileName).ToLower(); ;
                            noticia.Fotografia = novoNome;
                            carregaFotoNoticia.SaveAs(Path.Combine(Server.MapPath("~/NoticiasFotos/"), novoNome));

                        }
                        //se não for uma imagem
                        else
                        {
                            //redireciona para o "Edit"
                            return RedirectToAction("Edit");
                        }
                    }
                    //preencher a noticia com os valores do formulario
                    noticia.Titulo = formulario["Titulo"];
                    noticia.Conteudo = formulario["Conteudo"];

                    //criar uma lista auxiliar
                    ICollection<Equipas> listaEquipa = new List<Equipas> { };

                    //verificar se o as checkboxs sao diferentde null
                    if (formulario["checkBoxEquipas"] != null)
                    {
                        //array auxiliar de checkbox's
                        var arrayCheckBox = formulario["checkBoxEquipas"].Split(',');
                        //percorrer as equipas todas
                        foreach(var equipa in db.Equipas.ToList())
                        {
                            //se o array das checkbox tem o id da equipa
                            if (arrayCheckBox.Contains(equipa.ID.ToString()))
                            {
                                //adicionar na lista auxiliar a equipa
                                listaEquipa.Add(equipa);
                                //verifcar se a equipa nao pertence aquela noticia
                                if (!equipa.ListaDeNoticias.Contains(noticia))
                                {
                                    equipa.ListaDeNoticias.Add(noticia);
                                }
                            }
                            else
                            {
                                //se a equipa pertecenr a noticia mas nao esteja true na checkbox
                                if (equipa.ListaDeNoticias.Contains(noticia))
                                {
                                    equipa.ListaDeNoticias.Remove(noticia);
                                }
                            }
                        }
                        noticia.ListaDeEquipas = listaEquipa;
                    }



                    db.Entry(noticia).State = EntityState.Modified;
                    db.SaveChanges();
                    if (carregaFotoNoticia != null)
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/NoticiasFotos/"), nomeAntigo));
                    
                    // enviar os dados para a página inicial
                    return RedirectToAction("Index");

                }
                catch(Exception)
                {
                    ModelState.AddModelError("", string.Format("Ocorreu um erro com a edição dos dados da noticia {0}", noticia.Titulo));
                }
                
            }
            return View(noticia);
        }

        //***************************************************DELETE************************************************

        // GET: Noticias/Delete/5
        [Authorize(Roles = "Administrador, Moderador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }

        // POST: Equipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Moderador")]
        public ActionResult DeleteConfirmed(int id)
        {
            //encontrar o id da noticia
            Noticias noticias = db.Noticias.Find(id);
            noticias.IsVisible = false;
            //remover a noticia das noticias
            var noticiasEquipas = noticias.ListaDeEquipas.ToList();

            for (var i = 0; i < noticiasEquipas.Count; i++)
            {
               var cadaEquipas = noticiasEquipas[i];
               var RemoveNoticia = cadaEquipas.ListaDeNoticias.Remove(noticias);
               
            }

            db.Entry(noticias).State = EntityState.Modified;
            db.SaveChanges();
                return RedirectToAction("Index");
        }
        
        public ActionResult NavEquipas()
        {
            IEnumerable<Equipas> listaDeEquipas = db.Equipas.OrderBy(n => n.ID).ToList();
            return PartialView(listaDeEquipas);

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
