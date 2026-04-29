using System.Windows.Forms;
using eventPlus.Models;

namespace eventPlus.Forms
{
    public partial class CrearEventoForm : Form
    {
        private Usuario usuarioActual;

        public CrearEventoForm(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;
        }
    }
}