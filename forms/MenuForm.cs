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
    }
}