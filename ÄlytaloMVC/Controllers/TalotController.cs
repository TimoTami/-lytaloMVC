using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ÄlytaloMVC.Models;

namespace ÄlytaloMVC.Controllers
{
    public class TalotController : Controller
    {
        private ÄlytaloEntities db = new ÄlytaloEntities();

        // GET: Talot
        public ActionResult Index()
        {
            var talo = db.Talo.Include(t => t.Sauna).Include(t => t.TaloLampo).Include(t => t.Valo);
            return View(talo.ToList());
        }

        // GET: Talot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            return View(talo);
        }

        // GET: Talot/Create
        public ActionResult Create()
        {
            
            //ViewBag.SaunaID = new SelectList(db.Sauna, "SaunaID", "SaunanNimi");
            //ViewBag.TaloLampoID = new SelectList(db.TaloLampo, "TaloLampoID", "HuoneenNimi");
            //ViewBag.ValoID = new SelectList(db.Valo, "ValoID", "ValonNimi");
            return View();
        }


        // POST: Talot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaloID,TalonNimi")] Talo talo)
        {
            if (ModelState.IsValid)
            {
                db.Talo.Add(talo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.SaunaID = new SelectList(db.Sauna, "SaunaID", "SaunanNimi", talo.SaunaID);
            //ViewBag.TaloLampoID = new SelectList(db.TaloLampo, "TaloLampoID", "HuoneenNimi", talo.TaloLampoID);
            //ViewBag.ValoID = new SelectList(db.Valo, "ValoID", "ValonNimi", talo.ValoID);
            return View(talo);
        }
        // GET: Talot/Create
        public ActionResult UusiSauna()
        {
            ViewBag.TaloID = new SelectList(db.Talo, "TaloID", "TalonNimi");
            //ViewBag.SaunaID = new SelectList(db.Sauna, "SaunaID", "SaunanNimi");
            //ViewBag.TaloLampoID = new SelectList(db.TaloLampo, "TaloLampoID", "HuoneenNimi");
            //ViewBag.ValoID = new SelectList(db.Valo, "ValoID", "ValonNimi");
            return View();
        }


        // POST: Talot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UusiSauna([Bind(Include = "SaunaID,SaunanNimi,SaunanTila,SaunanNykyLampotila,TaloID")] Sauna sauna)
        {
            
            if (ModelState.IsValid)
            {
                db.Sauna.Add(sauna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaloID = new SelectList(db.Talo, "TaloID", "TalonNimi", sauna.TaloID);

            //ViewBag.SaunaID = new SelectList(db.Sauna, "SaunaID", "SaunanNimi", talo.SaunaID);
            //ViewBag.TaloLampoID = new SelectList(db.TaloLampo, "TaloLampoID", "HuoneenNimi", talo.TaloLampoID);
            //ViewBag.ValoID = new SelectList(db.Valo, "ValoID", "ValonNimi", talo.ValoID);
            return View(sauna);
        }

        // GET: Talot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            ViewBag.SaunaID = new SelectList(db.Sauna, "SaunaID", "SaunanNimi", talo.SaunaID);
            ViewBag.TaloLampoID = new SelectList(db.TaloLampo, "TaloLampoID", "HuoneenNimi", talo.TaloLampoID);
            ViewBag.ValoID = new SelectList(db.Valo, "ValoID", "ValonNimi", talo.ValoID);
            return View(talo);
        }

        // POST: Talot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaloID,SaunaID,SaunanNimi,TaloLampoID,HuoneenNimi,ValoID,ValonNimi")] Talo talo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SaunaID = new SelectList(db.Sauna, "SaunaID", "SaunanNimi", talo.SaunaID);
            ViewBag.TaloLampoID = new SelectList(db.TaloLampo, "TaloLampoID", "HuoneenNimi", talo.TaloLampoID);
            ViewBag.ValoID = new SelectList(db.Valo, "ValoID", "ValonNimi", talo.ValoID);
            return View(talo);
        }

        // GET: Talot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            return View(talo);
        }

        // POST: Talot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talo talo = db.Talo.Find(id);
            db.Talo.Remove(talo);
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
