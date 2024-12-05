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

namespace SystemSpace.Tarea
{
    public partial class CronogramaTarea : Form
    {
        ArrayList lista;
        DataBase dataBase;
        public CronogramaTarea()
        {
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
        }
        public CronogramaTarea(ArrayList list)
        {
            lista = new ArrayList();
            dataBase = new DataBase();
            InitializeComponent();
            llenartabla();
        }
        private void buttonOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llenartabla()
        {

           // dataGridViewTarea.DataSource = dataBase.TraerPlanService();
        }
    }
}
