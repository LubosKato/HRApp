using System.Collections.Generic;
using HRWebClient.HRService;

namespace HRWebClient.Models
{
    public class HRModel
    {
        public List<Supervisor> Supervisors;

        public class Supervisor
        {
            public int? SupervisorId { get; set; }
            public string Name { get; set; }
            public List<EmployeeSalary> employees;
        }

        public HRModel()
        {
            Supervisors = new List<Supervisor>();
        }
    }
}