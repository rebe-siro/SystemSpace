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

namespace SystemSpace.Empleado
{
    public partial class ListaEmpleado : Form
    {
        DataBase dataBase;
        public ListaEmpleado()
        {
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
            dGVEmpleado.ReadOnly = true;

        }
        private void llenartabla()
        {
            dGVEmpleado.DataSource = dataBase.traerEmpleado();
        }
        

        private void buttonAgregarEmpleado_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrarEmpleado registrarEmpleado = new RegistrarEmpleado();
            registrarEmpleado.ShowDialog();
            llenartabla();
            this.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();

            foreach (DataGridViewCell cell in dGVEmpleado.CurrentRow.Cells)
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell code = dGVEmpleado.CurrentRow.Cells[0];

            var resultadoConsulta = dataBase.traerEmpleadoPorCode(code.Value as string);
            if (resultadoConsulta.Rows.Count == 1)
            {
                DataRow row = resultadoConsulta.Rows[0];

                dataBase.eliminarLogicaEmpleado(code.Value as string);
                MessageBox.Show("El espacio físico se eliminó con éxito", "Información");
                
            }
            else
            {
                MessageBox.Show("No se encontró el espacio físico a eliminar", "Información");
            }
            llenartabla();
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
                dGVEmpleado.DataSource = dataBase.traerEmpleadoPorName(textBoxSearch.Text);
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
