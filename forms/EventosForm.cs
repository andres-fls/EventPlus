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
        private void EventosForm_Load(object sender, System.EventArgs e)
        {
            if (usuarioActual.Rol == "Invitado")
            {
                dgvUsuarios.Visible = false;

                btnCrear.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
            }
        }
        private void btnCrear_Click(object sender, System.EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, System.EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, System.EventArgs e)
        {

        }

        
    }
}