using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitunesMvc.Models;

namespace UnitunesMvc.Controllers
{
    public class MusicaController : Controller
    {
        UnitunesEntities unitunesDb = new UnitunesEntities();
        // GET: Musica
        public ActionResult Index()
        {
            return View(unitunesDb.Albums.ToList());
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                unitunesDb.Albums.Add(album);
                unitunesDb.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(unitunesDb.Categorias , "GeneroId", "Name", album.GeneroId );
            ViewBag.ArtistId = new SelectList(unitunesDb.Autores, "AutorId", "Name", album.AutorId);
            return View(album);
        }

        public ActionResult Details(int id)
        {
            var album = unitunesDb.Albums.Find(id);
            return View(album);
        }
        
    }
}