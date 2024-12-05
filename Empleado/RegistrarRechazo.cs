using Google.Protobuf.Collections;
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
using SystemSpace.EspacioFisico;
using SystemSpace.Tarea;

namespace SystemSpace.Empleado
{
    public partial class RegistrarRechazo : Form
    {
        DataBase dataBase;
        ArrayList lista;

        public RegistrarRechazo()
        {
            lista = new ArrayList();
            dataBase = new DataBase();
            InitializeComponent();
            textBoxCode.Enabled = false;
            disabled();
        }

        public RegistrarRechazo(ArrayList list)
        {
            lista = list;
            dataBase = new DataBase();
            InitializeComponent();
            LlenarCampos();
            AsignarCodeR();

        }

        private void clean()
        {
            textBoxCode.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            textBoxDetails.Text = string.Empty;

        }

        private void LlenarCampos()
        {
            if (lista.Count > 0)
            {
                textBoxCode.Text = lista[0] as string;
                textBoxDescription.Text = lista[1] as string;
                textBoxDetails.Text = lista[2] as string;
            }
        }


        private void disabled()
        {
            textBoxCode.Enabled = false;
            textBoxDescription.Enabled = false;
            textBoxDetails.Enabled = false;
        }

        private void enabled()
        {
            textBoxDescription.Enabled = true;
            textBoxDetails.Enabled = true;
        }
        private void buttonClean_Click(object sender, EventArgs e)
        {
            clean();
            enabled();
        }


        private int AsignarCodeR()
        {
            int nuevoCodigo = dataBase.ultimoCodeR();
            //textBoxCode.Text = nuevoCodigo.ToString();
            return nuevoCodigo;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //string code = textBoxCode.Text;
            string code = AsignarCodeR().ToString();
            string description = textBoxDescription.Text;
            string details = textBoxDetails.Text;
            string status = "A";

            if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(description) || String.IsNullOrEmpty(details))
            {
                MessageBox.Show("Todos los campos son importantes se deben de llenar", "Información");
                return;
            }
            else if (lista.Count > 0)
            {
                dataBase.modificarRechazo(description, details, status);
                this.Close();
                MessageBox.Show("Se modificó con exito", "Información");
            }
            else if (dataBase.traerRechazoPorCodigo(code).Rows.Count == 0)
            {
                dataBase.agregarRechazo(code, description, details, status);
                clean();
                MessageBox.Show("Se ha guardado con éxito el motvio de rechazo", "Información");

            }
            disabled();
        }
    }
}
