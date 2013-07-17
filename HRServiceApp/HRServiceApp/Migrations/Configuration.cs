using System.Data.Entity.Migrations;

namespace HRServiceApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HRServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HRServiceContext context)
        {
            context.Employees.AddOrUpdate(new Employee()
            {
                EmailAddress = "ab@email.com",
                EmployeeId = 1,
                FirstName = "asd",
                LastName = "asd",
                SupervisorId = null
            });
            context.Employees.AddOrUpdate(new Employee()
            {
                EmailAddress = "ab1@email.com",
                EmployeeId = 2,
                FirstName = "asd1",
                LastName = "asd1",
                SupervisorId = 1
            });
            context.Salaries.AddOrUpdate(new Salary() { EmployeeId = 1, SalaryValue = 10000 });
            context.Salaries.AddOrUpdate(new Salary() { EmployeeId = 2, SalaryValue = 2000 });
        }
    }
}
