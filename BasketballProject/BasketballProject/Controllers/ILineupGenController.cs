using BasketballProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasketballProject.Controllers
{
    public class ILineupGenController : Controller
    {
        private BasketballEntities db = new BasketballEntities();

        // GET: LineupGenerator
        public ActionResult Index()
        {
            ILineupGenModel Glineup = new ILineupGenModel();            

            var PG1 = from a in db.ImportPlayers
                      where a.Position == "PG"
                      select a;

            Glineup.Player1 = PG1.OrderByDescending(item => item.Salary).First();

            var PG2 = from a in db.ImportPlayers
                      where a.Position == "PG" && a.Id != Glineup.Player1.Id
                      select a;

            Glineup.Player2 = PG2.OrderByDescending(item => item.Salary).First();

            var SG1 = from a in db.ImportPlayers
                      where a.Position == "SG"
                      select a;

            Glineup.Player3 = SG1.OrderByDescending(item => item.Salary).First();

            var SG2 = from a in db.ImportPlayers
                      where a.Position == "SG" && a.Id != Glineup.Player3.Id
                      select a;

            Glineup.Player4 = SG2.OrderByDescending(item => item.Salary).First();

            var SF1 = from a in db.ImportPlayers
                      where a.Position == "SF"
                      select a;

            Glineup.Player5 = SF1.OrderByDescending(item => item.Salary).First();

            var SF2 = from a in db.ImportPlayers
                      where a.Position == "SF" && a.Id != Glineup.Player5.Id
                      select a;

            Glineup.Player6 = SF2.OrderByDescending(item => item.Salary).First();

            var PF1 = from a in db.ImportPlayers
                      where a.Position == "PF"
                      select a;

            Glineup.Player7 = PF1.OrderByDescending(item => item.Salary).First();

            var PF2 = from a in db.ImportPlayers
                      where a.Position == "PF" && a.Id != Glineup.Player7.Id
                      select a;

            Glineup.Player8 = PF2.OrderByDescending(item => item.Salary).First();

            var C = from a in db.ImportPlayers
                    where a.Position == "C"
                    select a;

            Glineup.Player9 = C.OrderByDescending(item => item.Salary).First();

            IUtils.FixITeamS(ref Glineup);
            //IUtils.FixITeamF(ref Glineup);

            return View(Glineup);
        }
    }
}