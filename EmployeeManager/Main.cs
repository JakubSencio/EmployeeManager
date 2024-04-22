using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        private FileHelper<List<Employee>> _fileHelper = new FileHelper<List<Employee>>
            (Program.FilePath);
        public EmployeeManager()
        {
            InitializeComponent();

            RefreshPanel();
            SetColumnsHeader();

        }

        private void RefreshPanel()
        {
            var employees = _fileHelper.DeserializeFromFile();
            dgvDiary.DataSource = employees;
        }

        private void SetColumnsHeader()
        {
            dgvDiary.Columns[0].HeaderText = "ID";
            dgvDiary.Columns[1].HeaderText = "First Name";
            dgvDiary.Columns[2].HeaderText = "Last Name";
            dgvDiary.Columns[3].HeaderText = "Start Date";
            dgvDiary.Columns[4].HeaderText = "Salary";
            dgvDiary.Columns[5].HeaderText = "Position";
            dgvDiary.Columns[6].HeaderText = "Section";
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
                DeleteEmployee(Convert.ToInt32(selectedEmployee.Cells[0].Value));
                RefreshPanel();
            }

        }
        private void DeleteEmployee(int id)
        {
            var employees = _fileHelper.DeserializeFromFile();
            employees.RemoveAll(x => x.Id == id);
            _fileHelper.SerializeToFile(employees);
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
            RefreshPanel();
        }
    }
}
