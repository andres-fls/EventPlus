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
                    eventos = eventoService.ObtenerTodos();
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
        // AGREGAR INVITADO AL EVENTO SELECCIONADO
        // =====================================
        private void btnAgregarInvitado_Click(object sender, EventArgs e)
        {
            Evento eventoSeleccionado = ObtenerEventoSeleccionado();
            Usuario invitadoSeleccionado = ObtenerInvitadoSeleccionado();

            if (eventoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un evento.");
                return;
            }

            if (invitadoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un invitado.");
                return;
            }

            // Verificar si ya está agregado
            if (eventoSeleccionado.InvitadosIds.Contains(invitadoSeleccionado.Id))
            {
                MessageBox.Show("Este invitado ya está en el evento.");
                return;
            }

            // Verificar cupo
            int invitadosActuales = eventoSeleccionado.InvitadosIds.Count;
            if (invitadosActuales >= eventoSeleccionado.cupoMaximo)
            {
                MessageBox.Show("El evento ya alcanzó el cupo máximo.");
                return;
            }

            try
            {
                eventoSeleccionado.InvitadosIds.Add(invitadoSeleccionado.Id);
                eventoService.EditarEvento(eventoSeleccionado);
                MessageBox.Show($"Invitado '{invitadoSeleccionado.Nombre}' agregado al evento.");
                CargarEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                CargarEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Evento seleccionado = ObtenerEventoSeleccionado();
            if (seleccionado == null) return;

            DetalleEventoForm detalle = new DetalleEventoForm(seleccionado);
            detalle.ShowDialog();
        }

        private void btnQuitarInvitado_Click(object sender, EventArgs e)
        {

        }
    }
}