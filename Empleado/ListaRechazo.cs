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

namespace SystemSpace.Empleado
{
    public partial class ListaRechazo : Form
    {
        DataBase dataBase;
        public ListaRechazo()
        {
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
            dGVRechazos.ReadOnly = true;
        }

        private void buttonAgregarRechazo_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrarRechazo registrarRechazo = new RegistrarRechazo();
            registrarRechazo.ShowDialog();
            llenartabla();
            this.Show();
        }
        private void llenartabla()
        {
            dGVRechazos.DataSource = dataBase.traerRechazo();
        }




        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();

            foreach (DataGridViewCell cell in dGVRechazos.CurrentRow.Cells)
            {
                //llamarComboType(registrarEspacioFisico);
                list.Add(cell.Value);
            }

            this.Hide();
            RegistrarRechazo registrarRechazo = new RegistrarRechazo(list);
            registrarRechazo.ShowDialog();
            llenartabla();
            this.Show();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            llenartabla();
            textBoxSearch.Text = string.Empty;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell code = dGVRechazos.CurrentRow.Cells[0];

            var resultadoConsulta = dataBase.traerRechazoPorCodigo(code.Value as string);
            if (resultadoConsulta.Rows.Count == 1)
            {
                DataRow row = resultadoConsulta.Rows[0];

                dataBase.eliminarLogicaRechazo(code.Value as string);
                MessageBox.Show("El motivo de rechazo se eliminó con éxito", "Información");

            }
            else
            {
                MessageBox.Show("No se encontró el motivo de rechazo a eliminar", "Información");
            }
            llenartabla();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();
            if (searchText.Length > 0)
            {
                dGVRechazos.DataSource = dataBase.traerRechazoPorDescription(textBoxSearch.Text);
            }
            else
            {
                llenartabla();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
