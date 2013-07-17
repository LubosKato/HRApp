using System.Collections.Generic;
using HRServiceApp;
using NUnit.Framework;

namespace HRServiceAppTests
{
    [TestFixture]
    public class TestBaseSetup
    {
        protected IHRService Service;
        protected EmployeeSalary FakeEmployeeSalary;
        protected List<EmployeeSalary> FakeEmployeeList;
        protected Employee FakeEmployee;
        protected Salary FakeSalary;

        [SetUp]
        public virtual void TestSetup()
        {
            Service = new HRService();
            FakeEmployeeSalary = new EmployeeSalary()
            {
                EmailAddress = "ab@email.com",
                EmployeeId = 1,
                FirstName = "asd",
                LastName = "asd",
                SupervisorId = null,
                Salary = 2000
            };
            

            FakeEmployee = new Employee()
            {
                EmailAddress = "ab@email.com",
                EmployeeId = 1,
                FirstName = "asd",
                LastName = "asd",
                SupervisorId = null
            };

            FakeEmployeeList = new List<EmployeeSalary>
                                   {
                                       FakeEmployeeSalary,
                                       new EmployeeSalary()
                                           {
                                               EmailAddress = "ab1@email.com",
                                               EmployeeId = 2,
                                               FirstName = "asd1",
                                               LastName = "asd1",
                                               SupervisorId = 1,
                                               Salary = 3000
                                           }
                                   };

            FakeSalary = new Salary() { EmployeeId = 1, SalaryValue = 2000 };
            FakeSalary = new Salary() { EmployeeId = 2, SalaryValue = 3000 };
        } 
    }
}