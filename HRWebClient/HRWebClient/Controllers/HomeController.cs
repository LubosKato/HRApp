using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HRWebClient.HRService;
using HRWebClient.Models;

namespace HRWebClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var model = new HRModel();
            var service = new HRServiceClient();
            List<EmployeeSalary> employees = service.GetAllEmployees().ToList();
            var supervisorIds = (from p in employees
                                 join o in employees on p.EmployeeId equals o.SupervisorId
                                 select o.SupervisorId
                                ).Distinct().ToList();
            var supervisors = new List<HRModel.Supervisor>();
            foreach (var supervisorId in supervisorIds)
            {
                supervisors.AddRange(from p in employees
                                     where p.EmployeeId.Equals(supervisorId ?? 0)
                                     select new HRModel.Supervisor() {employees = new List<EmployeeSalary>(), Name = p.FirstName + " " + p.LastName, SupervisorId = supervisorId});
            }
            foreach (var supervisor in supervisors)
            {
                supervisor.employees.AddRange(from p in employees
                                              where p.SupervisorId.Equals(supervisor.SupervisorId)
                                              select
                                                  new EmployeeSalary {FirstName = p.FirstName, LastName = p.LastName, EmailAddress = p.EmailAddress, Salary = p.Salary});
            }
            model.Supervisors = supervisors;

            return View(model);
        }
    }
}
