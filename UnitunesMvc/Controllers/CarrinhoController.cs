using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnitunesMvc.Core.Database.Entities;
using UnitunesMvc.Models;
using UnitunesMvc.Helpers;

namespace UnitunesMvc.Controllers
{
    public class CarrinhoController : Controller
    {
        private UnitunesEntities db = new UnitunesEntities();
        // GET: Carrinho
        public ActionResult Index()
        {
            var usuario = new LoginViewModel().Buscar(User.Identity.Name);
            var car = from c in db.Carrinhos.Include(x => x.Items) where c.UsuarioId == usuario.Id select c;
            var items = car.FirstOrDefault().Items.ToList();
            return View(items);
        }

        public ActionResult Add(int? id)
        {
            var usuario = new LoginViewModel().Buscar(User.Identity.Name);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carrinho = db.Carrinhos.Where(x => x.UsuarioId == usuario.Id).Include(c => c.Items).FirstOrDefault();

            if (carrinho == null)
            {
                carrinho = new Carrinho() { UsuarioId = usuario.Id };
                db.Carrinhos.Add(carrinho);
            }
            var itemCarrinho = carrinho.Items.Where(x => x.MidiaId == id).FirstOrDefault();

            if (itemCarrinho != null)
            {
                carrinho.Items.Remove(itemCarrinho);
                db.SaveChanges();
            }

            itemCarrinho = new CarrinhoItem() {MidiaId = (int)id };

            carrinho.Items.Add(itemCarrinho);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}