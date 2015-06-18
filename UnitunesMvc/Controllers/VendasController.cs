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
    public class VendasController : Controller
    {
        private UnitunesEntities db = new UnitunesEntities();
        // GET: Vendas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contas/Details/5
        public ActionResult Details(int? id)
        {
            var usuario = new LoginViewModel().Buscar(User.Identity.Name);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var venda = db.Vendas.Where(x => x.Id == id && x.UsuarioId == usuario.Id).FirstOrDefault();
            
            if (venda != null)
            {
                ViewBag.Vendedor = db.Usuarios.Find(venda.Items.FirstOrDefault().Midia.AutorId).NomeCompleto;
                ViewBag.Comprador = usuario.NomeCompleto;
                ViewBag.Total = venda.Total;
                ViewBag.Data = venda.Data;
            }
            return View(venda.Items);
        }
    }
}