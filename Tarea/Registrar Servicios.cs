using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSpace.Tarea
{
    public partial class RegistrarServicios : Form
    {
        DataBase dataBase;
        ArrayList lista;
        public RegistrarServicios()
        {
            InitializeComponent();  
            lista = new ArrayList();
            dataBase = new DataBase();
            llenarComboSType();
            textBoxCode.Enabled = false;
            disabled();
        }
        public RegistrarServicios(ArrayList list)
        {
            lista = list;
            dataBase = new DataBase();
            InitializeComponent();
            LlenarCampos();
            llenarComboSType();
            AsignarCode();


        }

        private void disabled()
        {
            textBoxCode.Enabled = false;
            textBoxDescription.Enabled = false;
            comboBoxSType.Enabled = false;
        }

        private void enabled()
        {
            textBoxDescription.Enabled = true;
            comboBoxSType.Enabled = true;
        }

        private void clean()
        {
            textBoxCode.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            comboBoxSType.SelectedIndex = -1;
        }
        private void LlenarCampos()
        {
            if (lista.Count > 0)
            {
                textBoxCode.Text = lista[0] as string;
                textBoxDescription.Text = lista[1] as string;
                comboBoxSType.Text = lista[2] as string;
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string code = AsignarCode().ToString();
            string description = textBoxDescription.Text;
            int sType = comboBoxSType.SelectedIndex + 1; ;
            string status = "A";

            if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(description) || (sType <= 0))
            {
                MessageBox.Show("Todos los campos son importantes, deben de llenar", "Información");
                return;
            }
            else if (lista.Count > 0)
            {
                dataBase.modificarServicios(description, sType, status);
                this.Close();
                MessageBox.Show("Se modificó con exito", "Información");
            }
            else if (dataBase.traerServiciosPorCodigo(code).Rows.Count == 0)
            {
                dataBase.agregarServicios(code, description, sType, status);
                clean();
                MessageBox.Show("Se ha guardado con éxito el espacio físico", "Información");

            }
            disabled();
        }

        private void Disabled()
        {
            textBoxCode.Enabled = false;
            textBoxDescription.Enabled = false;
            comboBoxSType.Enabled = false;
        }

        private void Enabled()
        {
            textBoxDescription.Enabled = true;
            comboBoxSType.Enabled = true;
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            clean();
            Enabled();
        }

        public void llenarComboSType()
        {

            DataTable sType = dataBase.traerTypeServicio();

            string[] code = new string[sType.Rows.Count];

            if (sType != null)
            {

                for (int i = 0; i < sType.Rows.Count; i++)
                {
                    code[i] = sType.Rows[i][0].ToString();
                }
            }


            comboBoxSType.Items.Clear();
            comboBoxSType.Items.AddRange(code);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int AsignarCode()
        {
            int nuevoCodigo = dataBase.ultimoCodeServices();
            //textBoxCode.Text = nuevoCodigo.ToString();
            return nuevoCodigo;

        }

        private void buttonLista_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
