using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SibersTest.Models;

namespace SibersTest.Controllers
{
    public class ProjectssesController : Controller
    {
        private ProjectsDBContext db = new ProjectsDBContext();

        // GET: Projectsses
        public ActionResult Index()
        {
            return View(db.Projectss.ToList());
        }

        // GET: Projectsses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projectss projectss = db.Projectss.Find(id);
            if (projectss == null)
            {
                return HttpNotFound();
            }
            return View(projectss);
        }

        // GET: Projectsses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projectsses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ProjectName")] Projectss projectss)
        {
            if (ModelState.IsValid)
            {
                db.Projectss.Add(projectss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectss);
        }

        // GET: Projectsses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projectss projectss = db.Projectss.Find(id);
            if (projectss == null)
            {
                return HttpNotFound();
            }
            return View(projectss);
        }

        // POST: Projectsses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ProjectName")] Projectss projectss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectss);
        }

        // GET: Projectsses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projectss projectss = db.Projectss.Find(id);
            if (projectss == null)
            {
                return HttpNotFound();
            }
            return View(projectss);
        }

        // POST: Projectsses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projectss projectss = db.Projectss.Find(id);
            db.Projectss.Remove(projectss);
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
