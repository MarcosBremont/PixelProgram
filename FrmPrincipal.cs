using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pixel_Program
{
    public partial class FrmPrincipal : Form
    {
        private bool mousePresionado;
        private Point posicionInicial;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            FrmIngresos formularioIngresos = new FrmIngresos();
            formularioIngresos.Show();
            Hide();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            FrmGastos formularioGastos = new FrmGastos();
            formularioGastos.Show();
            Hide();

        }

        private void FrmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            // Verificar si se ha presionado el botón izquierdo del mouse
            if (e.Button == MouseButtons.Left)
            {
                mousePresionado = true;
                // Guardar la posición inicial del formulario
                posicionInicial = new Point(e.X, e.Y);
            }
        }

        private void FrmPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            // Verificar si se está moviendo el formulario con el botón izquierdo del mouse presionado
            if (mousePresionado)
            {
                // Obtener la posición actual del mouse
                Point nuevaPosicion = PointToScreen(new Point(e.X, e.Y));
                // Calcular la nueva posición del formulario sumando la diferencia entre la posición actual y la inicial
                Location = new Point(nuevaPosicion.X - posicionInicial.X, nuevaPosicion.Y - posicionInicial.Y);
            }
        }

        private void FrmPrincipal_MouseUp(object sender, MouseEventArgs e)
        {
            // Se ha soltado el botón del mouse, por lo que el formulario ya no se moverá
            mousePresionado = false;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario formularioInventario = new FrmInventario();
            formularioInventario.Show();
            Hide();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FrmVenta formularioVenta = new FrmVenta();
            formularioVenta.Show();
            Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes formularioReportes = new FrmReportes();
            formularioReportes.Show();
            Hide();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos formularioPedidos = new FrmPedidos();
            formularioPedidos.Show();
            Hide();
        }
    }
}
