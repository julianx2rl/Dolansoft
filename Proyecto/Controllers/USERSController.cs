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
    public class USERSController : Controller
    {
        private Entities db = new Entities();

        // GET: USERS
        public ActionResult Index()
        {
            var uSERS = db.USERS.Include(u => u.PROJECT1).Include(u => u.ROLES);
            return View(uSERS.ToList());
        }

        // GET: USERS/Details/5
        public ActionResult Details(int? id)
        {
            //get model from database
            return PartialView(db.USERS.First(x => x.USERS_ID == id));
        }

        // GET: USERS/Create
        public ActionResult Create()
        {
            ViewBag.PROJECT_ID = new SelectList(db.PROJECT, "PROJECT_ID", "PROJECT_ID");
            ViewBag.ROLE_TYPE = new SelectList(db.ROLES, "ROLE_TYPE", "ROLE_TYPE");
            return View();
        }

        // POST: USERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USERS_ID,ROLE_TYPE,EMAIL,USERNAME,SURNAME,LASTNAME,PASSWORDS,PROJECT_ID")] USERS uSERS)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.USERS.Add(uSERS);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.PROJECT_ID = new SelectList(db.PROJECT, "PROJECT_ID", "DESCRIPTIONS", uSERS.PROJECT_ID);
                ViewBag.ROLE_TYPE = new SelectList(db.ROLES, "ROLE_TYPE", "ROLE_TYPE", uSERS.ROLE_TYPE);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Forbidden_Action", "Delete"));
            }
            return View(uSERS);
        }

        // GET: USERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROJECT_ID = new SelectList(db.PROJECT, "PROJECT_ID", "PROJECT_ID", uSERS.PROJECT_ID);
            ViewBag.ROLE_TYPE = new SelectList(db.ROLES, "ROLE_TYPE", "ROLE_TYPE", uSERS.ROLE_TYPE);
            return View(uSERS);
        }

        // POST: USERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USERS_ID,ROLE_TYPE,EMAIL,USERNAME,SURNAME,LASTNAME,PASSWORDS,PROJECT_ID")] USERS uSERS)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(uSERS).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.PROJECT_ID = new SelectList(db.PROJECT, "PROJECT_ID", "PROJECT_ID", uSERS.PROJECT_ID);
                ViewBag.ROLE_TYPE = new SelectList(db.ROLES, "ROLE_TYPE", "ROLE_TYPE", uSERS.ROLE_TYPE);
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Forbidden_Action", "Delete"));
            }
            return View(uSERS);
        }

        // GET: USERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return HttpNotFound();
            }
            return View(uSERS);
        }

        // POST: USERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                USERS uSERS = db.USERS.Find(id);
                db.USERS.Remove(uSERS);
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
