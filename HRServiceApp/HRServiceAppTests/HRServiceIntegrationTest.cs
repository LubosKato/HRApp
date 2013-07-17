using NUnit.Framework;

namespace HRServiceAppTests
{
    [TestFixture]
    public class HRServiceIntegrationTest : TestBaseSetup
    {
        [Test]
        public void TestGetEmployee()
        {
            Assert.AreEqual(FakeEmployee.EmployeeId, Service.GetEmployee(1).EmployeeId);
        }

        [Test]
        public void TestInsertEmployee()
        {
            Assert.AreEqual(true, Service.InsertEmployee(FakeEmployeeSalary));
        }

        [Test]
        public void TestGetEmployeeIdByName()
        {
            Assert.AreEqual(1, Service.GetEmployeeIdByName(FakeEmployee.FirstName + " " + FakeEmployee.LastName));
        }
    }
}