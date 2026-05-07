using eventPlus.Models;
using eventPlus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eventPlus.Forms
{
    public partial class EventosForm : Form
    {
        private Usuario usuarioActual;
        private EventoService eventoService = new EventoService();
        private UsuarioService usuarioService = new UsuarioService();

        public EventosForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            dgvEventos.SelectionChanged += dgvEventos_SelectionChanged;
        }

        private void EventosForm_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasEventos();
            ConfigurarColumnasInvitados();
            ConfigurarVistaPorRol();
            CargarEventos();
            CargarTodosInvitados();
        }

        // =====================================
        // CONFIGURAR COLUMNAS DGV EVENTOS
        // =====================================
        private void ConfigurarColumnasEventos()
        {
            dgvEventos.AutoGenerateColumns = false;
            dgvEventos.Columns.Clear();

            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreEvento",
                HeaderText = "Evento",
                Width = 150
            });

            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Hora",
                HeaderText = "Hora",
                Width = 45,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" }
            });

            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "lugarEvento",
                HeaderText = "Lugar",
                Width = 150
            });

            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "cupoMaximo",
                HeaderText = "Cupo",
                Width = 40
            });

            dgvEventos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Activo",
                HeaderText = "Activo",
                Width = 40
            });

        }

        // =====================================
        // CONFIGURAR COLUMNAS DGV INVITADOS
        // =====================================
        private void ConfigurarColumnasInvitados()
        {
            dgvInvitados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvitados.MultiSelect = true;
            dgvInvitados.AutoGenerateColumns = false;
            dgvInvitados.Columns.Clear();

            dgvInvitados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Width = 100
            });

            dgvInvitados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo",
                Width = 130
            });

            dgvInvitados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Width = 75
            });

            dgvInvitados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Edad",
                HeaderText = "Edad",
                Width = 30
            });
        }

        private void dgvEventos_SelectionChanged(object sender, EventArgs e)
        {
            Evento seleccionado = ObtenerEventoSeleccionado();
            if (seleccionado != null)
            {
                btnDeshabilitar.Text = seleccionado.Activo ? "Deshabilitar" : "Habilitar";
            }
        }

        // =====================================
        // CONFIGURAR SEGUN ROL
        // =====================================
        private void ConfigurarVistaPorRol()
        {
            if (usuarioActual.Rol == "Invitado")
            {
                dgvInvitados.Visible = false;
                btnAgregarInvitado.Visible = false;
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

                if (usuarioActual.Rol == "Lider")
                {
                    eventos = eventoService.ObtenerTodos(false);
                }
                else
                {
                    eventos = eventoService.ObtenerEventosInvitado(usuarioActual.Id);
                }

                dgvEventos.DataSource = null;
                dgvEventos.DataSource = eventos;
                dgvEventos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar eventos: " + ex.Message);
            }
        }

        // =====================================
        // CARGAR TODOS LOS INVITADOS DISPONIBLES
        // =====================================
        private void CargarTodosInvitados()
        {
            try
            {
                List<Usuario> invitados = usuarioService.ObtenerInvitados();
                dgvInvitados.DataSource = null;
                dgvInvitados.DataSource = invitados;
                dgvInvitados.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar invitados: " + ex.Message);
            }
        }

        // =====================================
        // OBTENER EVENTO SELECCIONADO
        // =====================================
        private Evento ObtenerEventoSeleccionado()
        {
            if (dgvEventos.SelectedRows.Count == 0)
                return null;

            return (Evento)dgvEventos.SelectedRows[0].DataBoundItem;
        }

        // =====================================
        // OBTENER INVITADO SELECCIONADO
        // =====================================
        private Usuario ObtenerInvitadoSeleccionado()
        {
            if (dgvInvitados.SelectedRows.Count == 0)
                return null;

            return (Usuario)dgvInvitados.SelectedRows[0].DataBoundItem;
        }

        // =====================================
        // BOTONES
        // =====================================
        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearEventoForm form = new CrearEventoForm(usuarioActual);
            form.ShowDialog();
            CargarEventos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Evento seleccionado = ObtenerEventoSeleccionado();
            if (seleccionado == null) return;

            CrearEventoForm editar = new CrearEventoForm(usuarioActual, seleccionado);
            editar.ShowDialog();
            CargarEventos();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            Evento seleccionado = ObtenerEventoSeleccionado();
            if (seleccionado == null) return;

            if (seleccionado.Activo)
            {
                // DESHABILITAR
                DialogResult confirmacion = MessageBox.Show(
                    "¿Deseas deshabilitar este evento?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion != DialogResult.Yes) return;

                try
                {
                    eventoService.DeshabilitarEvento(seleccionado.Id);
                    MessageBox.Show("Evento deshabilitado.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                // HABILITAR
                DialogResult confirmacion = MessageBox.Show(
                    "¿Deseas habilitar este evento?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes) return;

                try
                {
                    eventoService.HabilitarEvento(seleccionado.Id);
                    MessageBox.Show("Evento habilitado.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            CargarEventos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Evento seleccionado = ObtenerEventoSeleccionado();
            if (seleccionado == null) return;

            DetalleEventoForm detalle = new DetalleEventoForm(seleccionado, usuarioActual);
            detalle.ShowDialog();

            CargarEventos();
        }

        private void btnAgregarInvitado_Click_1(object sender, EventArgs e)
        {
            Evento eventoSeleccionado = ObtenerEventoSeleccionado();
            if (eventoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un evento.");
                return;
            }

            if (dgvInvitados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un invitado.");
                return;
            }

            int agregados = 0;
            List<string> errores = new List<string>();

            foreach (DataGridViewRow row in dgvInvitados.SelectedRows)
            {
                Usuario invitado = (Usuario)row.DataBoundItem;

                // Verificar si ya está en el evento
                if (eventoSeleccionado.InvitadosIds.Contains(invitado.Id))
                {
                    errores.Add($"{invitado.Nombre} ya está en el evento.");
                    continue;
                }

                // Verificar cupo
                if (eventoSeleccionado.InvitadosIds.Count >= eventoSeleccionado.cupoMaximo)
                {
                    errores.Add($"Cupo máximo alcanzado ({eventoSeleccionado.cupoMaximo}). No se pudo agregar a {invitado.Nombre}.");
                    break; // ya no hay campo para nadie más
                }

                // Validar conflicto de horario
                bool conflicto = eventoService.InvitadoTieneConflicto(
                    invitado.Id,
                    eventoSeleccionado.Fecha,
                    eventoSeleccionado.Hora,
                    eventoSeleccionado.Id);

                if (conflicto)
                {
                    errores.Add($"{invitado.Nombre} ya tiene otro evento en ese horario.");
                    continue;
                }

                // Agregar
                eventoSeleccionado.InvitadosIds.Add(invitado.Id);
                agregados++;
            }

            // Guardar cambios si al menos uno fue agregado
            if (agregados > 0)
            {
                try
                {
                    eventoService.EditarEvento(eventoSeleccionado);
                    CargarEventos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                    return;
                }
            }

            // Mostrar resumen
            string mensaje = $"Invitados agregados: {agregados}.";
            if (errores.Count > 0)
                mensaje += "\n\nNo se agregaron:\n" + string.Join("\n", errores);

            MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK,
                agregados > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
    }
}