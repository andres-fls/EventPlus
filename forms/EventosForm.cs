using eventPlus.Forms;
using eventPlus.Models;
using eventPlus.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eventPlus.Forms
{
    public partial class EventosForm : Form
    {
        private Usuario usuarioActual;

        private EventoService eventoService =
            new EventoService();

        private UsuarioService usuarioService =
            new UsuarioService();

        public EventosForm(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;

            dgvEventos.SelectionChanged +=
                dgvEventos_SelectionChanged;
        }

        private void EventosForm_Load(object sender, System.EventArgs e)
        {
            ConfigurarVistaPorRol();

            CargarEventos();
        }

        // =====================================
        // CONFIGURAR SEGUN ROL
        // =====================================
        private void ConfigurarVistaPorRol()
        {
            if (usuarioActual.Rol == "Invitado")
            {
                dgvInvitados.Visible = false;

                btnCrear.Visible = false;
                btnEditar.Visible = false;
                btnDeshabilitar.Visible = false;
            }
        }

        // =====================================
        // CARGAR EVENTOS
        // =====================================
        private void CargarEventos()
        {
            try
            {
                List<Evento> eventos;

                // =========================
                // SI ES LIDER
                // =========================
                if (usuarioActual.Rol == "Lider")
                {
                    eventos =
                        eventoService.ObtenerTodos();
                }

                // =========================
                // SI ES INVITADO
                // =========================
                else
                {
                    eventos =
                        eventoService.ObtenerEventosInvitado(
                            usuarioActual.Id);
                }

                dgvEventos.DataSource = null;
                dgvEventos.DataSource = eventos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar eventos: "
                    + ex.Message);
            }
        }

        private void dgvEventos_SelectionChanged(object sender,EventArgs e)
        {
            CargarInvitadosEvento();
        }

        private void CargarInvitadosEvento()
        {
            try
            {
                Evento seleccionado =
                    ObtenerEventoSeleccionado();

                if (seleccionado == null)
                    return;

                List<Usuario> invitados =
                    usuarioService.ObtenerPorIds(
                        seleccionado.InvitadosIds);

                dgvInvitados.DataSource = null;
                dgvInvitados.DataSource = invitados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Evento ObtenerEventoSeleccionado()
        {
            if (dgvEventos.SelectedRows.Count == 0)
            {
                return null;
            }

            return
                (Evento)dgvEventos.SelectedRows[0]
                .DataBoundItem;
        }

        private void btnCrear_Click(object sender, System.EventArgs e)
        {
            CrearEventoForm form =
                new CrearEventoForm(usuarioActual);

            form.ShowDialog();

            CargarEventos();
        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            Evento seleccionado =
                ObtenerEventoSeleccionado();

            if (seleccionado == null)
                return;

            CrearEventoForm editar =
                new CrearEventoForm(
                    usuarioActual,
                    seleccionado);

            editar.ShowDialog();

            CargarEventos();
        }

        

        private void btnDeshabilitar_Click(object sender, System.EventArgs e)
        {
            Evento seleccionado =
                ObtenerEventoSeleccionado();

            if (seleccionado == null)
                return;

            DialogResult confirmacion =
                MessageBox.Show(
                    "¿Deseas deshabilitar este evento?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                eventoService.DeshabilitarEvento(
                    seleccionado.Id);

                MessageBox.Show(
                    "Evento deshabilitado.");

                CargarEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVolver_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Evento seleccionado =
                ObtenerEventoSeleccionado();

            if (seleccionado == null)
                return;

            DetalleEventoForm detalle =
                new DetalleEventoForm(
                    seleccionado);

            detalle.ShowDialog();
        }
    }
}