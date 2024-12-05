using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemSpace.Tarea;

namespace SystemSpace.Empleado
{
    public partial class RegistrarEmpleado : Form
    {
        DataBase dataBase;
        ArrayList lista;
        public RegistrarEmpleado()
        {
            lista = new ArrayList();
            dataBase = new DataBase();
            InitializeComponent();
            llenarComboSpeciality();
            llenarComboCharge();
            disabled();
        }

        public RegistrarEmpleado(ArrayList list)
        {
            lista = list;
            dataBase = new DataBase();
            InitializeComponent();
            LlenarCampos();
            AsignarCode();
            llenarComboSpeciality();
            llenarComboCharge();

        }
        private void clean()
        {
            comboBoxSpeciality.SelectedIndex = -1;
            comboBoxCharge.SelectedIndex = -1;
            textBoxNames.Text = string.Empty;
            textBoxLastNames.Text = string.Empty;
            textBoxDirection.Text = string.Empty;
            textBoxTelephone.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
        }

        private void disabled()
        {
            textBoxCode.Enabled = false;
            textBoxDirection.Enabled = false;
            textBoxTelephone.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxNames.Enabled = false;
            textBoxLastNames.Enabled = false;
            comboBoxCharge.Enabled = false;
            comboBoxSpeciality.Enabled = false;
        }

        private void enabled()
        {
            textBoxDirection.Enabled = true;
            textBoxTelephone.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxNames.Enabled = true;
            textBoxLastNames.Enabled = true;
            comboBoxCharge.Enabled = true;
            comboBoxSpeciality.Enabled = true;
        }

        private void LlenarCampos()
        {
            if (lista.Count > 0)
            {
                textBoxCode.Text = Convert.ToDouble(lista[0]).ToString();
                comboBoxSpeciality.Text = Convert.ToString(lista[1]);
                comboBoxCharge.Text = Convert.ToString(lista[2]);
                textBoxNames.Text = lista[3] as string;
                textBoxLastNames.Text = lista[4] as string;
                textBoxDirection.Text = lista[5] as string;
                textBoxTelephone.Text = Convert.ToDouble(lista[6]).ToString();
                textBoxEmail.Text = lista[7] as string;
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string code = AsignarCode().ToString();
            int codeSpeciality = comboBoxSpeciality.SelectedIndex + 1;
            int codeCharge = comboBoxCharge.SelectedIndex + 1;
            string names = textBoxNames.Text;
            string lastNames = textBoxLastNames.Text;
            string address = textBoxDirection.Text;
            string telephone = textBoxTelephone.Text;
            string mail = textBoxEmail.Text;
            string status = "A";

            if (String.IsNullOrEmpty(code) || (codeSpeciality <= 0) || (codeCharge <=0) || String.IsNullOrEmpty(names) || String.IsNullOrEmpty(lastNames) || String.IsNullOrEmpty(address))
            {
                MessageBox.Show("Todos los campos son importantes, deben de llenar", "Información");
                return;
            }
            else if (lista.Count > 0)
            {
                dataBase.modificarEmpleado(codeSpeciality, codeCharge, names, lastNames, address, telephone, mail);
                this.Close();
                MessageBox.Show("Se modificó con exito", "Información");
            }
            else if (dataBase.traerEmpleadoPorCode(code).Rows.Count == 0)
            {
                dataBase.agregarEmpleado(code, codeSpeciality, codeCharge, names, lastNames, address, telephone, mail, status);
                clean();
                MessageBox.Show("El empleado ha sido registrado con éxito", "Información");

            }
            disabled();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            enabled();
            clean();
        }

        public void llenarComboSpeciality()
        {
            DataTable speciality = dataBase.traerSpeciality();
            string[] code = new string[speciality.Rows.Count];

            if (speciality != null)
            {
                for (int i = 0; i < speciality.Rows.Count; i++)
                {
                    code[i] = speciality.Rows[i][0].ToString();
                }
            }

            comboBoxSpeciality.Items.Clear();
            comboBoxSpeciality.Items.AddRange(code);
        }

        public void llenarComboCharge()
        {
            DataTable charge = dataBase.traerCharge();
            string[] code = new string[charge.Rows.Count];

            if (charge != null)
            {
                for (int i = 0; i < charge.Rows.Count; i++)
                {
                    code[i] = charge.Rows[i][0].ToString();
                }
            }

            comboBoxCharge.Items.Clear();
            comboBoxCharge.Items.AddRange(code);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            ListaEmpleado listaEmpleado = new ListaEmpleado();
            listaEmpleado.Close();
        }

        private int AsignarCode()
        {
            int nuevoCodigo = dataBase.ultimoCodeEmployee();
            //textBoxCode.Text = nuevoCodigo.ToString();
            return nuevoCodigo;

        }

        private void buttonTarea_Click(object sender, EventArgs e)
        {
            this.Close();
            AgendarTarea agendarTarea = new AgendarTarea();
            agendarTarea.ShowDialog();
        }
    }
}
