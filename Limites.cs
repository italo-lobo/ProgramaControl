using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDNI
{
    public class Limites
    {
        public string LM = "";
        public string LPL = "";
        public string LZ = "";
        public void LimitesExp()
        {
             Clipboard.SetText("LM:$" +this.LM + " LZ:$" + this.LZ + " LPL:$" + this.LPL);
        }

        public void CalcularLimites(string LM, string LZ, string LPL)
        {
            this.LM = LM;
            this.LPL = LPL;
            this.LZ = LZ;
            if (LM == "" && LPL == "")
            {
                MessageBox.Show("Antes debe ingresar el importe en LM y LPL");
            }
            else
             if (LM.Length >= 6 && LPL.Length >= 6)
            {
                int tamañoLM = LM.Length - 5;
                int tamañoLPL = LPL.Length - 5;
                this.LPL = LPL.Substring(0, tamañoLPL);
                this.LM = LM.Substring(0, tamañoLM);
                this.LZ = Convert.ToString(Convert.ToInt32(LM) * 3);
            }
            else
            {
                MessageBox.Show("Recuerde que debe contener mas de 5 caracteres para poder ser convertidos");
            }
        }

    }
}
