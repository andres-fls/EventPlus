namespace eventPlus.Forms
{
    partial class MenuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnMisEventos = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnGestionEventos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "                Bienvenido                ";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(56, 90);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(220, 25);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "       Nombre usuario       ";
            // 
            // btnMisEventos
            // 
            this.btnMisEventos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMisEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisEventos.Location = new System.Drawing.Point(109, 282);
            this.btnMisEventos.Name = "btnMisEventos";
            this.btnMisEventos.Size = new System.Drawing.Size(111, 45);
            this.btnMisEventos.TabIndex = 2;
            this.btnMisEventos.Text = "Mis eventos";
            this.btnMisEventos.UseVisualStyleBackColor = false;
            this.btnMisEventos.Click += new System.EventHandler(this.btnMisEventos_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(96, 344);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(133, 43);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnGestionEventos
            // 
            this.btnGestionEventos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGestionEventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionEventos.Location = new System.Drawing.Point(109, 214);
            this.btnGestionEventos.Name = "btnGestionEventos";
            this.btnGestionEventos.Size = new System.Drawing.Size(111, 50);
            this.btnGestionEventos.TabIndex = 4;
            this.btnGestionEventos.Text = "Gestionar eventos";
            this.btnGestionEventos.UseVisualStyleBackColor = false;
            this.btnGestionEventos.Click += new System.EventHandler(this.btnGestionEventos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.Controls.Add(this.btnRegistro);
            this.groupBox1.Controls.Add(this.btnMisEventos);
            this.groupBox1.Controls.Add(this.btnGestionEventos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCerrarSesion);
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 405);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnRegistro
            // 
            this.btnRegistro.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Location = new System.Drawing.Point(109, 141);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(111, 49);
            this.btnRegistro.TabIndex = 5;
            this.btnRegistro.Text = "Registrar usuario";
            this.btnRegistro.UseVisualStyleBackColor = false;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(360, 430);
            this.Controls.Add(this.groupBox1);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnMisEventos;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnGestionEventos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRegistro;
    }
}