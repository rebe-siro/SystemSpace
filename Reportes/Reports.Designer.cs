namespace SystemSpace.Reportes
{
    partial class Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonOut = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.listaDeTareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tareasExiitosasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tareasRechazadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tareasPorEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.listaDeInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.buttonOut);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 615);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SystemSpace.Properties.Resources.Logo_21;
            this.pictureBox1.Location = new System.Drawing.Point(722, 550);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonOut
            // 
            this.buttonOut.BackColor = System.Drawing.Color.Firebrick;
            this.buttonOut.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOut.Location = new System.Drawing.Point(322, 536);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(225, 55);
            this.buttonOut.TabIndex = 2;
            this.buttonOut.Text = "Salir";
            this.buttonOut.UseVisualStyleBackColor = false;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(856, 454);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeTareasToolStripMenuItem,
            this.tareasExiitosasToolStripMenuItem,
            this.tareasRechazadasToolStripMenuItem,
            this.tareasPorEmpleadoToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(33, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // listaDeTareasToolStripMenuItem
            // 
            this.listaDeTareasToolStripMenuItem.Name = "listaDeTareasToolStripMenuItem";
            this.listaDeTareasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.listaDeTareasToolStripMenuItem.Text = "Lista de tareas";
            // 
            // tareasExiitosasToolStripMenuItem
            // 
            this.tareasExiitosasToolStripMenuItem.Name = "tareasExiitosasToolStripMenuItem";
            this.tareasExiitosasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.tareasExiitosasToolStripMenuItem.Text = "Tareas exitosas";
            // 
            // tareasRechazadasToolStripMenuItem
            // 
            this.tareasRechazadasToolStripMenuItem.Name = "tareasRechazadasToolStripMenuItem";
            this.tareasRechazadasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.tareasRechazadasToolStripMenuItem.Text = "Tareas rechazadas";
            // 
            // tareasPorEmpleadoToolStripMenuItem
            // 
            this.tareasPorEmpleadoToolStripMenuItem.Name = "tareasPorEmpleadoToolStripMenuItem";
            this.tareasPorEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.tareasPorEmpleadoToolStripMenuItem.Text = "Tareas por empleado";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeInventarioToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(33, 24);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // listaDeInventarioToolStripMenuItem
            // 
            this.listaDeInventarioToolStripMenuItem.Name = "listaDeInventarioToolStripMenuItem";
            this.listaDeInventarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listaDeInventarioToolStripMenuItem.Text = "Lista de Inventario";
            this.listaDeInventarioToolStripMenuItem.Click += new System.EventHandler(this.listaDeInventarioToolStripMenuItem_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 648);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reports";
            this.Text = "System Space - Reportes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem listaDeTareasToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem tareasExiitosasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tareasRechazadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tareasPorEmpleadoToolStripMenuItem;
        private System.Windows.Forms.Button buttonOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem listaDeInventarioToolStripMenuItem;
    }
}