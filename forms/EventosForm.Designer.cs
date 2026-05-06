namespace eventPlus.Forms
{
    partial class EventosForm
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvEventos = new System.Windows.Forms.DataGridView();
            this.dgvInvitados = new System.Windows.Forms.DataGridView();
            this.btnDetalle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvitados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(552, 381);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(80, 45);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnDeshabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeshabilitar.Location = new System.Drawing.Point(668, 381);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(103, 45);
            this.btnDeshabilitar.TabIndex = 17;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.UseVisualStyleBackColor = false;
            this.btnDeshabilitar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(220, 381);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(92, 45);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(70, 381);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(96, 45);
            this.btnCrear.TabIndex = 15;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(262, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(253, 31);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "          Eventos          ";
            // 
            // dgvEventos
            // 
            this.dgvEventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventos.Location = new System.Drawing.Point(12, 72);
            this.dgvEventos.Name = "dgvEventos";
            this.dgvEventos.Size = new System.Drawing.Size(433, 281);
            this.dgvEventos.TabIndex = 14;
            // 
            // dgvInvitados
            // 
            this.dgvInvitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvitados.Location = new System.Drawing.Point(451, 72);
            this.dgvInvitados.Name = "dgvInvitados";
            this.dgvInvitados.Size = new System.Drawing.Size(322, 281);
            this.dgvInvitados.TabIndex = 19;
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(353, 381);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(92, 45);
            this.btnDetalle.TabIndex = 21;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // EventosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(785, 450);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.dgvInvitados);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvEventos);
            this.Name = "EventosForm";
            this.Text = "EventosForm";
            this.Load += new System.EventHandler(this.EventosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvitados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnDeshabilitar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvEventos;
        private System.Windows.Forms.DataGridView dgvInvitados;
        private System.Windows.Forms.Button btnDetalle;
    }
}