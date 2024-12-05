using Org.BouncyCastle.Bcpg.Sig;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SystemSpace.Usuario
{
    public partial class RegistrarUsuario : Form
    {
        DataBase dataBase;
        ArrayList lista;

        public RegistrarUsuario()
        {
            lista = new ArrayList();
            dataBase = new DataBase();
            InitializeComponent();
            llenarComboRol();
            AsignarCodeU();

            textBoxCode.Enabled = false;
            textBoxCode.ReadOnly = true;
            disabled();
        }

        public RegistrarUsuario(ArrayList list)
        {
            lista = list;
            dataBase = new DataBase();
            textBoxCode.Enabled = false;
            textBoxCode.ReadOnly = true;
            InitializeComponent();
            LlenarCampos();
            llenarComboRol();

        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            clean();
            enabled();
        }

        private void LlenarCampos()
        {
            if (lista.Count > 0)
            {
                textBoxCode.Text = lista[0] as string;
                textBoxUser.Text = lista[1] as string;
                textBoxPassword.Text = lista[2] as string;
                textBoxPassword2.Text = lista[3] as string;
                comboBoxRol.Text = lista[4] as string;
                textBoxName.Text = lista[5] as string;
                textBoxMail.Text = lista[6] as string;
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //string code = textBoxCode.Text;
            string code = AsignarCodeU().ToString();
            string userName = textBoxUser.Text;
            string password = textBoxPassword.Text;
            string password2 = textBoxPassword2.Text;
            int type = comboBoxRol.SelectedIndex + 1; ;
            string name = textBoxName.Text;
            string mail = textBoxMail.Text;
            string status = "A";

            if (password == password2)
            {
                if (String.IsNullOrEmpty(code) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(password2) || (type <= 0) || String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Todos los campos son importantes, se deben de llenar", "Información");
                    return;
                }
                else if (lista.Count > 0)
                {
                    dataBase.modificarUser(code, userName, name, password, type, mail);
                    this.Close();
                    MessageBox.Show("Se modificó con exito", "Información");
                }
                else if (dataBase.traerUserPorCode(code).Rows.Count == 0)
                {
                    dataBase.agregarUser(code, userName, name, password, type, mail, status);
                    clean();
                    MessageBox.Show("Se ha guardado con éxito el usuario", "Información");

                }
                disabled();
            }
            else
            {
                MessageBox.Show("Las contraseñas no son iguales");
                textBoxPassword2.Text = string.Empty;
            }
            
        }

        private void disabled()
        {
            textBoxCode.Enabled = false;
            textBoxUser.Enabled = false;
            textBoxPassword.Enabled = false;
            textBoxPassword2.Enabled = false;
            comboBoxRol.Enabled = false;
            textBoxName.Enabled = false;
            textBoxMail.Enabled = false;
        }

        private void enabled()
        {
            textBoxUser.Enabled = true;
            textBoxPassword.Enabled = true;
            textBoxPassword2.Enabled = true;
            comboBoxRol.Enabled = true;
            textBoxName.Enabled = true;
            textBoxMail.Enabled = true;
        }

        private void clean()
        {
            textBoxCode.Text = string.Empty;
            textBoxUser.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxPassword2.Text = string.Empty;
            comboBoxRol.SelectedIndex = -1;
            textBoxName.Text = string.Empty;
            textBoxMail.Text = string.Empty;

        }

        public void llenarComboRol()
        {

            DataTable typeUser = dataBase.traerTypeUser();

            string[] code = new string[typeUser.Rows.Count];

            if (typeUser != null)
            {

                for (int i = 0; i < typeUser.Rows.Count; i++)
                {
                    code[i] = typeUser.Rows[i][0].ToString();
                }
            }


            comboBoxRol.Items.Clear();
            comboBoxRol.Items.AddRange(code);
        }

        private void buttonLista_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaUsuario listaUsuario = new ListaUsuario();
            listaUsuario.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ListaUsuario listaUsuario = new ListaUsuario();
            listaUsuario.Close();
            this.Close();
        }

        private int AsignarCodeU()
        {
            int nuevoCodigoU = dataBase.ultimoCodeUser();
            //textBoxCode.Text = nuevoCodigo.ToString();
            return nuevoCodigoU;

        }
    }
}
