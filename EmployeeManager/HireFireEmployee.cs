using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EmployeeManager
{
    public partial class HireFireEmployee : Form
    {
        private string _filePath
        = Path.Combine(Environment.CurrentDirectory, "employees.txt");
        private int _employeeId;
        private FileHelper<List<Employee>> _fileHelper = new FileHelper<List<Employee>>
            (Program.FilePath);
        public HireFireEmployee(int id = 0)
        {
            InitializeComponent();
            _employeeId = id;
            if(id != 0)
            {
                var employees = _fileHelper.DeserializeFromFile();
                var employee = employees.FirstOrDefault(x => x.Id == id);
                if(employee == null)
                {
                    throw new Exception("There is no user with that ID");
                }
                tbID.Text = employee.Id.ToString();
                tbFirstName.Text = employee.FirstName;
                tbLastName.Text = employee.LastName;
                tbStartDate.Text = employee.StartDate.ToString();
                tbSalary.Text = employee.Salary;
                tbPosition.Text = employee.Position;
                tbSection.Text = employee.Section;

                tbFirstName.Select();
            }
        }

        private void btnHireHF_Click(object sender, EventArgs e)
        {
            var employees = _fileHelper.DeserializeFromFile();

            if (_employeeId != 0)
            {
                employees.RemoveAll(x => x.Id == _employeeId);
            }
            else
            {

                var employeeHighestId =
                    employees.OrderByDescending(x => x.Id).FirstOrDefault();

                _employeeId = employeeHighestId ==
                    null ? 1 : employeeHighestId.Id + 1;
            }

            var employee = new Employee
            {
                Id = _employeeId,
                FirstName = tbFirstName.Text,// startdate salary position section
                LastName = tbLastName.Text,
                StartDate = DateTime.Now,
                Salary = tbSalary.Text,
                Position = tbPosition.Text,
                Section = tbSection.Text
            };
            employees.Add(employee);
            _fileHelper.SerializeToFile(employees);
            Close();
        }

        private void btnFireHF_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
