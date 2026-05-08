using eventPlus.Models;
using eventPlus.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace eventPlus.Forms
{
    public partial class DetalleEventoForm : Form
    {
        private Evento eventoActual;
        private Usuario usuarioActual; 

        private UsuarioService usuarioService = new UsuarioService();
        private EventoService eventoService = new EventoService();

        public DetalleEventoForm(Evento evento, Usuario usuario)
        {
            InitializeComponent();
            eventoActual = evento;
            usuarioActual = usuario; 

            ConfigurarDataGridView();
            CargarDatosEvento();
            CargarInvitados();
            ConfigurarVistaPorRol();

            dgvInvitadosEvento.DefaultCellStyle.ForeColor = Color.Black;
            dgvInvitadosEvento.DefaultCellStyle.BackColor = Color.White;
            dgvInvitadosEvento.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvInvitadosEvento.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvInvitadosEvento.BackgroundColor = Color.White;
            dgvInvitadosEvento.GridColor = Color.Gray;

        }

        private void ConfigurarVistaPorRol()
        {
            if (usuarioActual.Rol == "Invitado")
            {
                btnQuitarInvitado.Visible = false; 
            }
        }

        // =============================================
        // CONFIGURAR COLUMNAS CON TODOS LOS DATOS
        // =============================================
        private void ConfigurarDataGridView()
        {
            dgvInvitadosEvento.AutoGenerateColumns = false;
            dgvInvitadosEvento.Columns.Clear();

            dgvInvitadosEvento.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 150
            });

            dgvInvitadosEvento.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo",
                Width = 200
            });

            dgvInvitadosEvento.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rol",
                HeaderText = "Rol",
                Width = 80
            });

            dgvInvitadosEvento.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cedula",
                HeaderText = "Cédula",
                Width = 120
            });

            dgvInvitadosEvento.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Width = 120
            });

            dgvInvitadosEvento.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Genero",
                HeaderText = "Género",
                Width = 100
            });

            dgvInvitadosEvento.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Edad",
                HeaderText = "Edad",
                Width = 60
            });

            // Opcional: Ajuste automático para que ocupe todo el ancho
            dgvInvitadosEvento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =============================================
        // MOSTRAR DATOS DEL EVENTO (usa tus Labels)
        // =============================================
        private void CargarDatosEvento()
        {
            lblNombreEvento.Text = eventoActual.NombreEvento;
            lblTipoEvento.Text = eventoActual.TipoEvento;        
            lblLugar.Text = eventoActual.LugarEvento;
            lblFecha.Text = eventoActual.Fecha.ToString("dd/MM/yyyy");
            lblHora.Text = DateTime.ParseExact(eventoActual.Hora, "HH:mm", null).ToString("HH:mm");
            lblTotalInvitados.Text = $"{eventoActual.InvitadosIds.Count}/{eventoActual.CupoMaximo}";
            lblCategoriaEvento.Text = eventoActual.CategoriaEvento;
        }

        // =============================================
        // CARGAR INVITADOS ASIGNADOS
        // =============================================
        private void CargarInvitados()
        {
            List<Usuario> invitados = usuarioService.ObtenerPorIds(eventoActual.InvitadosIds);
            dgvInvitadosEvento.DataSource = null;
            dgvInvitadosEvento.DataSource = invitados;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitarInvitado_Click_1(object sender, EventArgs e)
        {
            if (dgvInvitadosEvento.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un invitado para quitar.");
                return;
            }

            Usuario invitadoSeleccionado = (Usuario)dgvInvitadosEvento.SelectedRows[0].DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Quitar a {invitadoSeleccionado.Nombre} del evento {eventoActual.NombreEvento}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            eventoActual.InvitadosIds.Remove(invitadoSeleccionado.Id);
            eventoService.EditarEvento(eventoActual);

            MessageBox.Show($"Invitado {invitadoSeleccionado.Nombre} eliminado del evento.");
            CargarInvitados();
        }

        
    }
}