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

namespace SystemSpace.Tarea
{
    public partial class FormSelectEmpleado : Form
    {
        DataBase dataBase;
        public FormSelectEmpleado()
        {
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
            dataGridViewEmpleado.ReadOnly = true;
        }
        private void llenartabla()
        {
            dataGridViewEmpleado.DataSource = dataBase.traerEmpleado();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();
            if (searchText.Length > 0)
            {
                dataGridViewEmpleado.DataSource = dataBase.traerEmpleadoPorName(textBoxSearch.Text);
            }
            else
            {
                llenartabla();
            }
        }

        private void dataGridViewEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();

            foreach (DataGridViewCell cell in dataGridViewEmpleado.CurrentRow.Cells)
            {
                //llamarComboType(registrarEspacioFisico);
                list.Add(cell.Value);
            }

            this.Hide();
            RegistrarEmpleado registrarEmpleado = new RegistrarEmpleado(list);
            registrarEmpleado.ShowDialog();
            llenartabla();
            this.Show();
        }
    }
}
