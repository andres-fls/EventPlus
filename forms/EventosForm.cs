using System.Windows.Forms;
using eventPlus.Models;

namespace eventPlus.Forms
{
    public partial class EventosForm : Form
    {
        private Usuario usuarioActual;

        public EventosForm(Usuario usuario)
        {
            InitializeComponent();

            usuarioActual = usuario;
        }
    }
}