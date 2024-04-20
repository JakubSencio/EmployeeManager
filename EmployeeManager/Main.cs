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

namespace EmployeeManager
{
    public partial class EmployeeManager : Form
    {
        public EmployeeManager()
        {
            var path = $@"{Path.GetDirectoryName
                (Application.ExecutablePath)}\Employeers.txt";

            InitializeComponent();
            if (!File.Exists(path))
            {
                File.Create(path);
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
