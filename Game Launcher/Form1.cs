using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Game_Launcher
{
    public partial class Form1 : Form
    {
        public Point MouseLocation;
        string item = "";
        public Form1()
        {
            InitializeComponent();
            string[] array2 = Directory.GetFiles(Environment.CurrentDirectory + "\\Aplications\\", "*.lnk");
            foreach (string name in array2)
            {

                string[] options = name.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                string filename = options.Last().Replace(".lnk", "");

                listBox1.Items.Add(filename);
                if (listBox1.SelectedItem != null)
                item = listBox1.GetItemText(listBox1.SelectedItem); 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var selecteditem in listBox1.SelectedItems)
            {
                Process.Start(Environment.CurrentDirectory + "\\Aplications\\" + selecteditem);
            }
        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point(-e.X, -e.Y);
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point MousePosition = Control.MousePosition;
                MousePosition.Offset(MouseLocation.X, MouseLocation.Y);
                Location = MousePosition;
            }
        }

        private void HeaderLabelMouseDown(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point(-e.X, -e.Y);
        }

        private void HeaderLabelMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point MousePosition = Control.MousePosition;
                MousePosition.Offset(MouseLocation.X, MouseLocation.Y);
                Location = MousePosition;
            }
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
