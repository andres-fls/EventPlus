using System;
using System.Windows.Forms;
using eventPlus.Models;
using eventPlus.Services;
using MongoDB.Driver;

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
            txtCorreo.Text = txtCorreo.Text.Trim();
            txtPassword.Text = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese el correo");
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contraseña");
                txtPassword.Focus();
                return;
            }

            try
            {
                Usuario usuario = usuarioService.Login(txtCorreo.Text, txtPassword.Text);

                // ✅ Mensaje personalizado según el rol
                string mensaje = usuario.Rol == "Lider"
                    ? "Iniciaste sesión como Líder"
                    : "Iniciaste sesión como Invitado";

                MessageBox.Show(
                    $"¡Bienvenido {usuario.Nombre}! {mensaje}",
                    "Login exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                MenuForm menu = new MenuForm(usuario);
                menu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error de autenticación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtPassword.Clear();
                txtCorreo.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Deseas salir?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
                Application.Exit();
        }

        private void linkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistroForm registro = new RegistroForm();

            this.Hide();
            registro.ShowDialog();
            this.Show();

            txtCorreo.Clear();
            txtPassword.Clear();
            txtCorreo.Focus();
        }

    }
}