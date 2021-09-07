using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTest.Models
{
    public class JoinedProjects
    {
      public int Id { get; set; }
        public string ProjectId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime ProjectDateStart { get; set; }
        public DateTime ProjectDateEnd { get; set; }
        public string ProjectPriorityId { get; set; }
    }
}