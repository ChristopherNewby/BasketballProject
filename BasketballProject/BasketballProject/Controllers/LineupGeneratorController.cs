using BasketballProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasketballProject.Controllers
{
    public class LineupGeneratorController : Controller
    {
        private BasketballEntities db = new BasketballEntities();

        // GET: LineupGenerator
        public ActionResult Index()
        {
            LineupGeneratorModel Glineup = new LineupGeneratorModel();

            var PG1 = from a in db.Players
                      where a.Position == 1
                      select a;

            Glineup.Player1 = PG1.OrderByDescending(item => item.Price).First();

            var PG2 = from a in db.Players
                      where a.Position == 1 && a.PlayerId != Glineup.Player1.PlayerId
                      select a;

            Glineup.Player2 = PG2.OrderByDescending(item => item.Price).First();

            var SG1 = from a in db.Players
                      where a.Position == 2
                      select a;

            Glineup.Player3 = SG1.OrderByDescending(item => item.Price).First();

            var SG2 = from a in db.Players
                      where a.Position == 2 && a.PlayerId != Glineup.Player3.PlayerId
                      select a;

            Glineup.Player4 = SG2.OrderByDescending(item => item.Price).First();

            var SF1 = from a in db.Players
                      where a.Position == 3
                      select a;

            Glineup.Player5 = SF1.OrderByDescending(item => item.Price).First();

            var SF2 = from a in db.Players
                      where a.Position == 3 && a.PlayerId != Glineup.Player5.PlayerId
                      select a;

            Glineup.Player6 = SF2.OrderByDescending(item => item.Price).First();

            var PF1 = from a in db.Players
                      where a.Position == 4
                      select a;

            Glineup.Player7 = PF1.OrderByDescending(item => item.Price).First();

            var PF2 = from a in db.Players
                      where a.Position == 4 && a.PlayerId != Glineup.Player7.PlayerId
                      select a;

            Glineup.Player8 = PF2.OrderByDescending(item => item.Price).First();

            var C = from a in db.Players
                    where a.Position == 5
                    select a;

            Glineup.Player9 = C.OrderByDescending(item => item.Price).First();

            Utils.FixTeam(ref Glineup);

            return View(Glineup);
        }
    }
}