using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnitunesMvc.Core.Database.Entities;

namespace UnitunesMvc.Controllers
{
    public class PodcastsController : Controller
    {
        private UnitunesEntities db = new UnitunesEntities();

        // GET: Podcasts
        public ActionResult Index()
        {
            var podcasts = db.Streamings.Where(
                podcast => podcast.Tipo == TipoStreaming.Podcast);
            return View(podcasts.ToList());
        }

        // GET: Podcasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Streaming streaming = db.Streamings.Find(id);
            if (streaming == null)
            {
                return HttpNotFound();
            }
            return View(streaming);
        }

        // GET: Podcasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Podcasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Duracao,Tipo,Nome,Descricao,Preco,Imagem,Conteudo")] Streaming streaming)
        {
            streaming.Tipo = TipoStreaming.Podcast;
            if (ModelState.IsValid)
            {
                db.Streamings.Add(streaming);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(streaming);
        }

        // GET: Podcasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Streaming streaming = db.Streamings.Find(id);
            if (streaming == null)
            {
                return HttpNotFound();
            }
            return View(streaming);
        }

        // POST: Podcasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Duracao,Tipo,Nome,Descricao,Preco,Imagem,Conteudo")] Streaming streaming)
        {
            if (ModelState.IsValid)
            {
                db.Entry(streaming).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(streaming);
        }

        // GET: Podcasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Streaming streaming = db.Streamings.Find(id);
            if (streaming == null)
            {
                return HttpNotFound();
            }
            return View(streaming);
        }

        // POST: Podcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Streaming streaming = db.Streamings.Find(id);
            db.Streamings.Remove(streaming);
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
