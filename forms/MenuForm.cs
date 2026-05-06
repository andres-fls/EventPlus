using System;
using System.Windows.Forms;
using eventPlus.Models;

namespace eventPlus.Forms
{
    public partial class MenuForm : Form
    {
        private Usuario usuarioActual;

        public MenuForm(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            lblUsuario.Text =
                $"{usuarioActual.Nombre} - {usuarioActual.Rol}";

            // SI ES INVITADO
            if (usuarioActual.Rol == "Invitado")
            {
                btnGestionEventos.Visible = false;
            }
        }

        // ==========================
        // CREAR EVENTOS
        // ==========================
        private void btnGestionEventos_Click(object sender, EventArgs e)
        {
            CrearEventoForm form =
                new CrearEventoForm(usuarioActual);

            this.Hide();

            form.ShowDialog();

            this.Show();
        }

        // ==========================
        // VER EVENTOS
        // ==========================
        private void btnMisEventos_Click(object sender, EventArgs e)
        {
            EventosForm form =
                new EventosForm(usuarioActual);

            this.Hide();

            form.ShowDialog();

            this.Show();
        }

        // ==========================
        // CERRAR SESIÓN
        // ==========================
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();

            login.Show();

            this.Close();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            RegistroForm registro = new RegistroForm();

            this.Hide();
            registro.ShowDialog();
            this.Show();

        }
    }
}