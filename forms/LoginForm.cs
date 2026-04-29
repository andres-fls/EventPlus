using System;
using System.Windows.Forms;
using eventPlus.Models;
using eventPlus.Services;

namespace eventPlus.Forms
{
    public partial class LoginForm : Form
    {
        private UsuarioService usuarioService = new UsuarioService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string correo = txtCorreo.Text.Trim();
                string password = txtPassword.Text.Trim();

                // VALIDACIONES
                if (string.IsNullOrWhiteSpace(correo))
                {
                    MessageBox.Show("Ingrese el correo.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Ingrese la contraseña.");
                    return;
                }

                // LOGIN
                Usuario usuario = usuarioService.Login(correo, password);

                if (usuario == null)
                {
                    MessageBox.Show("Correo o contraseña incorrectos.");
                    return;
                }

                // ABRIR MENÚ
                MenuForm menu = new MenuForm(usuario);

                menu.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistroForm registro = new RegistroForm();

            registro.Show();

            this.Hide();
        }
    }
}