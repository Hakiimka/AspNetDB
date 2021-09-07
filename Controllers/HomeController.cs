using SibersTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTest.Controllers
{
    public class HomeController : Controller
    {
        private ProjectsDBContext db = new ProjectsDBContext();
        public ActionResult Index()
        {
            var joined = from infos in db.Set<ProjectsInfoes>()
                         join project in db.Set<Projectss>()
                         on infos.ProjectId equals project.id
                         join employee in db.Set<Employees>()
                         on infos.EmployeeId equals employee.id
                         join priority in db.Set<Priorities>()
                         on infos.ProjectPriorityId equals priority.id
                         

                         select new { infos, project,employee,priority };

            List<JoinedProjects> list = new List<JoinedProjects>();

            foreach (var u in joined)
            {
                list.Add(new JoinedProjects() { ProjectId = u.project.ProjectName, EmployeeId = u.employee.Name+" "+ u.employee.Surname+" "+ u.employee.SecondName
                    , ProjectDateEnd = u.infos.ProjectDateEnd, ProjectDateStart = u.infos.ProjectDateStart, 
                    ProjectPriorityId = u.priority.Priority });
            }
            ViewBag.Projects = list;
            ViewBag.List = list.ToArray();
            return View(list);
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