using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KONTEYNER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int zaman = 0;
     
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           //acılış ekranı 2 sn sonra açılır.
            zaman++;          
            if (zaman >= 2)
            {
                new Form2().Show();
                timer1.Stop();
                this.Hide();
            }
            else
            {
                this.Text+=" "+(2-zaman).ToString();
            }
        }

       
    }
}
