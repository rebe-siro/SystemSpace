﻿namespace SystemSpace.EspacioFisico
{
    partial class ListaEspaciosFisicos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaEspaciosFisicos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAgregarEspacioFisico = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dGVEspaciosFisicos = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEspaciosFisicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.textBoxSearch);
            this.groupBox1.Controls.Add(this.dGVEspaciosFisicos);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Espacios Fisicos";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.buttonBack);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonActualizar);
            this.groupBox2.Controls.Add(this.buttonEdit);
            this.groupBox2.Controls.Add(this.buttonAgregarEspacioFisico);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(619, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 497);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Firebrick;
            this.buttonBack.Location = new System.Drawing.Point(13, 327);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(177, 70);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Salir";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(13, 252);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(177, 54);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Eliminar";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonActualizar.Location = new System.Drawing.Point(13, 187);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(177, 54);
            this.buttonActualizar.TabIndex = 2;
            this.buttonActualizar.Text = "Actualizar Tabla";
            this.buttonActualizar.UseVisualStyleBackColor = false;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click_1);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(13, 119);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(177, 54);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAgregarEspacioFisico
            // 
            this.buttonAgregarEspacioFisico.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonAgregarEspacioFisico.Location = new System.Drawing.Point(13, 55);
            this.buttonAgregarEspacioFisico.Name = "buttonAgregarEspacioFisico";
            this.buttonAgregarEspacioFisico.Size = new System.Drawing.Size(177, 54);
            this.buttonAgregarEspacioFisico.TabIndex = 0;
            this.buttonAgregarEspacioFisico.Text = "Agregar";
            this.buttonAgregarEspacioFisico.UseVisualStyleBackColor = false;
            this.buttonAgregarEspacioFisico.Click += new System.EventHandler(this.buttonAgregarEspacioFisico_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonSearch.Location = new System.Drawing.Point(478, 26);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(117, 46);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Buscar";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(25, 37);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(447, 27);
            this.textBoxSearch.TabIndex = 1;
            // 
            // dGVEspaciosFisicos
            // 
            this.dGVEspaciosFisicos.AllowUserToOrderColumns = true;
            this.dGVEspaciosFisicos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dGVEspaciosFisicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEspaciosFisicos.Location = new System.Drawing.Point(25, 81);
            this.dGVEspaciosFisicos.Name = "dGVEspaciosFisicos";
            this.dGVEspaciosFisicos.Size = new System.Drawing.Size(570, 440);
            this.dGVEspaciosFisicos.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SystemSpace.Properties.Resources.Logo_21;
            this.pictureBox1.Location = new System.Drawing.Point(14, 402);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ListaEspaciosFisicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 590);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListaEspaciosFisicos";
            this.Text = "System Space - Lista Espacios Fisicos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVEspaciosFisicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGVEspaciosFisicos;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAgregarEspacioFisico;
        private System.Windows.Forms.Button buttonActualizar;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}