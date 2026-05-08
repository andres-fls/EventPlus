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
        private void CrearEventoForm_Load(object sender,EventArgs e)
        {
            // =============================
            // TIPOS EVENTO
            // =============================
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Público");
            cmbTipo.Items.Add("Privado");
            cmbTipo.SelectedIndex = 0; // opción por defecto

            // =============================
            // CONFIG DTP HORA
            // =============================
            dtpHora.Format =
                DateTimePickerFormat.Time;

            dtpHora.ShowUpDown = true;

            dtpFecha.MinDate = DateTime.Today;

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

                dtpHora.Value = DateTime.ParseExact(eventoEditar.Hora, "HH:mm", null);

                numCupo.Value = eventoEditar.CupoMaximo;   // si usas NumericUpDown
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

                    DescripcionEvento =
                        txtDescripcion.Text.Trim(),

                    LugarEvento =
                        txtLugar.Text.Trim(),

                    CategoriaEvento =
                        cmbCategEvento.SelectedItem
                        .ToString(),

                    TipoEvento =
                        cmbTipo.SelectedItem
                        .ToString(),

                    Fecha =
                        dtpFecha.Value.Date,

                    Hora = dtpHora.Value.ToString("HH:mm"),

                    CupoMaximo = (int)numCupo.Value,

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

                    eventoService.EditarEvento(
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}