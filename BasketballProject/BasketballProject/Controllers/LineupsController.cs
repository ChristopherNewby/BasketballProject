using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasketballProject;
using BasketballProject.Models;

namespace BasketballProject.Controllers
{
    public class LineupsController : Controller
    {
        private BasketballEntities db = new BasketballEntities();

        // GET: Lineups
        public ActionResult Index()
        {
            var lineups = db.Lineups.Include(l => l.Player).Include(l => l.Player10).Include(l => l.Player11).Include(l => l.Player12).Include(l => l.Player13).Include(l => l.Player14).Include(l => l.Player15).Include(l => l.Player16).Include(l => l.Player17);
            return View(lineups.ToList());
        }

        // GET: Lineups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lineup lineup = db.Lineups.Find(id);
            if (lineup == null)
            {
                return HttpNotFound();
            }
            return View(lineup);
        }

        // GET: Lineups/Create
        public ActionResult Create()
        {
            
            LineupSelectionViewModel Options = new LineupSelectionViewModel();

            Utils.Query(ref Options);

            return View(Options);

        }

        // POST: Lineups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineupID,Player1,Player2,Player3,Player4,Player5,Player6,Player7,Player8,Player9")] Lineup lineup)
        {
            if (ModelState.IsValid)
            {
                db.Lineups.Add(lineup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Player1 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player1);
            ViewBag.Player2 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player2);
            ViewBag.Player3 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player3);
            ViewBag.Player4 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player4);
            ViewBag.Player5 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player5);
            ViewBag.Player6 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player6);
            ViewBag.Player7 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player7);
            ViewBag.Player8 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player8);
            ViewBag.Player9 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player9);
            return View(lineup);
        }

        // GET: Lineups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lineup lineup = db.Lineups.Find(id);
            if (lineup == null)
            {
                return HttpNotFound();
            }
            ViewBag.Player1 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player1);
            ViewBag.Player2 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player2);
            ViewBag.Player3 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player3);
            ViewBag.Player4 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player4);
            ViewBag.Player5 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player5);
            ViewBag.Player6 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player6);
            ViewBag.Player7 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player7);
            ViewBag.Player8 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player8);
            ViewBag.Player9 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player9);
            return View(lineup);
        }

        // POST: Lineups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineupID,Player1,Player2,Player3,Player4,Player5,Player6,Player7,Player8,Player9")] Lineup lineup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Player1 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player1);
            ViewBag.Player2 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player2);
            ViewBag.Player3 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player3);
            ViewBag.Player4 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player4);
            ViewBag.Player5 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player5);
            ViewBag.Player6 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player6);
            ViewBag.Player7 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player7);
            ViewBag.Player8 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player8);
            ViewBag.Player9 = new SelectList(db.Players, "PlayerId", "Name", lineup.Player9);
            return View(lineup);
        }

        // GET: Lineups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lineup lineup = db.Lineups.Find(id);
            if (lineup == null)
            {
                return HttpNotFound();
            }
            return View(lineup);
        }

        // POST: Lineups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lineup lineup = db.Lineups.Find(id);
            db.Lineups.Remove(lineup);
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

