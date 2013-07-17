using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HRFormsClient.HRService;

namespace HRFormsClient
{
    public partial class HRClient : Form
    {
        HRServiceClient service;
        private int? employeeId;

        public HRClient()
        {
            InitializeComponent();
            service = new HRServiceClient();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            if(!ValidateInput())
            {
                var employeeSalary = new EmployeeSalary();
                employeeSalary.FirstName = txtFirstName.Text;
                employeeSalary.LastName = txtLastName.Text;
                employeeSalary.Salary = Convert.ToDecimal(txtSalary.Text);
                employeeSalary.EmailAddress = txtEmail.Text;
                employeeSalary.SupervisorId = employeeId;
                service.InsertEmployee(employeeSalary);
                EmployeeInserted();
            }
        }

        private void EmployeeInserted()
        {
            txtSupervisor.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSalary.Text = string.Empty;
            lblResult.Text = "Employee Saved!";
        }

        private bool ValidateInput()
        {
            bool error = false;

            if (!string.IsNullOrEmpty(txtSupervisor.Text) && txtSupervisor.Text.Split(' ').Count() == 2)
            {
                employeeId = service.GetEmployeeIdByName(txtSupervisor.Text);
                if (employeeId == null)
                {
                    errorProvider1.SetError(txtSupervisor, "Add existing Supervisor name in format First Last name!");
                    error = true;
                }
                else
                {
                    errorProvider1.SetError(txtSupervisor, null);
                }
            }
            else
            {
                errorProvider1.SetError(txtSupervisor, "Supervisor format should be First Last name!");
                error = true;
            }

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "First Name required!");
                error = true;
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Last Name required!");
                error = true;
            }
            else
            {
                errorProvider1.SetError(txtLastName, null);
            }

            if (string.IsNullOrEmpty(txtSalary.Text))
            {
                errorProvider1.SetError(txtSalary, "Salary required!");
                error = true;
            }
            else if (!Regex.IsMatch(txtSalary.Text, @"[0-9]"))
            {
                errorProvider1.SetError(txtSalary, "Salary invalid!");
                error = true;
            }
            else
            {
                errorProvider1.SetError(txtSalary, null);
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email required!");
                error = true;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                errorProvider1.SetError(txtEmail, "Email invalid!");
                error = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            return error;
        }
    }
}
