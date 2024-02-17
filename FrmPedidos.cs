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
    public partial class FrmPedidos : Form
    {
        private GestionBaseDeDatos gestionBaseDatos;
        private Dictionary<string, decimal> diccionarioNombresYPreciosProductos;
        // Definir una lista para almacenar los PictureBoxes
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private List<TextBox> textBoxes = new List<TextBox>();
        List<string> rutasImagenes = new List<string>(); // Declaración de la lista

        private bool mousePresionado;
        private Point posicionInicial;
        public FrmPedidos()
        {
            InitializeComponent();
            gestionBaseDatos = new GestionBaseDeDatos(); // Inicializar la instancia de GestionBaseDatos
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            // Agrega las columnas al DataGridView
            dataGridViewPedidos.Columns.Add("IdColumn", "ID");
            dataGridViewPedidos.Columns.Add("ClienteColumn", "Cliente");
            dataGridViewPedidos.Columns.Add("DescripcionColumn", "Descripcion");
            dataGridViewPedidos.Columns.Add("EstadoColumn", "Estado");
            dataGridViewPedidos.Columns.Add("Fecha_pedidoColumn", "Fecha Pedido");
            dataGridViewPedidos.Columns.Add("Fecha_entregaColumn", "Fecha Para Entrega");
            dataGridViewPedidos.Columns.Add("NotasColumn", "Notas");

            //CargarProductosEnComboBox();
            CargarPedidos();
        }

        // Declarar un PictureBox adicional para mostrar la imagen a tamaño completo
        private PictureBox pictureBoxFullscreen = new PictureBox();

        private void MostrarImagenCompleta(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            // Configurar el PictureBox de pantalla completa
            pictureBoxFullscreen.Image = pictureBox.Image;
            pictureBoxFullscreen.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxFullscreen.Dock = DockStyle.Fill;
            pictureBoxFullscreen.BackColor = Color.Black; // Opcional: Fondo negro para resaltar la imagen
            pictureBoxFullscreen.BorderStyle = BorderStyle.FixedSingle;

            // Crear un nuevo formulario para mostrar la imagen a tamaño completo
            Form formFullscreen = new Form();
            formFullscreen.Text = "Imagen Completa";
            formFullscreen.StartPosition = FormStartPosition.CenterScreen; // Alinear formulario al centro de la pantalla
            formFullscreen.Size = new Size(800, 600); // Tamaño predeterminado para la ventana

            // Agregar el PictureBox a la ventana del formulario
            formFullscreen.Controls.Add(pictureBoxFullscreen);

            // Mostrar el formulario
            formFullscreen.ShowDialog();
        }

        private void CargarPedidos()
        {
            try
            {
                gestionBaseDatos.AbrirConexion();

                string consulta = "SELECT * FROM pedidos";
                MySqlCommand comando = new MySqlCommand(consulta, gestionBaseDatos.conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                dataGridViewPedidos.Rows.Clear();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0); // Suponiendo que el ID está en la posición 0
                    string cliente = reader.GetString(1);
                    string descripcion = reader.GetString(2);
                    string estado = reader.GetString(3);
                    DateTime fecha_pedido = reader.GetDateTime(4);
                    DateTime fecha_entrega = reader.GetDateTime(5);
                    string notas = reader.GetString(6);


                    dataGridViewPedidos.Rows.Add(id, cliente, descripcion, estado, fecha_pedido, fecha_entrega, notas);
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los pedidos: " + ex.Message);
            }
            finally
            {
                gestionBaseDatos.CerrarConexion();
                //CalcularTotalIngresos();
            }
        }

        //private void CargarProductosEnComboBox()
        //{
        //    diccionarioNombresYPreciosProductos = gestionBaseDatos.ObtenerNombresYPreciosProductos();
        //    cmbProductos.DataSource = new BindingSource(diccionarioNombresYPreciosProductos, null);
        //    cmbProductos.DisplayMember = "key";
        //    cmbProductos.ValueMember = "Value";
        //}

        //private void CalcularTotalIngresos()
        //{
        //    decimal totalIngresos = 0;

        //    foreach (DataGridViewRow fila in dataGridViewPedidos.Rows)
        //    {
        //        // Verifica si la fila no es la fila de encabezado
        //        if (!fila.IsNewRow)
        //        {
        //            totalIngresos += Convert.ToDecimal(fila.Cells["MontoColumn"].Value);
        //        }
        //    }

        //    lbltotalingresos.Text = "Total: RD $" + totalIngresos.ToString("N2"); // Mostrar el total en el Label con formato de moneda
        //}


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


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si los campos obligatorios están llenos
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                cmbEstado.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtNotas.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los datos del pedido desde los controles del formulario
            string cliente = txtNombreCliente.Text;
            string descripcion = txtDescripcion.Text;
            string Estado = cmbEstado.SelectedItem.ToString();
            DateTime fecha_pedido = dateTimePicker1Pedido.Value;
            DateTime fecha_entrega = dateTimePicker2Pedidos.Value;
            string Notas = txtNotas.Text;

            // Realizar el pedido y actualizar la base de datos
            gestionBaseDatos.InsertarPedidos(cliente, descripcion, Estado, fecha_pedido, fecha_entrega, Notas);

            // Obtener el ID del pedido recién insertado
            int idPedido = gestionBaseDatos.ObtenerUltimoIdPedido();

            // Guardar las imágenes asociadas al pedido en la base de datos
            foreach (string rutaImagen in rutasImagenes)
            {
                gestionBaseDatos.InsertarImagenPedido(idPedido, rutaImagen);
            }

            // Cargar los pedidos actualizados
            CargarPedidos();

            // Mostrar un mensaje de confirmación
            MessageBox.Show("Pedido guardado con éxito.");

            // Limpiar los controles del formulario después de realizar el pedido
            //LimpiarControles();
        }


        private void dataGridViewPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (dataGridViewPedidos.CurrentCell != null) // Verifica si se ha seleccionado alguna celda
            {
                int filaSeleccionada = dataGridViewPedidos.CurrentCell.RowIndex;
                DataGridViewRow fila = dataGridViewPedidos.Rows[filaSeleccionada];

                //// Obtener los valores de las celdas de la fila seleccionada
                //int id = Convert.ToInt32(fila.Cells["idColumn"].Value);
                //if (id > 0)
                //{
                //    txtNombreCliente.Text = fila.Cells["clienteColumn"].Value.ToString();
                //    txtDescripcion.Text = fila.Cells["DescripcionColumn"].Value.ToString();
                //    cmbEstado.Text = fila.Cells["EstadoColumn"].Value.ToString();
                //    dateTimePicker1Pedido.Value = Convert.ToDateTime(fila.Cells["Fecha_pedidoColumn"].Value);
                //    dateTimePicker2Pedidos.Value = Convert.ToDateTime(fila.Cells["Fecha_entregaColumn"].Value);
                //    txtNotas.Text = fila.Cells["NotasColumn"].Value.ToString();
                //}
                ////MessageBox.Show("Gasto actualizado correctamente.");

                // Verificar si el índice de la celda está dentro de los límites de las filas de datos
                if (e.RowIndex >= 0 && e.RowIndex < dataGridViewPedidos.Rows.Count - 1)
                {
                    // Obtener el ID del pedido seleccionado
                    int idPedido = Convert.ToInt32(dataGridViewPedidos.Rows[e.RowIndex].Cells["idColumn"].Value);

                    // Llamar al método para cargar los detalles del pedido y las imágenes
                    CargarDetallesPedido(idPedido);
                }
            }
            else
            {
                MessageBox.Show("Selecciona una celda para actualizar el pedido.");
            }
        }

        private void CargarDetallesPedido(int id)
        {
            try
            {
                gestionBaseDatos.AbrirConexion();

                // Obtener los datos del pedido desde la base de datos
                string consultaPedido = "SELECT cliente, descripcion, estado, fecha_pedido, fecha_entrega, notas FROM Pedidos WHERE id = @id";
                MySqlCommand comandoPedido = new MySqlCommand(consultaPedido, gestionBaseDatos.conexion);
                comandoPedido.Parameters.AddWithValue("@id", id);
                MySqlDataReader readerPedido = comandoPedido.ExecuteReader();

                if (readerPedido.Read())
                {
                    // Mostrar los datos del pedido en los controles del formulario
                    txtNombreCliente.Text = readerPedido.GetString("cliente");
                    txtDescripcion.Text = readerPedido.GetString("descripcion");
                    cmbEstado.SelectedItem = readerPedido.GetString("estado");
                    dateTimePicker1Pedido.Value = readerPedido.GetDateTime("fecha_pedido");
                    dateTimePicker2Pedidos.Value = readerPedido.GetDateTime("fecha_entrega");
                    txtNotas.Text = readerPedido.GetString("notas");
                }

                readerPedido.Close();

                // Obtener las imágenes asociadas al pedido desde la base de datos
                string consultaImagenes = "SELECT ruta_imagen FROM ImagenesPedido WHERE id = @id";
                MySqlCommand comandoImagenes = new MySqlCommand(consultaImagenes, gestionBaseDatos.conexion);
                comandoImagenes.Parameters.AddWithValue("@id", id);
                MySqlDataReader readerImagenes = comandoImagenes.ExecuteReader();

                // Limpiar los PictureBox antes de cargar nuevas imágenes
                foreach (PictureBox pictureBox in pictureBoxes)
                {
                    pictureBox.Image = null;
                }

                int index = 0;
                while (readerImagenes.Read() && index < pictureBoxes.Count)
                {
                    // Mostrar las imágenes en los PictureBox correspondientes
                    string rutaImagen = readerImagenes.GetString("ruta_imagen");
                    pictureBoxes[index].Image = Image.FromFile(rutaImagen);
                    index++;
                }

                readerImagenes.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los detalles del pedido: " + ex.Message);
            }
            finally
            {
                gestionBaseDatos.CerrarConexion();
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Clear();
            txtDescripcion.Clear();
            txtNotas.Clear();
        }

        private void btnSeleccionarFotos_Click(object sender, EventArgs e)
        {
            // Crear un nuevo OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Establecer las propiedades del OpenFileDialog
            openFileDialog.Title = "Seleccionar imagen";
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*";
            openFileDialog.Multiselect = true; // Permitir la selección de varios archivos

            // Mostrar el cuadro de diálogo y comprobar si el usuario hizo clic en el botón Aceptar
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta de los archivos seleccionados y mostrarlas en los PictureBox y TextBox correspondientes
                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                {
                    // Obtener la ruta del archivo seleccionado
                    string rutaImagenSeleccionada = openFileDialog.FileNames[i];

                    // Agregar la ruta de la imagen a la lista
                    rutasImagenes.Add(rutaImagenSeleccionada);

                    // Asignar la imagen al PictureBox correspondiente
                    if (i < pictureBoxes.Count) // Asegúrate de que hay suficientes PictureBoxes en la lista
                    {
                        pictureBoxes[i].Image = Image.FromFile(rutaImagenSeleccionada);
                    }

                    // Asignar la ruta de la imagen al TextBox correspondiente
                    if (i < textBoxes.Count) // Asegúrate de que hay suficientes TextBoxes en la lista
                    {
                        textBoxes[i].Text = rutaImagenSeleccionada;
                    }
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Click += MostrarImagenCompleta;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Click += MostrarImagenCompleta;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Click += MostrarImagenCompleta;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Click += MostrarImagenCompleta;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Click += MostrarImagenCompleta;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedCells.Count > 0)
            {
                int filaSeleccionadaIndex = dataGridViewPedidos.SelectedCells[0].RowIndex;
                DataGridViewRow filaSeleccionada = dataGridViewPedidos.Rows[filaSeleccionadaIndex];

                int id = Convert.ToInt32(filaSeleccionada.Cells["IdColumn"].Value);
                string nuevoCliente = txtNombreCliente.Text;
                string nuevoEstado = cmbEstado.Text;
                DateTime nuevaFechaDePedido = dateTimePicker1Pedido.Value;
                DateTime nuevaFechaDeEntrega = dateTimePicker2Pedidos.Value;
                string nuevaDescripcion = txtDescripcion.Text;
                string nuevaNota = txtNotas.Text;


                gestionBaseDatos.ActualizarPedido(id, nuevoCliente, nuevaDescripcion, nuevoEstado, nuevaFechaDePedido, nuevaFechaDeEntrega, nuevaNota);
                CargarPedidos(); // Recargar los gastos después de la actualización
                MessageBox.Show("Gasto actualizado correctamente.");

            }
            else
            {
                MessageBox.Show("Selecciona una celda para actualizar el gasto.");
            }
        }
    }
}
