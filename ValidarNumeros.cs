using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDNI
{
    class ValidarNumeros
    {
        public void soloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar)) //teclas numericas 
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))//tecla de control como la de borrar 
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))//tecla de espacio no permitida  
            {
                e.Handled = true; 
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
