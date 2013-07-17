using System;
using System.Collections.Generic;
using System.Linq;

namespace HRServiceApp
{
    public class HRService : IHRService
    {
        public Employee GetEmployee(int id)
        {
            using (var context = new HRServiceContext())
            {
                var employee = (from p
                                in context.Employees
                                where p.EmployeeId == id
                                select p).FirstOrDefault();
                if (employee != null)
                    return employee;
                throw new Exception("Invalid employee id");
            }
        }
        public List<EmployeeSalary> GetAllEmployees()
        {
            using (var context = new HRServiceContext())
            {
                var employeeSalary = from p
                                         in context.Employees
                                     join t in context.Salaries on p.EmployeeId equals t.EmployeeId
                                     select
                                         new EmployeeSalary
                                         {
                                             EmployeeId = p.EmployeeId,
                                             EmailAddress = p.EmailAddress,
                                             FirstName = p.FirstName,
                                             LastName = p.LastName,
                                             SupervisorId = p.SupervisorId,
                                             Salary = t.SalaryValue
                                         };
                return employeeSalary.ToList();
            }
        }

        public bool InsertEmployee(EmployeeSalary employeeSalary)
        {
            using (var db = new HRServiceContext())
            {
                db.Employees.Add(MapToEmployee(employeeSalary));
                db.SaveChanges();
                return true;
            }
        }

        private Employee MapToEmployee(EmployeeSalary employeeSalary)
        {
            return new Employee
            {
                EmployeeId = employeeSalary.EmployeeId,
                EmailAddress = employeeSalary.EmailAddress,
                FirstName = employeeSalary.FirstName,
                LastName = employeeSalary.LastName,
                SupervisorId = employeeSalary.SupervisorId,
                Salary = new Salary { SalaryValue = employeeSalary.Salary }
            };
        }

        public int? GetEmployeeIdByName(string name)
        {
            var firstLastName = new List<string>();
            if (string.IsNullOrEmpty(name))
                return null;
            firstLastName.AddRange(name.Split(' '));
            if (firstLastName.Count < 2)
                return null;
            string firstName = firstLastName[0];
            string lastName = firstLastName[1];
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                using (var context = new HRServiceContext())
                {
                    var employee = (from p
                                        in context.Employees
                                    where p.FirstName.ToLower().Equals(firstName.ToLower()) && p.LastName.ToLower().Equals(lastName.ToLower()) 
                                    select p).FirstOrDefault();
                    if (employee != null)
                        return employee.EmployeeId;
                    return null;
                }
            }
            return null;
        }

        #region testing class
#if DEBUG
        public class TestHelperClass
        {
            private readonly IHRService _client;

            public TestHelperClass(IHRService client)
            {
                this._client = client;
            }

            public Employee CallGetEmployee(int id)
            {
                return _client.GetEmployee(id);
            }

            public bool CallInsertEmployee(EmployeeSalary product)
            {
                return _client.InsertEmployee(product);
            }

            public List<EmployeeSalary> CallAllAmployees()
            {
                return _client.GetAllEmployees();
            }

            public int? GetEmployeeIdByName(string name)
            {
                return _client.GetEmployeeIdByName(name);
            }
        }
#endif
        #endregion
    }
}
