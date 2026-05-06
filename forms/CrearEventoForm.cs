using eventPlus.Models;
using eventPlus.Services;
using System;
using System.Windows.Forms;

namespace eventPlus.Forms
{
    public partial class CrearEventoForm : Form
    {
        // =====================================
        // USUARIO ACTUAL
        // =====================================
        private Usuario usuarioActual;

        // =====================================
        // EVENTO EN EDICION
        // =====================================
        private Evento eventoEditar;

        // =====================================
        // SERVICE
        // =====================================
        private EventoService eventoService =
            new EventoService();

        // =====================================
        // CONSTRUCTOR CREAR
        // =====================================
        public CrearEventoForm(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;
        }

        // =====================================
        // CONSTRUCTOR EDITAR
        // =====================================
        public CrearEventoForm(
            Usuario usuario,
            Evento evento)
        {
            InitializeComponent();

            usuarioActual = usuario;

            eventoEditar = evento;
        }

        // =====================================
        // LOAD
        // =====================================
        private void CrearEventoForm_Load(
            object sender,
            EventArgs e)
        {
            // =============================
            // TIPOS EVENTO
            // =============================
            cmbTipo.Items.Clear();

            cmbTipo.Items.Add("Academico");
            cmbTipo.Items.Add("Deportivo");
            cmbTipo.Items.Add("Cultural");

            // =============================
            // CONFIG DTP HORA
            // =============================
            dtpHora.Format =
                DateTimePickerFormat.Time;

            dtpHora.ShowUpDown = true;

            // =============================
            // MODO EDICION
            // =============================
            if (eventoEditar != null)
            {
                this.Text = "Editar Evento";

                txtNombre.Text =
                    eventoEditar.NombreEvento;

                cmbTipo.SelectedItem =
                    eventoEditar.TipoEvento;

                dtpFecha.Value =
                    eventoEditar.Fecha;

                dtpHora.Value =
                    eventoEditar.Hora;
            }
        }

        // =====================================
        // GUARDAR
        // =====================================
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            // =============================
            // VALIDACIONES
            // =============================
            if (string.IsNullOrWhiteSpace(
                txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del evento.");

                return;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un tipo de evento.");

                return;
            }

            try
            {
                // =========================
                // CREAR OBJETO
                // =========================
                Evento evento = new Evento()
                {
                    NombreEvento =
                        txtNombre.Text.Trim(),

                    TipoEvento =
                        cmbTipo.SelectedItem
                        .ToString(),

                    Fecha =
                        dtpFecha.Value.Date,

                    Hora =
                        dtpHora.Value,

                    IdLider =
                        usuarioActual.Id,

                    Activo = true
                };

                // =========================
                // CREAR
                // =========================
                if (eventoEditar == null)
                {
                    eventoService.CrearEvento(
                        evento);

                    MessageBox.Show(
                        "Evento creado correctamente.");
                }

                // =========================
                // EDITAR
                // =========================
                else
                {
                    evento.Id =
                        eventoEditar.Id;

                    eventoService.ActualizarEvento(
                        evento);

                    MessageBox.Show(
                        "Evento actualizado.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================
        // CANCELAR
        // =====================================
        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}