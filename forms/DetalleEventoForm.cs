using eventPlus.Models;
using eventPlus.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eventPlus.Forms
{
    public partial class DetalleEventoForm : Form
    {
        // =====================================
        // EVENTO SELECCIONADO
        // =====================================
        private Evento eventoSeleccionado;

        // =====================================
        // SERVICES
        // =====================================
        private UsuarioService usuarioService =
            new UsuarioService();

        // =====================================
        // CONSTRUCTOR
        // =====================================
        public DetalleEventoForm(Evento evento)
        {
            InitializeComponent();

            eventoSeleccionado = evento;
        }

        // =====================================
        // LOAD
        // =====================================
        private void DetalleEventoForm_Load(
            object sender,
            EventArgs e)
        {
            MostrarDatosEvento();

            CargarInvitados();
        }

        // =====================================
        // MOSTRAR DATOS EVENTO
        // =====================================
        private void MostrarDatosEvento()
        {
            lblNombreEvento.Text =
                eventoSeleccionado.NombreEvento;

            lblTipoEvento.Text =
                eventoSeleccionado.TipoEvento;

            lblFecha.Text =
                eventoSeleccionado.Fecha
                .ToShortDateString();

            lblHora.Text =
                eventoSeleccionado.Hora
                .ToShortTimeString();

            lblTotalInvitados.Text =
                eventoSeleccionado.cupoMaximo
                .ToString();

            lblEstado.Text =
                eventoSeleccionado.Activo
                ? "Activo"
                : "Deshabilitado";
        }

        // =====================================
        // CARGAR INVITADOS
        // =====================================
        private void CargarInvitados()
        {
            try
            {
                List<Usuario> invitados =
                    usuarioService.ObtenerPorIds(
                        eventoSeleccionado.InvitadosIds);

                dgvInvitados.DataSource = null;

                dgvInvitados.DataSource =
                    invitados;

                // =========================
                // CONFIG COLUMNAS
                // =========================
                dgvInvitados.Columns["Id"]
                    .Visible = false;

                dgvInvitados.Columns["Password"]
                    .Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =====================================
        // CERRAR
        // =====================================
        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}