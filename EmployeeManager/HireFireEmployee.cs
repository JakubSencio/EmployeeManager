using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public HireFireEmployee()
        {
            InitializeComponent();
        }
        public void SerializeToFile(List<Employee> employees)
        {
            var serializer = new XmlSerializer(typeof(List<Employee>));

            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, employees);
                streamWriter.Close();
            }
        }
        public List<Employee> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Employee>();
            }
            var serializer = new XmlSerializer(typeof(List<Employee>));

            using (var streamReader = new StreamReader(_filePath))
            {
                var employees = (List<Employee>)serializer.Deserialize(streamReader);
                streamReader.Close();
                return employees;
            }
        }

        private void btnHireHF_Click(object sender, EventArgs e)
        {
            var employees = DeserializeFromFile();

            var employeeHighestId =
                employees.OrderByDescending(x => x.Id).FirstOrDefault();

            var employeeId = employeeHighestId ==
                null ? 1 : employeeHighestId.Id + 1;

            var employee = new Employee
            {
                Id = employeeId,
                FirstName = tbFirstName.Text,// startdate salary position section
                LastName = tbLastName.Text,
                StartDate = DateTime.Now,
                Salary = tbSalary.Text,
                Position = tbPosition.Text,
                Section = tbSection.Text
            };
            employees.Add(employee);
            SerializeToFile(employees);
            Close();
        }
    }
}
