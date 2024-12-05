using Google.Protobuf.Collections;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SystemSpace.EspacioFisico;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SystemSpace
{
    public partial class Organizacion : Form
    {
        DataBase dataBase;
        private string connectionString = "Server=localhost;Database=System;Uid=admin;Pwd=sistema";

        public Organizacion()
        {
            InitializeComponent();
            dataBase = new DataBase();
          //  traer("J - 29972410");
            textBoxRif.Enabled = false;
            textBoxRif.ReadOnly = true;
            disabled();

        }

       /* private void traer(string rif)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Consulta SQL
                string query = "SELECT rif, name, address, boss FROM organization WHERE rif = @rif";

                // Crear el comando
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Agregar el parámetro
                    cmd.Parameters.AddWithValue("@rif", rif);

                    try
                    {
                        // Abrir la conexión
                        conn.Open();

                        // Ejecutar el comando y obtener los resultados
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxName.Text = reader["name"].ToString();
                                textBoxAddress.Text = reader["address"].ToString();
                                textBoxBoss.Text = reader["boss"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Organizacion no encontrado.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos: " + ex.Message);
                    }
                }
                conn.Close();
            }
        }*/

    private void disabled()
        {
            textBoxRif.Enabled = false;
            textBoxName.Enabled = false;
            textBoxAddress.Enabled = false;
            textBoxBoss.Enabled = false;
        }

      /*  private void buttonSave_Click(object sender, EventArgs e)
        {
            string rif = textBoxRif.Text;
            string name = textBoxName.Text;
            string address = textBoxAddress.Text;
            string boss = textBoxBoss.Text;

            if (String.IsNullOrEmpty(rif) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(boss))
            {
                MessageBox.Show("Todos los campos son importantes, deben de llenar", "Información");
                return;
            }
            else if (lista.Count > 0)
            {
                dataBase.modificarOrganization(rif, name, address, boss);
                this.Close();
                MessageBox.Show("Se modificó con exito", "Información");
            }
            else
            {
                dataBase.modificarOrganization(rif, name, address, boss);
                MessageBox.Show("Se ha guardado con éxito la información", "Información");

            }
            disabled();
        }*/

        private void enabled()
        {
            textBoxRif.Enabled = true;
            textBoxName.Enabled = true;
            textBoxAddress.Enabled = true;
            textBoxBoss.Enabled = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
