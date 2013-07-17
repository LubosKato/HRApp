using HRServiceApp;
using NUnit.Framework;
using Rhino.Mocks;

namespace HRServiceAppTests
{
    [TestFixture]
    public class HRServiceTests : TestBaseSetup
    {
        [Test]
        public void ClientTestGetEmployee()
        {
            var mock = MockRepository.GenerateMock<IHRService>();
            mock.Expect(t => t.GetEmployee(1)).Return(FakeEmployee);

            var helperClassUnderTestHelper = new HRService.TestHelperClass(mock);

            Assert.AreEqual(FakeEmployee.EmployeeId, helperClassUnderTestHelper.CallGetEmployee(1).EmployeeId);
            mock.VerifyAllExpectations();
        }

        [Test]
        public void ClientTestGetAllEmployees()
        {
            var mock = MockRepository.GenerateMock<IHRService>();
            mock.Expect(t => t.GetAllEmployees()).Return(FakeEmployeeList);

            var helperClassUnderTestHelper = new HRService.TestHelperClass(mock);

            Assert.AreEqual(FakeEmployeeList.Count, helperClassUnderTestHelper.CallAllAmployees().Count);
            Assert.AreEqual(FakeEmployeeList[0].EmployeeId, helperClassUnderTestHelper.CallAllAmployees()[0].EmployeeId);
            mock.VerifyAllExpectations();
        }

        [Test]
        public void ClientTestGetEmployeeIdByName()
        {
            var mock = MockRepository.GenerateMock<IHRService>();
            mock.Expect(t => t.GetEmployeeIdByName(FakeEmployee.FirstName + " " + FakeEmployee.LastName)).Return(1);

            var helperClassUnderTestHelper = new HRService.TestHelperClass(mock);

            Assert.AreEqual(1, helperClassUnderTestHelper.GetEmployeeIdByName(FakeEmployee.FirstName + " " + FakeEmployee.LastName));
            mock.VerifyAllExpectations();
        }

        [Test]
        public void ClientTestInsertEmployee()
        {
            var mock = MockRepository.GenerateMock<IHRService>();
            mock.Expect(t => t.InsertEmployee(FakeEmployeeSalary)).Return(true);

            var helperClassUnderTestHelper = new HRService.TestHelperClass(mock);

            Assert.AreEqual(true, helperClassUnderTestHelper.CallInsertEmployee(FakeEmployeeSalary));
            mock.VerifyAllExpectations();
        }
    }
}
