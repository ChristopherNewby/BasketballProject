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