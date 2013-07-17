using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace HRServiceApp
{
    [ServiceContract]
    public interface IHRService
    {
        [OperationContract]
        Employee GetEmployee(int id);

        [OperationContract]
        bool InsertEmployee(EmployeeSalary employee);

        [OperationContract]
        List<EmployeeSalary> GetAllEmployees();

        [OperationContract]
        int? GetEmployeeIdByName(string name);
    }

    [Table("Employee")]
    [DataContract]
    public class Employee
    {
        [DataMember]
        [Key]
        public int EmployeeId { get; set; }
        [DataMember]
        public int? SupervisorId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [ForeignKey("EmployeeId")]
        public Salary Salary { get; set; }
    }

    [Table("Salary")]
    [DataContract]
    public class Salary
    {
        [DataMember]
        [Key]
        public int EmployeeId { get; set; }
        [DataMember]
        [Column("Salary")]
        public decimal SalaryValue { get; set; }
    }

    [DataContract]
    public class EmployeeSalary
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public int? SupervisorId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public decimal Salary { get; set; }
    }

    public class HRServiceContext : DbContext
    {
        public HRServiceContext() : base("name=MSSQL") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
    }
}
