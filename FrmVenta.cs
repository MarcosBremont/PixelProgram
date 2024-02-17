using MySql.Data.MySqlClient;
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
    public partial class FrmVenta : Form
    {
        private GestionBaseDeDatos gestionBaseDatos;
        private Dictionary<string, decimal> diccionarioNombresYPreciosProductos;

        private bool mousePresionado;
        private Point posicionInicial;
        public FrmVenta()
        {
            InitializeComponent();
            gestionBaseDatos = new GestionBaseDeDatos(); // Inicializar la instancia de GestionBaseDatos

            // Agrega las columnas al DataGridView
            dataGridViewVentas.Columns.Add("IdColumn", "id");
            dataGridViewVentas.Columns.Add("DescripcionColumn", "Descripción");
            dataGridViewVentas.Columns.Add("MontoColumn", "Monto");
            dataGridViewVentas.Columns.Add("FechaColumn", "Fecha");
            dataGridViewVentas.Columns.Add("ClienteColumn", "Cliente");
            CargarProductosEnComboBox();
            CargarIngresos();
        }

        private void CargarIngresos()
        {
            try
            {
                gestionBaseDatos.AbrirConexion();

                string consulta = "SELECT id, descripcion, monto, fecha, cliente FROM ingresos";
                MySqlCommand comando = new MySqlCommand(consulta, gestionBaseDatos.conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                dataGridViewVentas.Rows.Clear();

                while (reader.Read())
                {
                    int idIngreso = reader.GetInt32(0); // Suponiendo que el ID está en la posición 0
                    string descripcion = reader.GetString(1);
                    decimal monto = reader.GetDecimal(2);
                    DateTime fecha = reader.GetDateTime(3);
                    string cliente = reader.GetString(4);


                    dataGridViewVentas.Rows.Add(idIngreso, descripcion, monto, fecha, cliente);
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los ingresos: " + ex.Message);
            }
            finally
            {
                gestionBaseDatos.CerrarConexion();
                CalcularTotalIngresos();
            }
        }

        private void CargarProductosEnComboBox()
        {
            diccionarioNombresYPreciosProductos = gestionBaseDatos.ObtenerNombresYPreciosProductos();
            cmbProductos.DataSource = new BindingSource(diccionarioNombresYPreciosProductos, null);
            cmbProductos.DisplayMember = "key";
            cmbProductos.ValueMember = "Value";
        }

        // Manejar el evento SelectedIndexChanged para manejar la selección del usuario
        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem != null)
            {
                string seleccionCompleta = cmbProductos.SelectedItem.ToString();
                string nombreProductoSeleccionado = seleccionCompleta.Substring(1, seleccionCompleta.IndexOf(",") - 1).Trim(); // Extraer el nombre del producto
                if (diccionarioNombresYPreciosProductos.ContainsKey(nombreProductoSeleccionado))
                {
                    decimal precioProducto = diccionarioNombresYPreciosProductos[nombreProductoSeleccionado];
                    txtPrecio.Text = precioProducto.ToString();
                }
            }
        }




        //private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void CalcularTotalIngresos()
        {
            decimal totalIngresos = 0;

            foreach (DataGridViewRow fila in dataGridViewVentas.Rows)
            {
                // Verifica si la fila no es la fila de encabezado
                if (!fila.IsNewRow)
                {
                    totalIngresos += Convert.ToDecimal(fila.Cells["MontoColumn"].Value);
                }
            }

            lbltotalingresos.Text = "Total: RD $" + totalIngresos.ToString("N2"); // Mostrar el total en el Label con formato de moneda
        }


        private void btnVender_Click(object sender, EventArgs e)
        {
            // Verifica que los campos obligatorios no estén vacíos
            if (cmbProductos.SelectedItem == null || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Verifica que los valores numéricos sean válidos
            if (!int.TryParse(txtCantidad.Text, out int cantidadVendida) || !decimal.TryParse(txtPrecio.Text, out decimal precioUnitario))
            {
                MessageBox.Show("Ingrese valores numéricos válidos en los campos 'Cantidad' y 'Precio'.");
                return;
            }

            // Obtener el nombre del producto seleccionado
            string seleccionCompleta = cmbProductos.Text;
            //int indiceComa = seleccionCompleta.IndexOf(",");
            //string nombreProducto = seleccionCompleta.Substring(1, indiceComa - 1);

            // Realizar la venta y actualizar la base de datos
            gestionBaseDatos.RegistrarVenta(seleccionCompleta, cantidadVendida, precioUnitario, txtNombreCliente.Text);
            CargarIngresos();

            // Mostrar un mensaje de confirmación
            MessageBox.Show("Venta realizada con éxito.");

            // Limpiar los controles del formulario después de realizar la venta
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            cmbProductos.SelectedItem = null;
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtNombreCliente.Clear();
        }


        private void FrmVenta_MouseDown(object sender, MouseEventArgs e)
        {
            // Verificar si se ha presionado el botón izquierdo del mouse
            if (e.Button == MouseButtons.Left)
            {
                mousePresionado = true;
                // Guardar la posición inicial del formulario
                posicionInicial = new Point(e.X, e.Y);
            }
        }

        private void FrmVenta_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmVenta_MouseUp(object sender, MouseEventArgs e)
        {
            // Se ha soltado el botón del mouse, por lo que el formulario ya no se moverá
            mousePresionado = false;
        }

        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            FrmPrincipal formularioPrincipal = new FrmPrincipal();
            formularioPrincipal.Show();
            Hide();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un dígito, el punto decimal o la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                // Si no es un dígito, el punto decimal o la tecla de retroceso, se marca el evento como manejado
                e.Handled = true;
            }

            // Permite solo un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un dígito, el punto decimal o la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                // Si no es un dígito, el punto decimal o la tecla de retroceso, se marca el evento como manejado
                e.Handled = true;
            }

            // Permite solo un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmbProductos_DropDown(object sender, EventArgs e)
        {

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {

        }
    }
}
