using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemSpace.EspacioFisico
{
    public partial class ListaEspaciosFisicos : Form
    {
        DataBase dataBase; 
        public ListaEspaciosFisicos()
        {
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
            //llenarComboType();
            dGVEspaciosFisicos.ReadOnly = true;
        }
        private void llenartabla()
        {
            dGVEspaciosFisicos.DataSource = dataBase.traerEspciofisicos();
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAgregarEspacioFisico_Click(object sender, EventArgs e)
        {
            this.Close();
            RegistrarEspacioFisico registrarEspacioFisico = new RegistrarEspacioFisico();
            registrarEspacioFisico.ShowDialog();
            llenartabla();
            this.Show();
        }
        
        private void buttonEdit_Click(object sender, EventArgs e)
        {

            ArrayList list = new ArrayList();

            foreach (DataGridViewCell cell in dGVEspaciosFisicos.CurrentRow.Cells)
            {
                //llamarComboType();
                list.Add(cell.Value);
            }


            this.Hide();
            RegistrarEspacioFisico registrarEspacioFisico = new RegistrarEspacioFisico(list);
            registrarEspacioFisico.ShowDialog();
            llenartabla();
            this.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell code = dGVEspaciosFisicos.CurrentRow.Cells[0];

            var resultadoConsulta = dataBase.traerEspciosfisicosPorCodigo(code.Value as string);
            if (resultadoConsulta.Rows.Count == 1)
            {
                DataRow row = resultadoConsulta.Rows[0];

                dataBase.eliminarLogicaEspacioFisico(code.Value as string);
                MessageBox.Show("El espacio físico se eliminó con éxito", "Información");
            }
            else
            {
                MessageBox.Show("No se encontró el espacio físico a eliminar", "Información");
            }
            llenartabla();
        }

        private void buttonActualizar_Click_1(object sender, EventArgs e)
        {
            llenartabla();
            textBoxSearch.Text = string.Empty;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();
            if (searchText.Length > 0)
            {
                dGVEspaciosFisicos.DataSource = dataBase.traerEspciosfisicosPorDescription(textBoxSearch.Text);
            }
            else
            {
                llenartabla();
            }
        }
    }
}
