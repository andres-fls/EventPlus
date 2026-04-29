namespace eventPlus.Forms
{
    partial class CrearEventoForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCupo = new System.Windows.Forms.Label();
            this.numCupo = new System.Windows.Forms.NumericUpDown();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpHoraEveFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaEveFin = new System.Windows.Forms.DateTimePicker();
            this.cmbCategEvento = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHoraEve = new System.Windows.Forms.DateTimePicker();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblfechafin = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.dtpFechaEve = new System.Windows.Forms.DateTimePicker();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblLugar = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtLugar = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCupo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.groupBox2.Controls.Add(this.dtpHoraEveFin);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpFechaEveFin);
            this.groupBox2.Controls.Add(this.chkActivo);
            this.groupBox2.Controls.Add(this.lblEstado);
            this.groupBox2.Controls.Add(this.dtpHoraEve);
            this.groupBox2.Controls.Add(this.lblCupo);
            this.groupBox2.Controls.Add(this.numCupo);
            this.groupBox2.Controls.Add(this.lblfechafin);
            this.groupBox2.Controls.Add(this.cmbTipo);
            this.groupBox2.Controls.Add(this.lblTipo);
            this.groupBox2.Controls.Add(this.lblFecha);
            this.groupBox2.Controls.Add(this.dtpFechaEve);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(460, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 322);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Seleccione fecha de inscripcion";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.ForeColor = System.Drawing.Color.White;
            this.chkActivo.Location = new System.Drawing.Point(158, 292);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(125, 24);
            this.chkActivo.TabIndex = 18;
            this.chkActivo.Text = "Evento Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.White;
            this.lblEstado.Location = new System.Drawing.Point(8, 293);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(60, 20);
            this.lblEstado.TabIndex = 17;
            this.lblEstado.Text = "Estado";
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.ForeColor = System.Drawing.Color.White;
            this.lblCupo.Location = new System.Drawing.Point(8, 203);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(105, 20);
            this.lblCupo.TabIndex = 6;
            this.lblCupo.Text = "Cupo maximo";
            // 
            // numCupo
            // 
            this.numCupo.Location = new System.Drawing.Point(158, 201);
            this.numCupo.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numCupo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCupo.Name = "numCupo";
            this.numCupo.Size = new System.Drawing.Size(79, 26);
            this.numCupo.TabIndex = 13;
            this.numCupo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Publico",
            "Privado"});
            this.cmbTipo.Location = new System.Drawing.Point(158, 244);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 28);
            this.cmbTipo.TabIndex = 14;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.ForeColor = System.Drawing.Color.White;
            this.lblTipo.Location = new System.Drawing.Point(8, 247);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(91, 20);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo evento";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.groupBox1.Controls.Add(this.cmbCategEvento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.lblLugar);
            this.groupBox1.Controls.Add(this.txtLugar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 373);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // dtpHoraEveFin
            // 
            this.dtpHoraEveFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEveFin.Location = new System.Drawing.Point(173, 140);
            this.dtpHoraEveFin.Name = "dtpHoraEveFin";
            this.dtpHoraEveFin.Size = new System.Drawing.Size(121, 26);
            this.dtpHoraEveFin.TabIndex = 18;
            // 
            // dtpFechaEveFin
            // 
            this.dtpFechaEveFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEveFin.Location = new System.Drawing.Point(173, 98);
            this.dtpFechaEveFin.Name = "dtpFechaEveFin";
            this.dtpFechaEveFin.Size = new System.Drawing.Size(121, 26);
            this.dtpFechaEveFin.TabIndex = 17;
            // 
            // cmbCategEvento
            // 
            this.cmbCategEvento.FormattingEnabled = true;
            this.cmbCategEvento.Items.AddRange(new object[] {
            "Deportivo",
            "Cultural",
            "Academico"});
            this.cmbCategEvento.Location = new System.Drawing.Point(10, 319);
            this.cmbCategEvento.Name = "cmbCategEvento";
            this.cmbCategEvento.Size = new System.Drawing.Size(150, 28);
            this.cmbCategEvento.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Categoria";
            // 
            // dtpHoraEve
            // 
            this.dtpHoraEve.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEve.Location = new System.Drawing.Point(12, 140);
            this.dtpHoraEve.Name = "dtpHoraEve";
            this.dtpHoraEve.ShowUpDown = true;
            this.dtpHoraEve.Size = new System.Drawing.Size(121, 26);
            this.dtpHoraEve.TabIndex = 12;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(6, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(144, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del Evento";
            // 
            // lblfechafin
            // 
            this.lblfechafin.AutoSize = true;
            this.lblfechafin.ForeColor = System.Drawing.Color.White;
            this.lblfechafin.Location = new System.Drawing.Point(169, 68);
            this.lblfechafin.Name = "lblfechafin";
            this.lblfechafin.Size = new System.Drawing.Size(127, 20);
            this.lblfechafin.TabIndex = 5;
            this.lblfechafin.Text = "Fecha fin evento";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(10, 54);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(374, 26);
            this.txtNombre.TabIndex = 8;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(6, 98);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(92, 20);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // dtpFechaEve
            // 
            this.dtpFechaEve.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEve.Location = new System.Drawing.Point(12, 98);
            this.dtpFechaEve.Name = "dtpFechaEve";
            this.dtpFechaEve.Size = new System.Drawing.Size(121, 26);
            this.dtpFechaEve.TabIndex = 10;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(10, 121);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(374, 99);
            this.txtDescripcion.TabIndex = 9;
            // 
            // lblLugar
            // 
            this.lblLugar.AutoSize = true;
            this.lblLugar.ForeColor = System.Drawing.Color.White;
            this.lblLugar.Location = new System.Drawing.Point(6, 234);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(50, 20);
            this.lblLugar.TabIndex = 3;
            this.lblLugar.Text = "Lugar";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(6, 68);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(145, 20);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha inicio evento";
            // 
            // txtLugar
            // 
            this.txtLugar.Location = new System.Drawing.Point(10, 257);
            this.txtLugar.Name = "txtLugar";
            this.txtLugar.Size = new System.Drawing.Size(374, 26);
            this.txtLugar.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(617, 391);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 35);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(208)))), ((int)(((byte)(245)))));
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(460, 391);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 35);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(323, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "CREAR EVENTO";
            // 
            // CrearEventoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Name = "CrearEventoForm";
            this.Text = "CrearEventoForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCupo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.NumericUpDown numCupo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpHoraEveFin;
        private System.Windows.Forms.DateTimePicker dtpFechaEveFin;
        private System.Windows.Forms.ComboBox cmbCategEvento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHoraEve;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblfechafin;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.DateTimePicker dtpFechaEve;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblLugar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
    }
}