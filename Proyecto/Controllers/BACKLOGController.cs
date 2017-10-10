using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Dolansoft.Controllers
{
    public class BACKLOGController : Controller
    {
        private Entities db = new Entities();

        // GET: BACKLOGs
        public ActionResult Index()
        {
            var bACKLOG = db.BACKLOG.Include(b => b.PROJECT);
            return View(bACKLOG.ToList());
        }

        // GET: BACKLOGs/Details/5
        public ActionResult Details(int? id)
        {
            return PartialView(db.BACKLOG.First(x => x.BACKLOG_ID == id));
        }

        // GET: BACKLOGs/Create
        public ActionResult Create()
        {
            ViewBag.PROJECT_ID = new SelectList(db.PROJECT, "PROJECT_ID", "DESCRIPTIONS");
            return View();
        }

        // POST: BACKLOGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BACKLOG_ID,PROJECT_ID")] BACKLOG bACKLOG)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.BACKLOG.Add(bACKLOG);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.PROJECT_ID = new SelectList(db.PROJECT, "PROJECT_ID", "DESCRIPTIONS", bACKLOG.PROJECT_ID);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Forbidden_Action", "Delete"));
            }
            return View(bACKLOG);
        }

        // GET: BACKLOGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACKLOG bACKLOG = db.BACKLOG.Find(id);
            if (bACKLOG == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROJECT_ID = new SelectList(db.PROJECT, "PROJECT_ID", "DESCRIPTIONS", bACKLOG.PROJECT_ID);
            return View(bACKLOG);
        }

        // POST: BACKLOGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BACKLOG_ID,PROJECT_ID")] BACKLOG bACKLOG)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bACKLOG).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.PROJECT_ID = new SelectList(db.PROJECT, "PROJECT_ID", "DESCRIPTIONS", bACKLOG.PROJECT_ID);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Forbidden_Action", "Delete"));
            }
            return View(bACKLOG);
        }

        // GET: BACKLOGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BACKLOG bACKLOG = db.BACKLOG.Find(id);
            if (bACKLOG == null)
            {
                return HttpNotFound();
            }
            return View(bACKLOG);
        }

        // POST: BACKLOGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
            BACKLOG bACKLOG = db.BACKLOG.Find(id);
            db.BACKLOG.Remove(bACKLOG);
            db.SaveChanges();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Forbidden_Action", "Delete"));
            }
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
