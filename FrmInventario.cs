using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pixel_Program
{
    public partial class FrmInventario : Form
    {
        private GestionBaseDeDatos gestionBaseDatos;
        private bool mousePresionado;
        private Point posicionInicial;
        public FrmInventario()
        {
            InitializeComponent();

            gestionBaseDatos = new GestionBaseDeDatos(); // Inicializar la instancia de GestionBaseDatos


            // Agrega las columnas al DataGridView
            dataGridViewInventario.Columns.Add("IdColumn", "id");
            dataGridViewInventario.Columns.Add("NombreColumn", "Nombre");
            dataGridViewInventario.Columns.Add("DescripcionColumn", "Descripción");
            dataGridViewInventario.Columns.Add("cantidadColumn", "Cantidad");
            dataGridViewInventario.Columns.Add("PrecioColumn", "Precio");
            dataGridViewInventario.Columns.Add("LinkopaginaColumn", "Linkopagina");
            dataGridViewInventario.Columns.Add("PreciocompraColumn", "Linkopagina");

            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                gestionBaseDatos.AbrirConexion();

                string consulta = "SELECT id, nombre, descripcion, cantidad, precio, linkopagina, preciocompra FROM Productos";
                MySqlCommand comando = new MySqlCommand(consulta, gestionBaseDatos.conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                dataGridViewInventario.Rows.Clear();
                List<string> productosCantidadBaja = new List<string>();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0); // Suponiendo que el ID está en la posición 0
                    string nombre = reader.GetString(1);
                    string descripcion = reader.GetString(2);
                    int cantidad = reader.GetInt32(3);
                    decimal precio = reader.GetDecimal(4);
                    string linkopagina = reader.GetString(5);
                    decimal preciocompra = reader.GetDecimal(6);

                    dataGridViewInventario.Rows.Add(id, nombre, descripcion, cantidad, precio, linkopagina, preciocompra);

                    // Verificar si la cantidad es menor a 5
                    if (cantidad < 5)
                    {
                        // Agregar el nombre del producto a la lista de productos con cantidades bajas
                        productosCantidadBaja.Add(nombre);
                    }
                }

                reader.Close();

                // Verificar si hay productos con cantidades bajas
                if (productosCantidadBaja.Count > 0)
                {
                    // Construir el mensaje
                    string mensaje = "Los siguientes productos tienen una cantidad baja:\n";
                    foreach (string producto in productosCantidadBaja)
                    {
                        mensaje += "- " + producto + "\n";
                    }

                    // Mostrar el mensaje en un MessageBox o en un Label, como prefieras
                    labelCantidadBaja.Text = mensaje;
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
            finally
            {
                gestionBaseDatos.CerrarConexion();
                // Llama al método para calcular el total después de cargar los datos
                // (Si no necesitas calcular un total para el inventario, puedes omitir esta parte)
                // CalcularTotal();
            }
        }

        private void dataGridViewInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBoxProducto.Image = null;
            if (dataGridViewInventario.CurrentCell != null) // Verifica si se ha seleccionado alguna celda
            {
                int filaSeleccionada = dataGridViewInventario.CurrentCell.RowIndex;
                DataGridViewRow fila = dataGridViewInventario.Rows[filaSeleccionada];

                // Obtener los valores de las celdas de la fila seleccionada
                int id = Convert.ToInt32(fila.Cells["idColumn"].Value);
                if (id > 0)
                {

                    MostrarImagenDeProducto(id);
                    txtNombre.Text = fila.Cells["NombreColumn"].Value.ToString();
                    txtDescripcion.Text = fila.Cells["DescripcionColumn"].Value.ToString();
                    txtCantidad.Text = fila.Cells["CantidadColumn"].Value.ToString();
                    txtPrecio.Text = fila.Cells["PrecioColumn"].Value.ToString();
                    txtLinkopagina.Text = fila.Cells["linkopaginaColumn"].Value.ToString();
                    txtPrecioCompra.Text = fila.Cells["preciocompraColumn"].Value.ToString();
                    //gestionBaseDatos.ActualizarGasto(idGasto, nuevaDescripcion, nuevoMonto, nuevaFecha);
                }
                //MessageBox.Show("Gasto actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("Selecciona una celda para actualizar el gasto.");
            }
        }



        private void MostrarImagenDeProducto(int idProducto)
        {
            try
            {
                // Obtener los bytes de la imagen de la base de datos
                string consulta = "SELECT imagen FROM Productos WHERE id = @idProducto";
                MySqlCommand comando = new MySqlCommand(consulta, gestionBaseDatos.conexion);
                comando.Parameters.AddWithValue("@idProducto", idProducto);

                gestionBaseDatos.AbrirConexion();
                byte[] bytesImagen = (byte[])comando.ExecuteScalar();

                // Convertir los bytes de la imagen a un objeto Image
                using (MemoryStream ms = new MemoryStream(bytesImagen))
                {
                    pictureBoxProducto.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Este producto no contiene imagen");
            }
            finally
            {
                gestionBaseDatos.CerrarConexion();
            }
        }

        public void limpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewInventario.SelectedCells.Count > 0)
            {
                int filaSeleccionadaIndex = dataGridViewInventario.SelectedCells[0].RowIndex;
                DataGridViewRow filaSeleccionada = dataGridViewInventario.Rows[filaSeleccionadaIndex];

                int id = Convert.ToInt32(filaSeleccionada.Cells["IdColumn"].Value);
                string nuevaNombre = txtNombre.Text;
                string nuevaDescripcion = txtDescripcion.Text;
                int nuevaCantidad = Convert.ToInt32(txtCantidad.Text);
                decimal nuevoprecio;
                string nuevaLinkopagina = txtLinkopagina.Text;
                decimal nuevopreciocompra = Convert.ToDecimal(txtPrecioCompra.Text);


                if (decimal.TryParse(txtPrecio.Text, out nuevoprecio))
                {
                    gestionBaseDatos.ActualizarProducto(id, nuevaNombre, nuevaDescripcion, nuevaCantidad, nuevoprecio, nuevaLinkopagina, nuevopreciocompra);
                    CargarProductos(); // Recargar los gastos después de la actualización
                    MessageBox.Show("Producto actualizado correctamente.");
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un monto válido y una fecha válida.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una celda para actualizar el gasto.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewInventario.SelectedRows.Count > 0)
            {
                // Obtener el ID del gasto seleccionado
                int id = Convert.ToInt32(dataGridViewInventario.SelectedCells[0].Value);

                // Confirmar con el usuario si realmente desea eliminar el gasto
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al método para eliminar el gasto de la base de datos
                    gestionBaseDatos.EliminarProducto(id);

                    // Volver a cargar los gastos en el DataGridView después de eliminar
                    CargarProductos();
                    limpiarCampos();

                    MessageBox.Show("El producto se ha eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verifica que todos los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioCompra.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Verifica que los valores numéricos sean válidos
            if (!int.TryParse(txtCantidad.Text, out int cantidad) ||
                !decimal.TryParse(txtPrecio.Text, out decimal precio) ||
                !decimal.TryParse(txtPrecioCompra.Text, out decimal preciocompra))
            {
                MessageBox.Show("Ingrese valores numéricos válidos en los campos 'Cantidad', 'Precio' y 'Precio de compra'.");
                return;
            }

            // Insertar el producto en la base de datos
            gestionBaseDatos.InsertarProducto(txtNombre.Text, txtDescripcion.Text, cantidad, precio, txtLinkopagina.Text, preciocompra, txtRutaImagen.Text);

            // Recargar los productos en el DataGridView después de insertar uno nuevo
            CargarProductos();
            MessageBox.Show("Producto agregado correctamente.");

            // Limpiar los campos después de agregar el producto
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtLinkopagina.Clear();
            txtPrecioCompra.Clear();
            txtRutaImagen.Clear();
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

        private void FrmInventario_MouseDown(object sender, MouseEventArgs e)
        {
            // Verificar si se ha presionado el botón izquierdo del mouse
            if (e.Button == MouseButtons.Left)
            {
                mousePresionado = true;
                // Guardar la posición inicial del formulario
                posicionInicial = new Point(e.X, e.Y);
            }
        }

        private void FrmInventario_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmInventario_MouseUp(object sender, MouseEventArgs e)
        {
            // Se ha soltado el botón del mouse, por lo que el formulario ya no se moverá
            mousePresionado = false;
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            // Crear un nuevo OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Establecer las propiedades del OpenFileDialog
            openFileDialog.Title = "Seleccionar imagen";
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*";
            openFileDialog.Multiselect = false; // Permitir la selección de un solo archivo

            // Mostrar el cuadro de diálogo y comprobar si el usuario hizo clic en el botón Aceptar
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado y mostrarla en un TextBox o en otro lugar
                string rutaImagenSeleccionada = openFileDialog.FileName;
                txtRutaImagen.Text = rutaImagenSeleccionada;
            }
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

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
