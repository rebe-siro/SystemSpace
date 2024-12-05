using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
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
using System.Windows.Forms.VisualStyles;
using SystemSpace.Empleado;
using SystemSpace.EspacioFisico;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SystemSpace.Tarea
{
    public partial class AgendarTarea : Form
    {
        DataBase dataBase;
        DataTable dt;
        ArrayList lista;

        public AgendarTarea()
        {
            lista = new ArrayList();
            dataBase = new DataBase();
            dt = new DataTable();
            InitializeComponent();
            TraerMateriales();
            dataGridMaterials2.ReadOnly = true;
            dGVGeneral.ReadOnly = true;
            buttonSelect.Visible = false;
            Iniciar();
            monthCalendar.DateSelected += MonthCalendar_DateSelected;

        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Formatear la fecha seleccionada
            textBoxFecha.Text = e.Start.ToString("yyyy-MM-dd");
        }


        private void buttonSelect_Click(object sender, EventArgs e)
        {
        }



        private void TraerEmpleado()
        {
            dGVGeneral.DataSource = dataBase.traerEmpleado();
            buttonSelect.Visible = true;
        }

        private void TraerSuplente()
        {
            dGVGeneral.DataSource = dataBase.traerEmpleado2();
            buttonSelect.Visible = true;
        }
        private void TraerEspacioFisico()
        {
            dGVGeneral.DataSource = dataBase.traerEspciofisicos();
            buttonSelect.Visible = true;
        }
        private void TraerServicio()
        {
            dGVGeneral.DataSource = dataBase.TraerServicios();
            buttonSelect.Visible = true;
        }
        private void TraerMateriales()
        {
            dataGridMaterials2.DataSource = dataBase.traerInventario();
        }

        private void buttonService_Click(object sender, EventArgs e)
        {
            TraerServicio();
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            TraerEmpleado();
        }

        private void buttonSpaceFisic_Click(object sender, EventArgs e)
        {
            TraerEspacioFisico();
        }

        private void buttonSupl_Click(object sender, EventArgs e)
        {
            TraerSuplente();
        }            



        private void Iniciar()
        {
            monthCalendar.Enabled = false;
            textBoxSearch.Enabled = false;
            buttonSelect.Enabled = false;
            dataGridMaterials2.Enabled = false;
            buttonService.Enabled = false;
            buttonEmployee.Enabled = false;
            buttonSupl.Enabled = false;
            groupBoxCalendar.Enabled = false;
            buttonSave.Enabled = false;
            textBoxEmployee.Enabled = false;
            textBoxEmployeeCode.Enabled = false;
            textBoxServices.Enabled = false;
            textBoxServicesCode.Enabled = false;
            textBoxSuplent.Enabled = false;
            textBoxSuplentCode.Enabled = false;
            dataGridMaterials2.Enabled = false;
            dGVGeneral.Enabled = false;
            buttonSpaceFisic.Enabled = false;
            textBoxSpaceFisic.Enabled=false;
            textBoxSpaceFisicCode.Enabled = false;

            monthCalendar.Visible = false;

            textBoxEmployee.ReadOnly = true;
            textBoxEmployeeCode.ReadOnly = true;
            textBoxServices.ReadOnly = true;
            textBoxServicesCode.ReadOnly = true;
            textBoxSuplent.ReadOnly = true;
            textBoxSuplentCode.ReadOnly = true;
            textBoxSpaceFisicCode.ReadOnly = true;
            textBoxSpaceFisic.ReadOnly = true;
        }  
        private void buttonServicesAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarServicios registrarServicios = new RegistrarServicios();
            registrarServicios.ShowDialog();
            //llenartabla();
            this.Show();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            //clean();
            textBoxEmployee.Enabled = true;
            textBoxEmployeeCode.Enabled = true;
            textBoxServices.Enabled = true ;
            textBoxServicesCode.Enabled = true;
            textBoxSuplent.Enabled = true;
            textBoxSuplentCode.Enabled = true;
            dataGridMaterials2.Enabled = true;
            buttonService.Enabled = true;
          
            buttonEmployee.Enabled = true;
            buttonSupl.Enabled = true;
            groupBoxCalendar.Enabled = true;
            buttonSave.Enabled = true;

            dGVGeneral.Enabled = true;
            buttonSpaceFisic.Enabled = true;
            textBoxSpaceFisic.Enabled = true;
            textBoxSpaceFisicCode.Enabled = true;

        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string code = AsignarCode().ToString();
            string codeService = textBoxServicesCode.Text;
            string codeEmployee = textBoxEmployeeCode.Text;
            string codeSupl = textBoxSuplentCode.Text;
            string codeFisicS = textBoxSpaceFisicCode.Text;
            String daysSelec = textBoxFecha.Text;
            string status = "A";

            if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(codeService) || String.IsNullOrEmpty(codeEmployee))
            {
                MessageBox.Show("Todos los campos son importantes, deben de llenar", "Información");
                return;
            }
            /*else if (lista.Count > 0)
            {
                dataBase.modificarEmpleado(codeSpeciality, codeCharge, names, lastNames, address, telephone, mail);
                this.Close();
                MessageBox.Show("Se modificó con exito", "Información");
            }*/
            else if (dataBase.traerPlanServicePorCode(code).Rows.Count == 0)
            {
                dataBase.agregarPlanServicio(code, codeService, codeEmployee, codeSupl, codeFisicS, daysSelec, status);

                    foreach (DataGridViewRow row in dataGridMaterials2.SelectedRows)
                    {
                        var valor = row.Cells["Código"].Value;
                        string codeS = code.ToString();
                        string codeInventory = valor.ToString();
                        dataBase.agregarMateriales(codeS, codeInventory);
                    //    MessageBox.Show("Si me estoy mostrando" + valor, "Información");

                }

                        //clean();
                        MessageBox.Show("El plan ha sido registrado con éxito", "Información");

            }
            Iniciar();
        }
        private int AsignarCode()
        {
            int nuevoCodigo = dataBase.ultimoCodePlanService();
            //textBoxCode.Text = nuevoCodigo.ToString();
            return nuevoCodigo;

        }
      

        private void buttonMaterials_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=System;Uid=admin;Pwd=sistema;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    // Abre la conexión a la base de datos
                    conn.Open();

                    // Recorre cada fila del DataGridView
                    foreach (DataGridViewRow row in dataGridMaterials2.Rows)
                    {
                        // Asegúrate de que la fila no esté vacía
                        if (!row.IsNewRow)
                        {
                            // Obtiene los valores de las celdas para cada campo
                          //  string codeM = AsignarCodeM().ToString();
                            int codeInvetory = Convert.ToInt32(row.Cells["Código"].Value);
                            string description = row.Cells["Descripción"].Value.ToString();
                           // DateTime fecha = Convert.ToDateTime(row.Cells["Fecha"].Value);

                            // Crea la consulta SQL para actualizar los datos
                            string sqlStatement = "INSERT INTO materials (codeM, codeInvetory, Descripcion) VALUES (@code, @codeInventory, @Description)";

                            // Prepara el comando SQL con los parámetros
                            using (MySqlCommand command = new MySqlCommand(sqlStatement, conn))
                            {
                               // command.Parameters.AddWithValue("@codeM", codeM);
                                command.Parameters.AddWithValue("@codeInvetory", codeInvetory);
                                command.Parameters.AddWithValue("@description", description);

                                // Ejecuta la actualización
                                command.ExecuteNonQuery();
                            }
                        }

                    }

                    // Cierra la conexión
                    conn.Close();

                    MessageBox.Show("Los registros se han guardado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los registros: " + ex.Message);
            }
        }

        private void buttonListServicios_Click(object sender, EventArgs e)
        {
            ListaServicios listaServicios = new ListaServicios();
            listaServicios.ShowDialog();
        }

        private void dGVGeneral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dGVGeneral.Rows[e.RowIndex];

                if (dGVGeneral.DataSource != null)
                {
                    if (dGVGeneral.DataSource is DataTable dataTable)
                    {
                        // Comparar con los métodos específicos de manera confiable
                        if (EsMismoDataTable(dataTable, dataBase.TraerServicios()))
                        {
                            textBoxServicesCode.Text = selectedRow.Cells[0].Value.ToString();
                            textBoxServices.Text = selectedRow.Cells[1].Value.ToString();
                        }
                        else if (EsMismoDataTable(dataTable, dataBase.traerEmpleado()))
                        {
                            textBoxEmployeeCode.Text = selectedRow.Cells[0].Value.ToString();
                            textBoxEmployee.Text = selectedRow.Cells[1].Value.ToString();
                        }
                        else if (EsMismoDataTable(dataTable, dataBase.traerEmpleado2()))
                        {
                            textBoxSuplentCode.Text = selectedRow.Cells[0].Value.ToString();
                            textBoxSuplent.Text = selectedRow.Cells[1].Value.ToString();
                        }
                        else if (EsMismoDataTable(dataTable, dataBase.traerEspciofisicos()))
                        {
                            textBoxSpaceFisicCode.Text = selectedRow.Cells[0].Value.ToString();
                            textBoxSpaceFisic.Text = selectedRow.Cells[1].Value.ToString();
                        }
                    }
                }
            }
        }

        private bool EsMismoDataTable(DataTable dataTable1, DataTable dataTable2)
        {
            // Verificar si ambos DataTable tienen el mismo número de filas y columnas
            if (dataTable1.Rows.Count != dataTable2.Rows.Count || dataTable1.Columns.Count != dataTable2.Columns.Count)
                return false;

            // Comparar las filas y columnas de cada DataTable
            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable1.Columns.Count; j++)
                {
                    // Comparar los valores en cada celda
                    if (!dataTable1.Rows[i][j].Equals(dataTable2.Rows[i][j]))
                        return false;
                }
            }

            return true;
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar.Visible = false;
        }

        private void buttonOneT_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxL.Items.Count; i++)
            {
                checkedListBoxL.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBoxM.Items.Count; i++)
            {
                checkedListBoxM.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBoxMM.Items.Count; i++)
            {
                checkedListBoxMM.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBoxJ.Items.Count; i++)
            {
                checkedListBoxJ.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBoxV.Items.Count; i++)
            {
                checkedListBoxV.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBoxS.Items.Count; i++)
            {
                checkedListBoxS.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBoxD.Items.Count; i++)
            {
                checkedListBoxD.SetItemChecked(i, false);
            }



            monthCalendar.Visible = true;
            monthCalendar.Enabled = true;
        }

        private void checkedListBoxL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
