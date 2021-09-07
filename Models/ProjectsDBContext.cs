using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SibersTest.Models
{
    public class ProjectsDBContext : DbContext
    {
        public ProjectsDBContext() : base("ProjectsDBEntities")
        {

        }
        
        public DbSet<Projectss> Projectss { get; set; }
      
        public DbSet<Employees> Employees { get; set; }

        public DbSet<ProjectsInfoes> ProjectsInfoes { get; set; }
        public DbSet<Priorities> Priorities { get; set; }
    }
}