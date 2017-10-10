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
    public class PROJECTController : Controller
    {
        private Entities db = new Entities();

        // GET: PROJECT
        public ActionResult Index()
        {
                var pROJECT = db.PROJECT.Include(p => p.USERS);
                return View(pROJECT.ToList());
        }

        // GET: PROJECT/Details/5
        public ActionResult Details(int? id)
        {
            //get model from database
            return PartialView(db.PROJECT.First(x => x.PROJECT_ID == id));
        }

        // GET: PROJECT/Create
        public ActionResult Create()
        {
            ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "USERS_ID");
            return View();
        }

        // POST: PROJECT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROJECT_ID,STARTING_DATE,FINAL_DATE,DESCRIPTIONS,PROJECT_NAME,LEADER_ID")] PROJECT pROJECT)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PROJECT.Add(pROJECT);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "USERS_ID", pROJECT.LEADER_ID);
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Forbidden_Action", "Delete"));
            }
            return View(pROJECT);
        }

        // GET: PROJECT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "ROLE_TYPE", pROJECT.LEADER_ID);
            return View(pROJECT);
        }

        // POST: PROJECT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROJECT_ID,STARTING_DATE,FINAL_DATE,DESCRIPTIONS,PROJECT_NAME,LEADER_ID")] PROJECT pROJECT)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(pROJECT).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.LEADER_ID = new SelectList(db.USERS, "USERS_ID", "ROLE_TYPE", pROJECT.LEADER_ID);
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Forbidden_Action", "Delete"));
            }
            return View(pROJECT);
        }

        // GET: PROJECT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        // POST: PROJECT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PROJECT pROJECT = db.PROJECT.Find(id);
                db.PROJECT.Remove(pROJECT);
                db.SaveChanges();
            }
            catch(Exception ex)
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
