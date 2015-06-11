using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitunesMvc.Core.Database.Entities;

namespace UnitunesMvc.Controllers
{
    
    public class HomeController : Controller
    {
        private UnitunesEntities db = new UnitunesEntities();
        [Authorize]
        public ActionResult Index()
        {
            //db.feed();
            return View();
        }

        [HttpGet]
        public FileResult GetImage(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var intId = Convert.ToInt32(id);
                var item = db.Binarios.Where(file => file.Id == intId).FirstOrDefault();
                var ms = new System.IO.MemoryStream(item.Bytes);
                FileStreamResult result = new FileStreamResult(ms, "image/png");
                result.FileDownloadName = item.Id.ToString(); // or item.Id or something (3)
                return result;
            }

            return new FileStreamResult(new System.IO.MemoryStream(), "image/png");
        }
    }

    
}