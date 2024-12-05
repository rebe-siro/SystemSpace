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

namespace SystemSpace.AsignacionTarea
{
    public partial class AgregarInventario : Form
    {
        DataBase dataBase;
        ArrayList lista;
        public AgregarInventario()
        {
            lista = new ArrayList();
            dataBase = new DataBase();
            InitializeComponent();
            llenarComboUnit();
            disabled();
        }

        public AgregarInventario(ArrayList list)
        {
            lista = list;
            dataBase = new DataBase();
            InitializeComponent();
            LlenarCampos();
            llenarComboUnit();

        }

        private void clean()
        {
            textBoxCode.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            comboBoxUnit.SelectedIndex = - 1;
            textBoxCost.Text = string.Empty;
            textBoxStock.Text = string.Empty;
            textBoxSMin.Text = string.Empty;
        }

        private void LlenarCampos()
        {
            if (lista.Count > 0)
            {
                textBoxCode.Text = lista[0] as string;
                textBoxDescription.Text = lista[1] as string;
                comboBoxUnit.Text = lista[2] as string;
                textBoxCost.Text = Convert.ToDouble(lista[3]).ToString();
                textBoxStock.Text = Convert.ToDouble(lista[4]).ToString();
                textBoxSMin.Text = Convert.ToDouble(lista[5]).ToString();
            }
        }

        private void buttonSaveInventary_Click(object sender, EventArgs e)
        {
            string code = textBoxCode.Text;
            string description = textBoxDescription.Text;
            int unit = comboBoxUnit.SelectedIndex + 1;
            string cost = textBoxCost.Text;
            string stock = textBoxStock.Text;
            string sMin = textBoxSMin.Text;
            string status = "A";

            if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(description) || (unit <= 0) || String.IsNullOrEmpty(cost) || String.IsNullOrEmpty(stock) || String.IsNullOrEmpty(sMin))
            {
                MessageBox.Show("Todos los campos son importantes, deben de llenar", "Información");
                return;
            }
            else if (lista.Count > 0)
            {
                dataBase.modificarInventario(code, description, unit, cost, stock, sMin);
                this.Close();
                MessageBox.Show("Se modificó con exito", "Información");
            }
            else if (dataBase.traerInventarioPorCode(code).Rows.Count == 0)
            {
                dataBase.agregarInventario(code, description, unit, cost, stock, sMin, status);
                clean();
                MessageBox.Show("El inventario ha sido registrado con éxito", "Información");

            }
            disabled();
        }
        private void disabled()
        {
            textBoxCode.Enabled = false;
            textBoxDescription.Enabled = false;
            textBoxCost.Enabled = false;
            textBoxStock.Enabled = false;
            textBoxSMin.Enabled = false;
            comboBoxUnit.Enabled = false;
        }

        private void enabled()
        {
            textBoxDescription.Enabled = true;
            textBoxCost.Enabled = true;
            textBoxCode.Enabled=true;
            textBoxStock.Enabled=true;
            textBoxSMin.Enabled=true;
            comboBoxUnit.Enabled=true;
            textBoxCost.Enabled=true;
        }

        public void llenarComboUnit()
            {
                DataTable unit = dataBase.traerUnit();
                string[] code = new string[unit.Rows.Count];

                if (unit != null)
                {
                    for (int i = 0; i < unit.Rows.Count; i++)
                    {
                        code[i] = unit.Rows[i][0].ToString();
                    }
                }

                comboBoxUnit.Items.Clear();
                comboBoxUnit.Items.AddRange(code);
            }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            ListaInventario listaInventario = new ListaInventario();
            listaInventario.Close();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            clean();
            enabled();
        }

        private void buttonTarea_Click(object sender, EventArgs e)
        {
            this.Close();
            AgendarTarea agendarTarea = new AgendarTarea();
            agendarTarea.ShowDialog();
        }
    }
}
