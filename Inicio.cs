using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemSpace.Usuario;

namespace SystemSpace
{
    public partial class Form1 : Form
    {
        private Menu menu;
        private string type;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBoxUser.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor ingrese el nombre de usuario y la contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //string userType = textBoxUser.Text.Trim();
            if (ValidarCredenciales(userName, password))
            {
                MessageBox.Show("Ingreso exitoso.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                Menu menu = new Menu("1");
                
                menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Intente nuevamente.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Text = string.Empty; Text = "";
            }
        }

        private bool ValidarCredenciales(string userName, string password)
        {
            string connectionString = "Server=localhost;Database=System;Uid=admin;Pwd=sistema;";    

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM user WHERE userName = @userName AND password = @password AND status = 'A'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.ShowDialog();
        }
    }
}
