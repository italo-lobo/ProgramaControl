using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;// se coloca este para poder usar la barra de progreso.

namespace ListaDNI
{


    public partial class formControl : Form
    {//instanciacion de la clase validacion de solo numeros 
        ValidarNumeros vn = new ValidarNumeros();

        List<int> validados = new List<int>();
        List<int> siEnRevision = new List<int>();
        List<int> contestador = new List<int>();
        List<int> desiste = new List<int>();
        List<int> duplicado = new List<int>();
        int contadorValidados = 0;
        int contadorContestador = 0;
        int contadorRevision = 0;
        int contadorDesiste = 0;
        int contadorDuplicado = 0;
        int contadorNoAplica = 0;
        String llamadaText = "";
        DateTime fechaHora;
        string text = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            lblHoraReloj.Text = "";
            toolTip1.SetToolTip(txtEmailMin, "Ingrese el texto y haga doble clic para pasar el texto a minuscula y guardar en el portapapeles");
            toolTip1.SetToolTip(btnGenerar, "1: Haga clic en generar para fijar la hora y min actual\n2: Luego presione en el boton EXPORTAR");
            toolTip1.SetToolTip(btnExpor, "Haga clic en ESPORTAR para almacenar la informacion en el portapapeles");
            toolTip1.SetToolTip(btnCalcular, "1: Primero ingrese los importes en el campo LM y LPL.\r\n2: Presione en el boton CALCULAR. \r\n3: Luego presione el boton EXPORTAR");
            toolTip1.SetToolTip(btnExportar, "1: Primero utilice el boton CALCULAR \n2: Presione el boton EXPORTAR para guardar la informacion en el portapapeles.");
        }
        public formControl()
        {
            InitializeComponent();

        }
        //PROGRAMACION DE BOTONES PARA AGREGAR CONTENIDO (VALIDADO Y CONTESTADOR)
        void LimpiarDNI()
        {
            txtDNI.Text = "";
            txtDNI.Focus();
        }
        void MensajeErrorDNI()
        {
            MessageBox.Show("Ingrese un DNI antes");
            txtDNI.Focus();
        }
        private void btnValidado_Click(object sender, EventArgs e)
        {

            if (txtDNI.Text == "")
            {
                MensajeErrorDNI();
            }
            else
            {
                listValidados.Items.Add(txtDNI.Text);
                lblValdCont.Text = Convert.ToString(contadorValidados = contadorValidados + 1);
                LimpiarDNI();
            }

        }
        private void btnContestador_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                MensajeErrorDNI();
            }
            else
            {
                lstConts.Items.Add(txtDNI.Text);
                lblContsCont.Text = Convert.ToString(contadorContestador = contadorContestador + 1);
                LimpiarDNI();
            }
        }
        private void btnRevision_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                MensajeErrorDNI();
            }
            else
            {
                lstRev.Items.Add(txtDNI.Text);
                lblRevCont.Text = Convert.ToString(contadorRevision = contadorRevision + 1);
                LimpiarDNI();
            }
        }
        private void btnDesiste_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                MensajeErrorDNI();
            }
            else
            {
                lstDesis.Items.Add(txtDNI.Text);
                lblDesisCont.Text = Convert.ToString(contadorDesiste = contadorDesiste + 1);
                LimpiarDNI();
            }
        }
        private void btnDupli_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                MensajeErrorDNI();
            }
            else
            {
                lstDupli.Items.Add(txtDNI.Text);
                lblDuplCont.Text = Convert.ToString(contadorDuplicado = contadorDuplicado + 1);
                LimpiarDNI();
            }
        }
        private void btnNoApli_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                MensajeErrorDNI();
            }
            else
            {
                lstNoApl.Items.Add(txtDNI.Text);
                lblNoApl.Text = Convert.ToString(contadorNoAplica = contadorNoAplica + 1);
                LimpiarDNI();
            }
        }
        //PROGRAMACION DE BOTONES CON FUNCIONES COPIAR/ELIMINAR/MODIFICAR
        private void btnCopiar_Click(object sender, EventArgs e)
        {
            //ESTA PARTE DEL CODIGO COPIA AL PORTAPAPELES LA INFO QUE TENGO EN TODO EL PROGRAMA
            //LA FINALIDAD ES PASARLO A UN EXCEL O IMPRIMIR UN REPORTE - FALTA TERMINAR ESTO 
            //string totales = $("total de cargas: Validados {0} Contestador {1} Si en revision {2} Desiste {3} Duplicadas {4}"; lblValdCont.Text,lblContsCont.Text);
            //lblContsCont.Text, lblRevCont.Text, lblDesisCont.Text, lblDuplCont.Text;
            //Clipboard.SetText(lblValiList.Text + "\n" + lblContestList.Text + "\n" );

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (listValidados.SelectedIndex != -1)
            {//este contador funciona bien. 
                int indice = listValidados.SelectedIndex;
                listValidados.Items.RemoveAt(indice);
                lblValdCont.Text = (contadorValidados = contadorValidados - 1).ToString();
            }
            if (lstConts.SelectedIndex != -1)
            {//no entiendo prque no funciona bien cuando pongo contadorContestador-- 
                int indice = lstConts.SelectedIndex;
                lstConts.Items.RemoveAt(indice);
                lblValdCont.Text = (contadorContestador--).ToString();
            }
        }
        private void btnModf_Click(object sender, EventArgs e)
        {
            //ESTA PARTE DEL CODIGO SERIA PARA QUE ME MODIFIQUE LO QUE NECESITO SEGUN EL LISTBOX QUE TENGA SELECCIONADO 
            //Podria simplificarlo con un metodo y un switch? 
            //SOLO LO PROGRAME PARA VALIDADOS Y CONTESTADOR
            if (listValidados.SelectedIndex > -1)
            {
                int indice = listValidados.SelectedIndex;
                listValidados.Items.RemoveAt(indice);
                listValidados.Items.Insert(indice, txtDNI.Text);
                txtDNI.Text = "";
                txtDNI.Focus();
            }
            if (lstConts.SelectedIndex > -1)
            {
                int indice = lstConts.SelectedIndex;
                lstConts.Items.RemoveAt(indice);
                lstConts.Items.Insert(indice, txtDNI.Text);
                txtDNI.Text = "";
                txtDNI.Focus();
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {



            if (txtLM.Text == "" && txtLPL.Text == "")
            {
                MessageBox.Show("Antes debe ingresar el importe");
            }
            else
            if (txtLM.Text.Length >= 6 && txtLPL.Text.Length >= 6)
            {
                int tamañoLM = txtLM.Text.Length - 5;
                int tamañoLPL = txtLPL.Text.Length - 5;
                txtLPL.Text = txtLPL.Text.Substring(0, tamañoLPL);
                txtLM.Text = txtLM.Text.Substring(0, tamañoLM);
                txtLZ.Text = Convert.ToString(Convert.ToInt32(txtLM.Text) * 3);
            }
            else
            {
                MessageBox.Show("Recuerde que debe contener mas de 5 caracteres para poder ser convertidos");
                txtLM.Focus();
            }




        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("LM:$" + txtLM.Text + " LZ:$" + txtLZ.Text + " LPL:$" + txtLPL.Text);
            txtLM.Text = "";
            txtLZ.Text = "";
            txtLPL.Text = "";

        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            fechaHora = DateTime.Now;
            lblHoraReloj.Text = fechaHora.ToString();
            btnGenerar.Enabled = false;
        }
        private void btnExpor_Click(object sender, EventArgs e)
        {
            //esta parte del codigo me agrega encabezado siempre que el boton se encuentre selecccionado 

            if (cbxBBOO.Checked == true)
            {
                text = "_________________\n" + "BBOO\n";
            }
            else
            {
                text = "";
            }
            string TurnoCartero()
            {
                string turno = "";
                if (rbtTurnoM.Checked)
                {
                    turno = "Mañana";

                }
                else

                    if (rbtTurnoT.Checked)
                { turno = "Tarde"; }
                else
                {
                    turno = "";
                }
                return turno;
            }

            string chekbox()
            {
                string valor = "";
                if (rbx2.Checked)
                {
                    valor = "x2";

                }
                else

                    if (rbx3.Checked)
                { valor = "x3"; }
                else
                {
                    valor = "";
                }
                return valor;
            }

            void limpiarCheck()
            {
                cbEstados.SelectedIndex = 0;
                rbx2.Checked = false;
                rbx3.Checked = false;
                rbx2.Visible = false;
                rbx3.Visible = false;
                cbNomBBOO.Text = "";
                cbxBBOO.Checked = false;
                rbtTurnoM.Checked = false;
                rbtTurnoT.Checked = false;

            }

            if (cbNomBBOO.Text == "Matias" || cbNomBBOO.Text == "Geo")
            {
                string nombreBBOO = cbNomBBOO.Text;

                if (cbEstados.Text == "Validado")
                {
                    llamadaText = text + fechaHora.ToShortDateString() + " BBOO: " + nombreBBOO + " " + cbEstados.SelectedItem + "\nCartero: " + TurnoCartero();
                    Clipboard.SetText(llamadaText);
                    limpiarCheck();
                }
                else
                {
                    llamadaText = text + fechaHora.ToShortDateString() + " BBOO: " + nombreBBOO + " " + cbEstados.SelectedItem + " " + chekbox() + "\n";
                    Clipboard.SetText(llamadaText);
                    limpiarCheck();
                }
            }
            else
            {

                if (cbEstados.Text == "Validado")
                {
                    llamadaText = text + fechaHora.ToString("dd/MM/yy HH:mm") + " BBOO Italo: " + cbEstados.SelectedItem + "\nCartero: " + TurnoCartero();
                    Clipboard.SetText(llamadaText);
                    limpiarCheck();
                }
                else
                {
                    llamadaText = text + fechaHora.ToString("dd/MM/yy HH:mm") + " BBOO Italo: " + cbEstados.SelectedItem + " " + chekbox() + "\n";
                    Clipboard.SetText(llamadaText);
                    limpiarCheck();
                }
            }
            btnGenerar.Enabled = true;

            rbx2.Checked = false;
            rbx3.Checked = false;
        }
        //mostrar y ocultar botones 
        private void cbEstados_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbEstados.Text != "Validado")
            {
                rbx2.Visible = true;
                rbx3.Visible = true;
                rbtTurnoM.Visible = false;
                rbtTurnoT.Visible = false;
            }
            else
            {
                rbx2.Visible = false;
                rbx3.Visible = false;
                rbtTurnoM.Visible = true;
                rbtTurnoT.Visible = true;
            }
        }
        private void btHabilitar_Click(object sender, EventArgs e)
        {
            btnGenerar.Enabled = true;
        }
        private void txtLM_KeyPress(object sender, KeyPressEventArgs e)
        {
            vn.soloNumeros(e);
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            vn.soloNumeros(e);
        }
        private void txtEmailMin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText((txtEmailMin.Text.ToLower()).Trim());
            txtEmailMin.Text = "";
        }
        private void btnPrecios_Click(object sender, EventArgs e)
        {
            Form formularioPrecios = new listPrecios();
            formularioPrecios.Show();

        }
        private void iconizarApp_Click(object sender, EventArgs e)
        {//LA MINIMIZAR EL FORMULARIO SE OCULTA EN LA BARRA DE NOTIFICACIONES
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }
        }
        private void formControl_Resize(object sender, EventArgs e)
        {//AL HACER CLICK EN EL ICONO DE NOTIFICACION MUESTRA EL FORMULARIO 
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                iconizarApp.Visible = true;
                iconizarApp.Icon = this.Icon;
            }


        }

    }
}




