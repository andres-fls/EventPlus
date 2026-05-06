using eventPlus.Models;
using eventPlus.Services;
using System;
using System.Windows.Forms;

namespace eventPlus.Forms
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private UsuarioService usuarioService = new UsuarioService();

        private void btnVolver_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = txtNombre.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Password = txtPassword.Text,
                    Rol = "Invitado",
                    Cedula = txtCedula.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Genero = cmbGenero.SelectedItem.ToString(),
                    Edad = int.Parse(txtEdad.Text)
                };

                usuarioService.Registrar(usuario);

                MessageBox.Show("Registro exitoso.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void RegistroForm_Load(object sender, System.EventArgs e)
        {
            
        }
    }
}