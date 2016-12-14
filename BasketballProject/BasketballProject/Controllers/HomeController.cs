using BasketballProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasketballProject.Controllers
{
    public class HomeController : Controller
    {
        private BasketballEntities db = new BasketballEntities();

        public ActionResult Index()
        {

            ImportPlayerViewModel BP = new ImportPlayerViewModel();

            BP.ImPlayers = db.ImportPlayers.ToList();

            return View(BP);
        }

        public ActionResult SelectPlayer(string id)
        {
            ImportPlayer p = (from a in db.ImportPlayers
                              where a.Id == id
                              select a).FirstOrDefault();
            if (p.Played == "Locked")
            {
                p.Played = "";
            }
            else
            {
                p.Played = "Locked";
            }
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}