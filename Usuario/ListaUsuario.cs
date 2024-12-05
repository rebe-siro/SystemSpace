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

namespace SystemSpace.Usuario
{
    public partial class ListaUsuario : Form
    {
        DataBase dataBase;
        public ListaUsuario()
        {
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
            dGVUsuarios.ReadOnly = true;
            InitializeComponent();
        }

        private void llenartabla()
        {
            dGVUsuarios.DataSource = dataBase.traeruser();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();
            if (searchText.Length > 0)
            {
                dGVUsuarios.DataSource = dataBase.traerUserPorName(textBoxSearch.Text);
                dGVUsuarios.DataSource = dataBase.traerUserPorUser(textBoxSearch.Text);
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

        private void buttonAgregarUsuarios_Click(object sender, EventArgs e)
        {

            this.Close();
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.ShowDialog();
            llenartabla();
            this.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();

            foreach (DataGridViewCell cell in dGVUsuarios.CurrentRow.Cells)
            {
                //llamarComboType();
                list.Add(cell.Value);
            }


            this.Hide();
            RegistrarUsuario registrarUsuario = new RegistrarUsuario(list);
            registrarUsuario.ShowDialog();
            llenartabla();
            this.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell code = dGVUsuarios.CurrentRow.Cells[0];

            var resultadoConsulta = dataBase.traerUserPorCode(code.Value as string);
            if (resultadoConsulta.Rows.Count == 1)
            {
                DataRow row = resultadoConsulta.Rows[0];

                dataBase.eliminarLogicaUsuario(code.Value as string);
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
    }
}
