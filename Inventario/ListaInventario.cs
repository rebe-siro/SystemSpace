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
using SystemSpace.Empleado;

namespace SystemSpace.AsignacionTarea
{
    public partial class ListaInventario : Form
    {
        DataBase dataBase;
        public ListaInventario()
        {
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
            dGVInventario.ReadOnly = true;
        }

        private void llenartabla()
        {
            dGVInventario.DataSource = dataBase.traerInventario();
        }

        private void buttonAgregarInventario_Click(object sender, EventArgs e)
        {
            this.Close();
            AgregarInventario agregarInventario = new AgregarInventario();
            agregarInventario.ShowDialog();
            //llenartabla();
            this.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();

            foreach (DataGridViewCell cell in dGVInventario.CurrentRow.Cells)
            {
                //llamarComboType(registrarEspacioFisico);
                list.Add(cell.Value);
            }

            this.Hide();
            AgregarInventario agregarInventario = new AgregarInventario(list);
            agregarInventario.ShowDialog();
            llenartabla();
            this.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell code = dGVInventario.CurrentRow.Cells[0];

            var resultadoConsulta = dataBase.traerInventarioPorCode(code.Value as string);
            if (resultadoConsulta.Rows.Count == 1)
            {
                DataRow row = resultadoConsulta.Rows[0];

                dataBase.eliminarLogicaInventario(code.Value as string);
                MessageBox.Show("El inventario se eliminó con éxito", "Información");
                llenartabla();
            }
            else
            {
                MessageBox.Show("No se encontró el inventario a eliminar", "Información");
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            llenartabla();
            textBoxSearch.Text = string.Empty;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();
            if (searchText.Length > 0)
            {
                dGVInventario.DataSource = dataBase.traerInventarioPorDescription(textBoxSearch.Text);
            }
            else
            {
                llenartabla();
            }
        }
    }
}
