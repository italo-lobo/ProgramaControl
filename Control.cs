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

using System.Runtime.CompilerServices;

namespace ListaDNI
{


    public partial class formControl : Form
    {
        #region DECLARACIONES
        Validaciones classValid = new Validaciones();
        Limites classlim = new Limites();
        DataTable tabla = new DataTable();
        DataTable BBOOs = new DataTable();
        ValidarNumeros vn = new ValidarNumeros();//instanciacion de la clase validacion de solo numeros 
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

            #region CREACION DE COLUMNA Y TABLA POR DEFECTO datagridveaw
            try
            {
                tabla.TableName = "controlDiario";
                tabla.Columns.Add("Fecha");
                tabla.Columns.Add("Validado");
                tabla.Columns.Add("Buzon");
                tabla.Columns.Add("Revision");
                tabla.Columns.Add("Negativos");
                tabla.Columns.Add("Recuperados");
                tabla.Columns.Add("DNI");
                tabla.Columns.Add("Onboarding");
            }
            catch (Exception)
            {
                tabla.WriteXml(@"Reporte Actividades Diarias");
            }
            #endregion

            #region CREACION DE COLUMNA Y TABLA POR DEFECTO BBOOs
            try
            {
                BBOOs.TableName = "BBOOs";
                BBOOs.Columns.Add("NombreBBOO");

            }
            catch (Exception)
            {
                BBOOs.WriteXml(@"Nombre de BBOOs");
            }
            #endregion
            #region LECTURA Y ASIGNACION
            tabla.ReadXml(@"Reporte Actividades Diarias");
            BBOOs.ReadXml(@"Nombre de BBOOs");
            dataGridView1.DataSource = tabla;
            cbNomBBOO.DataSource = BBOOs;
            cbNomBBOO.DisplayMember = "NombreBBOO";
            #endregion

            #region REFERENCIAS TOOL TIP
            lblHoraReloj.Text = "";
            toolTip1.SetToolTip(txtEmailMin, "Ingrese el texto y haga doble clic para pasar el texto a minuscula y guardar en el portapapeles");
            toolTip1.SetToolTip(btnGenerar, "1: Haga clic en generar para fijar la hora y min actual\n2: Luego presione en el boton EXPORTAR");
            toolTip1.SetToolTip(btnExpor, "Haga clic en ESPORTAR para almacenar la informacion en el portapapeles");
            toolTip1.SetToolTip(btnCalcular, "1: Primero ingrese los importes en el campo LM y LPL.\r\n2: Presione en el boton CALCULAR. \r\n3: Luego presione el boton EXPORTAR");
            toolTip1.SetToolTip(btnExportar, "1: Primero utilice el boton CALCULAR \n2: Presione el boton EXPORTAR para guardar la informacion en el portapapeles.");
            #endregion
        }
        public formControl()
        {
            InitializeComponent();
            //finalizamos el hilo 
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {//boton para cargar los datos en el datagrid
            //CONTROL DE ERROR FECHA INICIAL 
            FechaGenerar();
            tabla.Rows.Add();
            tabla.Rows[tabla.Rows.Count - 1][cbxTipif.SelectedIndex + 1] = txtDNI.Text;
            tabla.Rows[tabla.Rows.Count - 1][0] = classValid.fechaHora.ToString("d");
            
            //foreach (tipo  variable in coleccion)
            foreach (System.Data.DataRow item in tabla.Rows)
            {
                //int lugar = 0;
                //if (tabla.Rows == null)
                //{
                //    MessageBox.Show("ingresó");
                //    //lugar = dataGridView1.CurrentRow.Index;
                //    //tabla.Rows[lugar][cbxTipif.SelectedIndex + 1] = txtDNI.Text;
                //    break;
                //}
                //else
                //    MessageBox.Show(item["Validado"].ToString());
            }
            //TODO COMO CONTINUAR?

            //***************posible solucion 2*********************

            //private bool ValidateGrid(DataGridVieW dgvListas)
            //{
            //    for (int i = 0; i < dgvListas.RowCount - 1; i++)
            //    {
            //        for (int j = 0; j < dgvListas.ColumnCount; j++)
            //        {
            //            if (string.IsNullOrEmpty(dgvListas.Rows[i].Cells[j].Value))
            //            {
            //                return true;
            //            }
            //        }
            //    }
            //    return false;
            //}

            tabla.WriteXml(@"Reporte Actividades Diarias");
            LimpiarDNI();
            cbxTipif.SelectedIndex = -1;

        }

        #region METODOS
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

            btnGenerar.Enabled = true;
            rbx2.Checked = false;
            rbx3.Checked = false;
            btnGenerar.BackColor = System.Drawing.ColorTranslator.FromHtml("#f5f5f5");
        }
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
        void limpiarLimites()
        {
            txtLM.Text = "";
            txtLZ.Text = "";
            txtLPL.Text = "";
        }
        void FechaGenerar()
        {
            if (classValid.fechaHora.ToString("dd/MM/yyyy") == "01/01/0001")
            {
                classValid.fechaHora = DateTime.Now;
            }

        }
        #endregion

        #region BOTONES PRINCIPALES
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            classlim.CalcularLimites(txtLM.Text, txtLZ.Text, txtLPL.Text);

            txtLM.Text = classlim.LM;
            txtLZ.Text = classlim.LZ;
            txtLPL.Text = classlim.LPL;
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            classlim.LimitesExp();
            limpiarLimites();
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            classValid.fechaHora = DateTime.Now;
            lblHoraReloj.Text = classValid.fechaHora.ToString();
            btnGenerar.Enabled = false;
            btnGenerar.BackColor = System.Drawing.ColorTranslator.FromHtml("#4A5770");
        }
        private void btnExpor_Click(object sender, EventArgs e)
        {

            FechaGenerar(); //control de error fecha 
            classValid.Encabezado(cbxBBOO.Checked);
            classValid.Intentos(rbx2.Checked, rbx3.Checked); //se llamaba chekbox()
            classValid.CarteroTurno(rbtTurnoM.Checked, rbtTurnoT.Checked);
            classValid.BBOOCheck(cbNomBBOO.Text, cbEstados.SelectedItem, cbNomBBOO.SelectedIndex);
            limpiarCheck();

        }
        #endregion

        #region MOSTRAR Y OCULTAR CHECK 
        private void cbEstados_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbEstados.Text == "")
            {
                rbx3.Visible = false;
                rbx2.Visible = false;
                rbtTurnoM.Visible = false;
                rbtTurnoT.Visible = false;

            }
            else if (cbEstados.Text != "Validado")
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
        private void botonGenerarToolStripMenuItem_Click(object sender, EventArgs e)
        {//muestra el menu para habilitar el cambio de hora
            btnGenerar.Enabled = true;
            btnGenerar.BackColor = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
        }
        #endregion

        #region RESTRICCIONES
        private void txtLM_KeyPress(object sender, KeyPressEventArgs e)
        {
            vn.soloNumeros(e);
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            vn.soloNumeros(e);
        }
        #endregion

        #region ACCIONES
        private void txtEmailMin_MouseDoubleClick(object sender, MouseEventArgs e)
        {//conversor de texto a minuscula
            Clipboard.SetText((txtEmailMin.Text.ToLower()).Trim());
            txtEmailMin.Text = "";
        }
        private void btnPrecios_Click(object sender, EventArgs e)
        {
            Form formularioPrecios = new listPrecios();
            formularioPrecios.Show();


        }
        #region MINIMIZA EL PROGRAMA EN LA BANDEJA DE NOTIFICACIONES
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


        #endregion

        #endregion

        private void btnAceptarBBOONom_Click(object sender, EventArgs e)
        {

            BBOOs.Rows.Add();
            BBOOs.Rows[BBOOs.Rows.Count - 1][0] = txtNombreBBOOnew.Text;
            BBOOs.WriteXml(@"Nombre de BBOOs");
        }


    }
}




