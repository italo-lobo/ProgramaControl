using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;// se coloca este para poder usar la barra de progreso.

namespace ListaDNI
{
    public partial class listPrecios : Form
    {      //CODIGO QUE PERMITE MOVER LAS VENTANAS QUE NO TIENEN BORDE 
        public int xClick = 0, yClick = 0;
        public listPrecios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//CREACION DE UNA VENTANA SPLASH //https://www.youtube.com/watch?v=nnhUVmPf06s&ab_channel=nicosiored
         //tutorial 2 de ventana splash  https://www.youtube.com/watch?v=baCsxxliNRc
            timer1.Start();
            prbProgreso.Increment(1);
        
            while (this.Opacity > 0)
            {
                this.Opacity -= 0.00001;
            }
            this.Hide();
            Control ct = new Control();
            ct.Show();
            timer1.Stop();
           
        }

        private void listPrecios_Load(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
            timer1.Interval = 9500;
            timer1.Start();
           

        }

      

        private void listPrecios_MouseMove(object sender, MouseEventArgs e)
        {
            //CODIGO QUE PERMITE MOVER LAS VENTANAS QUE NO TIENEN BORDE 
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}
