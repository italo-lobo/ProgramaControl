using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDNI
{
    public class Validaciones
    {
        public DateTime fechaHora;
        public string BBOO = "";
        public string estado = "";
        public string cartero = "";
        public string llamadaText = "";
        public string intentos = "";
        public string encabezado = "";



        public string Encabezado(Boolean check)
        {
            string text = "";
            if (check == true)
            {
                text = "_________________\n" + "BBOO\n";
            }
            else
            {
                text = "";
            }
            return encabezado = text;
        }
        public string Intentos(Boolean cbx2, Boolean cbx3)
        {

            string valor = "";
            if (cbx2)
            {
                valor = "x2";

            }
            else

                if (cbx3)
            { valor = "x3"; }
            else
            {
                valor = "";
            }
            return this.intentos = valor;

        }
        public string CarteroTurno(Boolean rbtM, Boolean rbtT)
        {

            string carteroTurno;
            if (rbtM)
            {
                carteroTurno = "Mañana";

            }
            else

                if (rbtT)
            { carteroTurno = "Tarde"; }
            else
            {
                carteroTurno = "";
            }
            return this.cartero = carteroTurno;

        }
        public void BBOOCheck(string NomBBOO, object cbEstado, int indexCb)
        {

            //  if (NomBBOO == "Matias" ||  NomBBOO == "Geo")
            if (indexCb != -1)
            {
                this.BBOO = NomBBOO;

                if (cbEstado == "Validado")
                {
                    llamadaText = encabezado + fechaHora.ToShortDateString() + " BBOO: " + NomBBOO + " " + cbEstado + "\nCartero: " + cartero;
                    Clipboard.SetText(llamadaText);
                }
                else
                {
                    llamadaText = encabezado + fechaHora.ToShortDateString() + " BBOO: " + NomBBOO + " " + cbEstado + " " + intentos + "\n";
                    Clipboard.SetText(llamadaText);
                }
            }
            else if (indexCb == -1)
            {

                if (cbEstado == "Validado")
                {
                    llamadaText = encabezado + fechaHora.ToString("dd/MM/yy HH:mm") + " BBOO Italo: " + cbEstado + "\nCartero: " + cartero;
                    Clipboard.SetText(llamadaText);
                }
                else
                {
                    llamadaText = encabezado + fechaHora.ToString("dd/MM/yy HH:mm") + " BBOO Italo: " + cbEstado + " " + intentos + "\n";
                    Clipboard.SetText(llamadaText);
                }
            }
        }

    }
}
