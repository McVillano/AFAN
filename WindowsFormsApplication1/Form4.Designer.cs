namespace WindowsFormsApplication1
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.clientesTableAdapter = new WindowsFormsApplication1.gestionDataSetTableAdapters.clientesTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textcifnif = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textApellidos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboDependencia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboMinusvalía = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textGradoMinusvalía = new System.Windows.Forms.TextBox();
            this.buttonAddEnfermo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textParentesco = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.buttonAddEnfermo);
            this.groupBox1.Controls.Add(this.textGradoMinusvalía);
            this.groupBox1.Controls.Add(this.comboMinusvalía);
            this.groupBox1.Controls.Add(this.comboDependencia);
            this.groupBox1.Controls.Add(this.textApellidos);
            this.groupBox1.Controls.Add(this.textcifnif);
            this.groupBox1.Controls.Add(this.textDireccion);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Controls.Add(this.textParentesco);
            this.groupBox1.Controls.Add(this.textCodigo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 235);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enfermo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código : ";
            // 
            // textCodigo
            // 
            this.textCodigo.Location = new System.Drawing.Point(54, 25);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(126, 20);
            this.textCodigo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DNI :";
            // 
            // textcifnif
            // 
            this.textcifnif.Location = new System.Drawing.Point(224, 25);
            this.textcifnif.Name = "textcifnif";
            this.textcifnif.Size = new System.Drawing.Size(141, 20);
            this.textcifnif.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre : ";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(61, 62);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(119, 20);
            this.textNombre.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Apellidos :";
            // 
            // textApellidos
            // 
            this.textApellidos.Location = new System.Drawing.Point(247, 62);
            this.textApellidos.Name = "textApellidos";
            this.textApellidos.Size = new System.Drawing.Size(118, 20);
            this.textApellidos.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dirección : ";
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(73, 101);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(292, 20);
            this.textDireccion.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Dependecia : ";
            // 
            // comboDependencia
            // 
            this.comboDependencia.FormattingEnabled = true;
            this.comboDependencia.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.comboDependencia.Location = new System.Drawing.Point(86, 133);
            this.comboDependencia.Name = "comboDependencia";
            this.comboDependencia.Size = new System.Drawing.Size(94, 21);
            this.comboDependencia.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Minusvalía : ";
            // 
            // comboMinusvalía
            // 
            this.comboMinusvalía.FormattingEnabled = true;
            this.comboMinusvalía.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.comboMinusvalía.Location = new System.Drawing.Point(260, 133);
            this.comboMinusvalía.Name = "comboMinusvalía";
            this.comboMinusvalía.Size = new System.Drawing.Size(105, 21);
            this.comboMinusvalía.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Grado de Minusvalía : ";
            // 
            // textGradoMinusvalía
            // 
            this.textGradoMinusvalía.Location = new System.Drawing.Point(127, 169);
            this.textGradoMinusvalía.Name = "textGradoMinusvalía";
            this.textGradoMinusvalía.Size = new System.Drawing.Size(53, 20);
            this.textGradoMinusvalía.TabIndex = 3;
            // 
            // buttonAddEnfermo
            // 
            this.buttonAddEnfermo.Image = global::WindowsFormsApplication1.Properties.Resources.button_add_5121;
            this.buttonAddEnfermo.Location = new System.Drawing.Point(304, 165);
            this.buttonAddEnfermo.Name = "buttonAddEnfermo";
            this.buttonAddEnfermo.Size = new System.Drawing.Size(61, 54);
            this.buttonAddEnfermo.TabIndex = 4;
            this.buttonAddEnfermo.UseVisualStyleBackColor = true;
            this.buttonAddEnfermo.Click += new System.EventHandler(this.buttonAddEnfermo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Parentesco";
            // 
            // textParentesco
            // 
            this.textParentesco.Location = new System.Drawing.Point(73, 203);
            this.textParentesco.Name = "textParentesco";
            this.textParentesco.Size = new System.Drawing.Size(145, 20);
            this.textParentesco.TabIndex = 1;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 263);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.ShowInTaskbar = false;
            this.Text = "Nuevo Enfermo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private gestionDataSetTableAdapters.clientesTableAdapter clientesTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textcifnif;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textGradoMinusvalía;
        private System.Windows.Forms.ComboBox comboMinusvalía;
        private System.Windows.Forms.ComboBox comboDependencia;
        private System.Windows.Forms.TextBox textApellidos;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddEnfermo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textParentesco;
    }
}