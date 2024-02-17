using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;


namespace Pixel_Program
{
    public partial class FrmGastos : Form
    {
        private GestionBaseDeDatos gestionBaseDatos;
        private bool mousePresionado;
        private Point posicionInicial;
        public FrmGastos()
        {
            InitializeComponent();
            gestionBaseDatos = new GestionBaseDeDatos();


            // Agrega las columnas al DataGridView
            dataGridViewGastos.Columns.Add("IdColumn", "id");
            dataGridViewGastos.Columns.Add("DescripcionColumn", "Descripción");
            dataGridViewGastos.Columns.Add("MontoColumn", "Monto");
            dataGridViewGastos.Columns.Add("FechaColumn", "Fecha");

            // Llama al método para cargar los gastos al cargar el formulario
            CargarGastos();

        }


        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            // Verifica si los campos obligatorios están llenos
            if (!CamposValidos())
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, llene todos los campos.");
                return;
            }

            // Si todos los campos están llenos, procede con la inserción del gasto
            string descripcion = txtDescripcion.Text;
            decimal monto;

            // Verifica si el valor en el campo de monto es válido
            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            // Asegúrate de manejar excepciones si el usuario ingresa un valor no válido
            DateTime fecha = DateTime.Now; // Puedes obtener la fecha actual o usar un control de fecha en tu formulario

            gestionBaseDatos.InsertarGasto(descripcion, monto, fecha);
            // Llama al método para cargar los gastos al cargar el formulario
            CargarGastos();
            MessageBox.Show("Gasto agregado correctamente.");

            // Limpia los campos después de agregar el gasto
            txtDescripcion.Clear();
            txtMonto.Clear();
        }

        // Método para verificar si todos los campos obligatorios están llenos
        private bool CamposValidos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                return false; // Retorna falso si alguno de los campos obligatorios está vacío
            }

            // Verifica si el campo txtMonto contiene solo números
            decimal monto;
            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("El campo monto solo debe contener números.");
                return false;
            }

            return true; // Retorna verdadero si todos los campos obligatorios están llenos y el campo monto contiene solo números
        }



        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dataGridViewGastos.Rows)
            {
                // Verifica si la fila no es la fila de encabezado
                if (!fila.IsNewRow)
                {
                    total += Convert.ToDecimal(fila.Cells["MontoColumn"].Value);
                }
            }

            lblTotal.Text = "Total: RD $" + total.ToString("N"); // Formatear el total con separadores de miles
        }

        private void CargarGastos()
        {
            try
            {
                gestionBaseDatos.AbrirConexion();

                string consulta = "SELECT id, descripcion, monto, fecha FROM gastos";
                MySqlCommand comando = new MySqlCommand(consulta, gestionBaseDatos.conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                dataGridViewGastos.Rows.Clear();

                while (reader.Read())
                {
                    int idGasto = reader.GetInt32(0); // Suponiendo que el ID está en la posición 0
                    string descripcion = reader.GetString(1);
                    decimal monto = reader.GetDecimal(2);
                    DateTime fecha = reader.GetDateTime(3);

                    dataGridViewGastos.Rows.Add(idGasto, descripcion, monto, fecha);
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar los gastos: " + ex.Message);
            }
            finally
            {
                gestionBaseDatos.CerrarConexion();
                // Llama al método para calcular el total después de cargar los datos
                CalcularTotal();
            }
        }

        private void btnActualizarGastos_Click(object sender, EventArgs e)
        {
            if (dataGridViewGastos.SelectedCells.Count > 0)
            {
                int filaSeleccionadaIndex = dataGridViewGastos.SelectedCells[0].RowIndex;
                DataGridViewRow filaSeleccionada = dataGridViewGastos.Rows[filaSeleccionadaIndex];

                int idGasto = Convert.ToInt32(filaSeleccionada.Cells["IdColumn"].Value);
                string nuevaDescripcion = txtDescripcion.Text;
                decimal nuevoMonto;
                DateTime nuevaFecha;

                if (decimal.TryParse(txtMonto.Text, out nuevoMonto) && DateTime.TryParse(txtFecha.Text, out nuevaFecha))
                {
                    gestionBaseDatos.ActualizarGasto(idGasto, nuevaDescripcion, nuevoMonto, nuevaFecha);
                    CargarGastos(); // Recargar los gastos después de la actualización
                    MessageBox.Show("Gasto actualizado correctamente.");
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


        private void dataGridViewGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewGastos.CurrentCell != null) // Verifica si se ha seleccionado alguna celda
            {
                int filaSeleccionada = dataGridViewGastos.CurrentCell.RowIndex;
                DataGridViewRow fila = dataGridViewGastos.Rows[filaSeleccionada];

                // Obtener los valores de las celdas de la fila seleccionada
                int idGasto = Convert.ToInt32(fila.Cells["idColumn"].Value);
                txtDescripcion.Text = fila.Cells["DescripcionColumn"].Value.ToString();
                txtMonto.Text = fila.Cells["montoColumn"].Value.ToString();
                txtFecha.Text = fila.Cells["fechaColumn"].Value.ToString();
                //gestionBaseDatos.ActualizarGasto(idGasto, nuevaDescripcion, nuevoMonto, nuevaFecha);

                //MessageBox.Show("Gasto actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("Selecciona una celda para actualizar el gasto.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewGastos.SelectedCells.Count > 0)
            {
                // Obtener el ID del gasto seleccionado
                int idGasto = Convert.ToInt32(dataGridViewGastos.SelectedCells[0].Value);

                // Confirmar con el usuario si realmente desea eliminar el gasto
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar este gasto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al método para eliminar el gasto de la base de datos
                    gestionBaseDatos.EliminarGasto(idGasto);

                    // Volver a cargar los gastos en el DataGridView después de eliminar
                    CargarGastos();


                    MessageBox.Show("El gasto se ha eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un gasto para eliminar.");
            }
        }

        private void FrmGastos_MouseDown(object sender, MouseEventArgs e)
        {
            // Verificar si se ha presionado el botón izquierdo del mouse
            if (e.Button == MouseButtons.Left)
            {
                mousePresionado = true;
                // Guardar la posición inicial del formulario
                posicionInicial = new Point(e.X, e.Y);
            }
        }

        private void FrmGastos_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmGastos_MouseUp(object sender, MouseEventArgs e)
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

        private void FrmGastos_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
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

