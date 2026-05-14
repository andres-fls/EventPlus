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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsLetter(e.KeyChar)) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo se permiten letras","Advertencia");
                e.Handled = true;
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) &&
    e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show(
                    "Solo se permiten números",
                    "Advertencia");

                e.Handled = true;
            }

            if (txtCedula.Text.Length >= 10 &&
                e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show(
                    "El número de identificación solo puede tener maximo 10 números",
                    "Advertencia");

                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) &&e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show(
                    "Solo se permiten números",
                    "Advertencia");

                e.Handled = true;
            }

            if (txtTelefono.Text.Length >= 10 &&
                e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show(
                    "El número de Telefono solo puede tener maximo 10 números",
                    "Advertencia");

                e.Handled = true;
            }

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show(
                    "Solo se permiten números",
                    "Advertencia");

                e.Handled = true;
            }
            if (txtEdad.Text.Length >=2 &&
              e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show(
                    " La edad solo puede tener máximo 2 dígitos",
                    "Advertencia");

                e.Handled = true;
            }

        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}