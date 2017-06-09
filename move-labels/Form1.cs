using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace move_labels
{
    public partial class Form1 : Form
    {
        int vx = -10;
        int vy = -10;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Left += vx;
            label1.Top += vy;

            if(label1.Left<=0)
            {
                vx = 10;
            }
            else if(label1.Left>=406){
                vx=-10;
            }
   

            if(label1.Top<=0)
            {
                vy = 10;
            }
            else if(label1.Top>=365)
            {
                vy = -10;
            }
        }
    }
}
