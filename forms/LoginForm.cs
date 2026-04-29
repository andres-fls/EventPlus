using System;
using System.Windows.Forms;
using eventPlus.Services;
using eventPlus;

namespace eventPlus.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegistroForm().Show();
            this.Hide();
        }
    }
}