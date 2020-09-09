using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
