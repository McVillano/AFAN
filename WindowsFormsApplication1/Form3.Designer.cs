namespace WindowsFormsApplication1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.groupSocio = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.datePickNaci = new System.Windows.Forms.DateTimePicker();
            this.comboSexo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textApellidos = new System.Windows.Forms.TextBox();
            this.textCifNif = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientesTableAdapter = new Afan.gestionDataSetTableAdapters.clientesTableAdapter();
            this.groupSocio.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSocio
            // 
            this.groupSocio.Controls.Add(this.button1);
            this.groupSocio.Controls.Add(this.label6);
            this.groupSocio.Controls.Add(this.datePickNaci);
            this.groupSocio.Controls.Add(this.comboSexo);
            this.groupSocio.Controls.Add(this.label5);
            this.groupSocio.Controls.Add(this.textApellidos);
            this.groupSocio.Controls.Add(this.textCifNif);
            this.groupSocio.Controls.Add(this.textNombre);
            this.groupSocio.Controls.Add(this.textCodigo);
            this.groupSocio.Controls.Add(this.label4);
            this.groupSocio.Controls.Add(this.label2);
            this.groupSocio.Controls.Add(this.label3);
            this.groupSocio.Controls.Add(this.label1);
            this.groupSocio.Location = new System.Drawing.Point(12, 12);
            this.groupSocio.Name = "groupSocio";
            this.groupSocio.Size = new System.Drawing.Size(433, 222);
            this.groupSocio.TabIndex = 0;
            this.groupSocio.TabStop = false;
            this.groupSocio.Text = "Socio";
            // 
            // button1
            // 
            this.button1.Image = global::Afan.Properties.Resources.button_add_5121;
            this.button1.Location = new System.Drawing.Point(355, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 54);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha de Nacimiento:";
            // 
            // datePickNaci
            // 
            this.datePickNaci.Location = new System.Drawing.Point(120, 131);
            this.datePickNaci.Name = "datePickNaci";
            this.datePickNaci.Size = new System.Drawing.Size(296, 20);
            this.datePickNaci.TabIndex = 4;
            // 
            // comboSexo
            // 
            this.comboSexo.FormattingEnabled = true;
            this.comboSexo.Items.AddRange(new object[] {
            "Hombre",
            "Mujer"});
            this.comboSexo.Location = new System.Drawing.Point(46, 98);
            this.comboSexo.Name = "comboSexo";
            this.comboSexo.Size = new System.Drawing.Size(130, 21);
            this.comboSexo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sexo:";
            // 
            // textApellidos
            // 
            this.textApellidos.Location = new System.Drawing.Point(240, 62);
            this.textApellidos.Name = "textApellidos";
            this.textApellidos.Size = new System.Drawing.Size(176, 20);
            this.textApellidos.TabIndex = 1;
            // 
            // textCifNif
            // 
            this.textCifNif.Location = new System.Drawing.Point(217, 25);
            this.textCifNif.Name = "textCifNif";
            this.textCifNif.Size = new System.Drawing.Size(199, 20);
            this.textCifNif.TabIndex = 1;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(59, 62);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(117, 20);
            this.textNombre.TabIndex = 1;
            // 
            // textCodigo
            // 
            this.textCodigo.Location = new System.Drawing.Point(55, 25);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(121, 20);
            this.textCodigo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Apellidos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 246);
            this.Controls.Add(this.groupSocio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.Text = "Nuevo Socio";
            this.groupSocio.ResumeLayout(false);
            this.groupSocio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupSocio;
        private System.Windows.Forms.TextBox textCifNif;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textApellidos;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePickNaci;
        private System.Windows.Forms.ComboBox comboSexo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private Afan.gestionDataSetTableAdapters.clientesTableAdapter clientesTableAdapter;
    }
}