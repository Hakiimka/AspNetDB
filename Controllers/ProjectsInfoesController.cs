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
    public class ProjectsInfoesController : Controller
    {
        private ProjectsDBContext db = new ProjectsDBContext();

        // GET: ProjectsInfoes
        public ActionResult Index()
        {
            var joined = from infos in db.Set<ProjectsInfoes>()
                         join project in db.Set<Projectss>()
                         on infos.ProjectId equals project.id
                         select new { infos, project };

            List<JoinedProjects> list = new List<JoinedProjects>();

            foreach(var u in joined)
            {
                list.Add(new JoinedProjects() { ProjectId= u.project.ProjectName,EmployeeId="2",ProjectDateEnd=DateTime.Now,ProjectDateStart=DateTime.Now,ProjectPriorityId="2" });
            }


            return View(db.ProjectsInfoes.ToList());
            //return View(list);
        }

        // GET: ProjectsInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsInfoes projectsInfoes = db.ProjectsInfoes.Find(id);
            if (projectsInfoes == null)
            {
                return HttpNotFound();
            }
            return View(projectsInfoes);
        }

        // GET: ProjectsInfoes/Create
        public ActionResult Create()
        {
            SelectList projects = new SelectList(db.Projectss, "Id", "ProjectName");
            SelectList employees = new SelectList(db.Employees, "Id", "Name");
            SelectList priorities = new SelectList(db.Priorities, "Id", "Priority");
            ViewBag.employees = employees;
            ViewBag.projects = projects;
            ViewBag.priorities = priorities;

            return View();
        }

        // POST: ProjectsInfoes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ProjectId,EmployeeId,ProjectDateStart,ProjectDateEnd,ProjectPriorityId")] ProjectsInfoes projectsInfoes)
        {
            if (ModelState.IsValid)
            {
                db.ProjectsInfoes.Add(projectsInfoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectsInfoes);
        }

        // GET: ProjectsInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsInfoes projectsInfoes = db.ProjectsInfoes.Find(id);
            if (projectsInfoes == null)
            {
                return HttpNotFound();
            }
            return View(projectsInfoes);
        }

        // POST: ProjectsInfoes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ProjectId,EmployeeId,ProjectDateStart,ProjectDateEnd,ProjectPriorityId")] ProjectsInfoes projectsInfoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectsInfoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectsInfoes);
        }

        // GET: ProjectsInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsInfoes projectsInfoes = db.ProjectsInfoes.Find(id);
            if (projectsInfoes == null)
            {
                return HttpNotFound();
            }
            return View(projectsInfoes);
        }

        // POST: ProjectsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectsInfoes projectsInfoes = db.ProjectsInfoes.Find(id);
            db.ProjectsInfoes.Remove(projectsInfoes);
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
