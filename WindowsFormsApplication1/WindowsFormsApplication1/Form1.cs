using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SawafOS;
using RR;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Round Robin")
            {
                RoundRobin rr = new RoundRobin();
                rr.doRoundRobin();
                
            }
            else if (comboBox1.SelectedItem.ToString() == "FCFS")
            {
                SawafOS.Program program = new SawafOS.Program();
                program.FCFS(progressBar1);                
            }
            else if (comboBox1.SelectedItem.ToString() == "FCLS")
            {
                SawafOS.Program program = new SawafOS.Program();
                program.FCLS(progressBar1);               
            }
        }
    }
}
