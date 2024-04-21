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
        private string _filePath;
        public EmployeeManager()
        {
            //var path = $@"{Path.GetDirectoryName
            //    (Application.ExecutablePath)}\Employeers.txt";
            //if (!File.Exists(path))
            //{
            //    File.Create(path);
            //}

            InitializeComponent();

        }
        public void SerializeToFile(List<Employee> employees)
        {
            var serializer = new XmlSerializer(typeof(List<Employee>));
            var streamWriter = new StreamWriter(_filePath);
            serializer.Serialize();
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
