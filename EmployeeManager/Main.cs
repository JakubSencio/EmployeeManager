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
    public partial class EmployeeManager : Form
    {
        private string _filePath 
            = Path.Combine(Environment.CurrentDirectory,"employees.txt");
        public EmployeeManager()
        {
            //var path = $@"{Path.GetDirectoryName
            //    (Application.ExecutablePath)}\Employeers.txt";
            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}

            InitializeComponent();
            var employees = new List<Employee>();
            employees.Add(new Employee { FirstName = "Peter" });
            employees.Add(new Employee { FirstName = "Mark" });
            employees.Add(new Employee { FirstName = "Steven" });
            employees.Add(new Employee { FirstName = "Bob" });

            SerializeToFile(employees);
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
            if(!File.Exists(_filePath))
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnHire_Click(object sender, EventArgs e)
        {

        }

        private void btnFire_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
