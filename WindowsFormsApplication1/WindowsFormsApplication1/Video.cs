
/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {


        private Form2 frm2;
        // Video video = null;
    
        public Form1()
        {
            InitializeComponent();
            frm2 = new Form2();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            axWindowsMediaPlayer1.openPlayer(@"C:\Users\Андрей\Downloads\ayy lmao.3gp");// адрес видео
             
            //Form2 f2 = new Form2();
            //f2.Show();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                this.axWindowsMediaPlayer1.close(); // закрываем сам плеер, чтобы все ресурсы освободились 
                this.Controls.Remove(axWindowsMediaPlayer1); // убираем элемент WMP с формы
                button1.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            button3.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            button3.Enabled = false;
            button2.Enabled = true;
        }
    }

    public class Form2 : Form
    {
        public Form2()
        {
            Text = "Form2";
        }

    }

}
*/