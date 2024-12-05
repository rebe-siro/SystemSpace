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
using SystemSpace.Tarea;

namespace SystemSpace.EspacioFisico
{
    public partial class RegistrarEspacioFisico : Form
    {
        DataBase dataBase;
        ArrayList lista;
        public RegistrarEspacioFisico()
        {
            lista = new ArrayList();
            dataBase = new DataBase();
            InitializeComponent();
            llenarComboType();
            textBoxCode.Enabled = false;
            disabled();
        }

        public RegistrarEspacioFisico(ArrayList list)
        {
            lista = list;
            dataBase = new DataBase();
            InitializeComponent();
            //comboBoxType.Enabled = true;
            //textBoxCode.ReadOnly = true;
            LlenarCampos();
            AsignarCode();
            llenarComboType();

        }

        private void clean()
        {
            //textBoxCode.Text = string.Empty;
            comboBoxType.SelectedIndex = -1;
            textBoxDescription.Text = string.Empty;
            textBoxMeasures.Text = string.Empty;

        }

        private void LlenarCampos()
        {
            if (lista.Count > 0)
            {
                textBoxCode.Text = lista[0] as string;
                textBoxDescription.Text = lista[1] as string;
                comboBoxType.Text = lista[2] as string;
                textBoxMeasures.Text = Convert.ToDouble(lista[3]).ToString();
            }   

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //string code = textBoxCode.Text;
            string code = AsignarCode().ToString();
            string description = textBoxDescription.Text;
            string measures = textBoxMeasures.Text;
            int typespace = comboBoxType.SelectedIndex + 1;
            string status = "A";

            if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(description) || (typespace <= 0))
            {
                MessageBox.Show("Todos los campos son importantes, deben de llenar", "Información");
                return;
            }
            else if (lista.Count > 0)
            {
                dataBase.modificarEspacioFisico(description, measures, typespace, status);
                this.Close();
                MessageBox.Show("Se modificó con exito", "Información");
            }
            else if (dataBase.traerEspciosfisicosPorCodigo(code).Rows.Count == 0)
            {
                dataBase.agregarEspacioFisico(code, description, measures, typespace, status);
                clean();
                MessageBox.Show("Se ha guardado con éxito el espacio físico", "Información");

            }
            disabled();
        }
        private void disabled()
        {
            textBoxCode.Enabled = false;
            textBoxDescription.Enabled = false;
            textBoxMeasures.Enabled = false;
            comboBoxType.Enabled = false;
        }

        private void enabled()
        {
            textBoxDescription.Enabled=true;
            textBoxMeasures.Enabled=true;
            comboBoxType.Enabled=true;
        }
        private void buttonClean_Click(object sender, EventArgs e)
        {
            clean();
            enabled();
        }

        public void llenarComboType()
        {

            DataTable type = dataBase.traerTypeEspacioFisicos();

            string[] code = new string[type.Rows.Count];

            if (type != null)
            {

                for (int i = 0; i < type.Rows.Count; i++)
                {
                    code[i] = type.Rows[i][0].ToString();
                }
            }


            comboBoxType.Items.Clear();
            comboBoxType.Items.AddRange(code);
        }

        private void buttonLista_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaEspaciosFisicos listaEspaciosFisicos = new ListaEspaciosFisicos();
            listaEspaciosFisicos.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ListaEspaciosFisicos listaEspaciosFisicos = new ListaEspaciosFisicos();
            listaEspaciosFisicos.Close();
            this.Close();
        }

        private int AsignarCode()
        {
            int nuevoCodigo = dataBase.ultimoCode();
            //textBoxCode.Text = nuevoCodigo.ToString();
            return nuevoCodigo;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            AgendarTarea agendarTarea = new AgendarTarea();
            agendarTarea.ShowDialog();
        }
    }
}
