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
using PagedList;
using PagedList.Mvc;
namespace HockeyPT.Controllers
{

    public class NoticiasController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Noticias
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 6;
            return View(db.Noticias.OrderByDescending(x => x.ID).ToPagedList(pageNumber, pageSize));

        }
        public ActionResult Sobre()
        {
            return View();
        }
        //******************************************DETAILS*******************************************************
        // GET: Noticias/Details/5
        /// <summary>
        /// Método que apresentar os detalhes das equipas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            comentario.UtilizadorPK = db.Utilizadores.Where(model => model.Username == User.Identity.Name).FirstOrDefault().ID;

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
        /// <summary>
        /// GET: Noticias/Create
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrador, Moderador")]
        public ActionResult Create()
        {
            ViewBag.listaEquipas = db.Equipas.ToList();
            return View();
        }

        // POST: Noticias/Create
        /// <summary>
        /// Método que permite criar uma notícia
        /// </summary>
        /// <param name="noticias"></param>
        /// <param name="ficheiroFotoNoticia"></param>
        /// <param name="checkBoxEquipas"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Titulo,Conteudo,Fotografia")] Noticias noticias,
                            HttpPostedFileBase ficheiroFotoNoticia,
                            string[] checkBoxEquipas)
        {
            var idNovaNoticia = 0;
            ViewBag.listaEquipas = db.Equipas.ToList();
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

            string nomeCapa = "Noticia" + noticias.ID + ".jpg";
            string caminhoFotografia = "";


            //verificar se chega efetivamente um ficheiro ao servidor
            if (ficheiroFotoNoticia != null)
            {
                //verifica se o ficheiro é uma imagem
                if (ficheiroFotoNoticia.ContentType.Contains("image"))
                {
                    //definir o nome da foto
                    noticias.Fotografia = nomeCapa;
                    //guardar na variavel auxiliar o caminho para onde guardar a imagem
                    caminhoFotografia = Path.Combine(Server.MapPath("~/NoticiasFotos/"), nomeCapa);
                }

            }
            //não foi inserido nenhum ficheiro 
            else
            {
                //gera mensagem de erro
                ModelState.AddModelError("", "Não foi inserida uma imagem");
                //redirecionar o utilizador para a View
                return View(noticias);
            }


            //verificar a lista de equipas
            if (checkBoxEquipas != null)
            {
                for (var i = 0; i < checkBoxEquipas.Length; i++)
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
            noticias.UtilizadorPK = db.Utilizadores.Where(cc => cc.Username.Equals(User.Identity.Name)).FirstOrDefault().ID;
            noticias.IsVisible = true;
            //ModelSatete.IsValid -> confronta os dados fornecidos com o modelo
            //se nao respeitar as regra dos modelo, rejeita os dados
            try
            {
                if (ModelState.IsValid)
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
            }
            catch (Exception e)
            {
                //gera uma mensagem de erro para o utilizador
                ModelState.AddModelError("", "Ocorreu um erro na criação de uma noticia ");
                return RedirectToAction("Index");
            }

            //ViewBag.listaEquipas = db.Equipas.ToList();
            return View(noticias);
        }

        //************************************************EDIT************************************************
        // GET: Noticias/Edit/5
        /// <summary>
        ///  GET: Noticias/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Método que permite editar uma notícia
        /// </summary>
        /// <param name="formulario"></param>
        /// <param name="carregaFotoNoticia"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador, Moderador")]
        public ActionResult Edit(FormCollection formulario,
                            HttpPostedFileBase carregaFotoNoticia)
        {
            Noticias noticia = db.Noticias.Find((int)Session["id"]);
            //preencher os campos da noticia com os campos do formulário
            noticia.Titulo = formulario["Titulo"];
            noticia.Conteudo = formulario["Conteudo"];

            //Preencher a data com o dia em que a noticia foi alterada
            noticia.Data = DateTime.Now;

            // preencher o autor com o utilizador que está autenticado
            var idUtilizador = db.Utilizadores.Where(d => d.Username == User.Identity.Name).FirstOrDefault();
            noticia.UtilizadorPK = idUtilizador.ID;

            //variaveis auxiliares para tratamento da Foto
            string caminhoNoticia = "";
            string nomeAntigo = formulario["Fotografia"];
            //verificação se foi inserido algum ficheiro
            if (carregaFotoNoticia != null)
            {
                string nomeFotografia = "Noticia" + noticia.ID + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + Path.GetExtension(carregaFotoNoticia.FileName).ToLower();
                //verificar se o ficheiro inserido é uma imagem
                if (carregaFotoNoticia.ContentType.Contains("image"))
                {
                    noticia.Fotografia = nomeFotografia;
                    caminhoNoticia = Path.Combine(Server.MapPath("~/NoticiasFotos/"), nomeFotografia);
                    carregaFotoNoticia.SaveAs(Path.Combine(Server.MapPath("~/NoticiasFotos/"), nomeFotografia));

                    //Apagar no disco a imagem
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/NoticiasFotos/"), nomeAntigo));
                }
            }
            //ficheiro nao inserido
            else
            {
                //definir a capa com o valor do formulario
                noticia.Fotografia = formulario["Fotografia"];
            }

            //criar uma lista auxiliar
            ICollection<Equipas> listaEquipa = new List<Equipas> { };

            //verificar se o as checkboxs sao diferentde null
            if (formulario["checkBoxEquipas"] != null)
            {
                //array auxiliar de checkbox's
                var arrayCheckBox = formulario["checkBoxEquipas"].Split(',');
                //percorrer as equipas todas
                foreach (var equipa in db.Equipas.ToList())
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

            try
            {
                if (ModelState.IsValid)
                {
                    //guardar os dados da Noticia
                    db.Entry(noticia).State = EntityState.Modified;
                    //efetuar o commit
                    db.SaveChanges();
                    //enviar os dados para a pagina inicial
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Não foi possivel concratizar a operação.");
            }

            return View(noticia);
        }


        //***************************************************DELETE************************************************

        // GET: Noticias/Delete/5
        /// <summary>
        /// GET: Noticias/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// método que permite apagar uma notícias
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
