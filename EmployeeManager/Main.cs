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
            InitializeComponent();

            var employees = DeserializeFromFile();

            dgvDiary.DataSource = employees;
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
            var hireEmployee = new HireFireEmployee();
            hireEmployee.ShowDialog();
        }

        private void btnFire_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select employee!");
                return;
            }

            var selectedEmployee = dgvDiary.SelectedRows[0];
            var confirmDelete = 
                MessageBox.Show($"Are you sure?\n{(selectedEmployee.Cells[1].Value.ToString() + " " + selectedEmployee.Cells[2].Value.ToString()).Trim()}",
                "Deleting employee",
                MessageBoxButtons.OKCancel);
            if(confirmDelete == DialogResult.OK)
            {
                var employees = DeserializeFromFile();
                employees.RemoveAll(x => x.Id == Convert.ToInt32(selectedEmployee.Cells[0].Value));
                SerializeToFile(employees);
                dgvDiary.DataSource = employees;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dgvDiary.SelectedRows.Count  == 0)
            {
                MessageBox.Show("Please select employee!");
                return;
            }
            var hireEmployee = new HireFireEmployee(
                Convert.ToInt32
                (dgvDiary.SelectedRows[0].Cells[0].Value)
                );
            hireEmployee.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var employees = DeserializeFromFile();
            dgvDiary.DataSource = employees;
        }
    }
}
