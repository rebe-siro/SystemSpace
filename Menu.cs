using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemSpace.AsignacionTarea;
using SystemSpace.Empleado;
using SystemSpace.EspacioFisico;
using SystemSpace.Reportes;
using SystemSpace.Tarea;
using SystemSpace.Usuario;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SystemSpace
{
    public partial class Menu : Form
    {
        private Form1 inicio;
        private String type;
        public Menu()
        {
            InitializeComponent();
            if (type == "1")
            {
                activateAdmin();
            }
            else if (type == "2")
            {
                activatePerson();
            }
            else if (type == "3")
            {
                activateGest();
            }
            else
            {
                MessageBox.Show("Error, el usuario no existe", "Error");
            }

            //disabled();

        }

        public Menu(String type)
        {
            InitializeComponent();
            this.type = type;
            disabled();
            if (type == "1")
            {
                activateAdmin();
            }
            else if (type == "2")
            {
                activatePerson();
            }
            else if (type == "3")
            {
                activateGest();
            }
            else
            {
                MessageBox.Show("Error, el usuario no existe", "Error");
            }

        }


        private void disabled()
        {
            buttonOrganizacion.Visible = false;
            buttonListEspacioFisico.Visible = false;
            buttonEmployee.Visible = false;
            buttonInventary.Visible = false;
            buttonPlanService.Visible = false;
            buttonCronogramaTarea.Visible = false;
            buttonUser.Visible = false;
            buttonReport.Visible = false;
            buttonReason.Visible = false;
        }

        private void activateAdmin()
        {
            buttonOrganizacion.Visible = true;
            buttonListEspacioFisico.Visible = true;
            buttonEmployee.Visible = true;
            buttonInventary.Visible = true;
            buttonPlanService.Visible = true;
            buttonCronogramaTarea.Visible = true;
            buttonUser.Visible = true;
            buttonReport.Visible = true;
        }
        private void activateGest()
        {
            buttonEmployee.Visible = true;
            buttonInventary.Visible = true;
            buttonReport.Visible = true;
        }
        private void activatePerson()
        {
            buttonCronogramaTarea.Visible = true;
            buttonReport.Visible = true;
        }


        private void buttonRegisterSpace_Click(object sender, EventArgs e)
        {
            RegistrarEspacioFisico registrarEspacioF = new RegistrarEspacioFisico();
            registrarEspacioF.ShowDialog();
        }

        private void buttonListEspacioFisico_Click(object sender, EventArgs e)
        {
            ListaEspaciosFisicos listaEspaciosFisicos = new ListaEspaciosFisicos();
            listaEspaciosFisicos.ShowDialog();
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            ListaEmpleado listaEmpleado = new ListaEmpleado();
            listaEmpleado.ShowDialog();
        }

        private void buttonInventary_Click(object sender, EventArgs e)
        {
            ListaInventario listaInventario = new ListaInventario();
            listaInventario.ShowDialog();
        }

        private void buttonPlanService_Click(object sender, EventArgs e)
        {
            AgendarTarea agendarTarea = new AgendarTarea();
            agendarTarea.ShowDialog();
        }

        private void buttonCronogramaTarea_Click(object sender, EventArgs e)
        {
            FormSelectEmpleado formSelectEmpleado = new FormSelectEmpleado();
            formSelectEmpleado.ShowDialog();
            CronogramaTarea cronogramaTarea = new CronogramaTarea();
            cronogramaTarea.ShowDialog();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Reports reportes = new Reports();
            reportes.ShowDialog();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            ListaUsuario listaUsuario = new ListaUsuario();
            listaUsuario.ShowDialog();
        }

        private void buttonSesionClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 inicio = new Form1();
            inicio.ShowDialog();
        }

        private void buttonOrganizacion_Click(object sender, EventArgs e)
        {
            Organizacion organizacion = new Organizacion();
            organizacion.ShowDialog();
        }

        private void buttonReason_Click(object sender, EventArgs e)
        {
            ListaRechazo listaRechazo = new ListaRechazo();
            listaRechazo.ShowDialog();
        }
    }
}
