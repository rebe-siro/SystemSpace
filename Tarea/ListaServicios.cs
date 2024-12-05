using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemSpace.Tarea;
using SystemSpace.Empleado;

namespace SystemSpace.Tarea
{
    public partial class ListaServicios : Form
    {
        DataBase dataBase;
        public ListaServicios()
        {
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
            dGVServicio.ReadOnly = true;
        }

        private void llenartabla()
        {
            dGVServicio.DataSource = dataBase.TraerServicios();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAgregarServicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarServicios registrarServicios = new RegistrarServicios();
            registrarServicios.ShowDialog();
            llenartabla();
            this.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell code = dGVServicio.CurrentRow.Cells[0];

            var resultadoConsulta = dataBase.traerServiciosPorCodigo(code.Value as string);
            if (resultadoConsulta.Rows.Count == 1)
            {
                DataRow row = resultadoConsulta.Rows[0];

                dataBase.eliminarLogicaServicios(code.Value as string);
                MessageBox.Show("El servicio se eliminó con éxito", "Información");

            }
            else
            {
                MessageBox.Show("No se encontró el servicio a eliminar", "Información");
            }
            llenartabla();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();
            if (searchText.Length > 0)
            {
                dGVServicio.DataSource = dataBase.traerServiciosPorDescription(textBoxSearch.Text);
            }
            else
            {
                llenartabla();
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {

            llenartabla();
            textBoxSearch.Text = string.Empty;
        }
    }
}
