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
    public partial class FrmIngresos : Form
    {
        private GestionBaseDeDatos gestionBaseDatos;

        private bool mousePresionado;
        private Point posicionInicial;
        public FrmIngresos()
        {
            InitializeComponent();
            gestionBaseDatos = new GestionBaseDeDatos(); // Inicializar la instancia de GestionBaseDatos


            // Agrega las columnas al DataGridView
            dataGridViewIngresos.Columns.Add("IdColumn", "id");
            dataGridViewIngresos.Columns.Add("DescripcionColumn", "Descripción");
            dataGridViewIngresos.Columns.Add("MontoColumn", "Monto");
            dataGridViewIngresos.Columns.Add("FechaColumn", "Fecha");
            dataGridViewIngresos.Columns.Add("ClienteColumn", "Cliente");


            // Llama al método para cargar los gastos al cargar el formulario
            CargarIngresos();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Verifica que todos los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtMonto.Text) ||
                string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Verifica que el monto sea un valor numérico
            if (!decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("El monto ingresado no es válido.");
                return;
            }

            // Obtener la fecha actual
            DateTime fecha = DateTime.Now;

            // Insertar el ingreso en la base de datos
            gestionBaseDatos.InsertarIngreso(txtDescripcion.Text, monto, fecha, txtNombreCliente.Text);

            // Recargar los ingresos en el DataGridView después de insertar uno nuevo
            CargarIngresos();

            MessageBox.Show("Ingreso registrado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewIngresos.SelectedRows.Count > 0)
            {
                // Obtener el ID del ingreso seleccionado
                int idIngreso = Convert.ToInt32(dataGridViewIngresos.SelectedRows[0].Cells["IdColumn"].Value);

                // Confirmar con el usuario si realmente desea eliminar el ingreso
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres eliminar este ingreso?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Eliminar el ingreso de la base de datos
                    gestionBaseDatos.EliminarIngreso(idIngreso);

                    // Recargar los ingresos en el DataGridView después de eliminar uno
                    CargarIngresos();

                    MessageBox.Show("El ingreso se ha eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un ingreso para eliminar.");
            }
        }

        private void CargarIngresos()
        {
            try
            {
                gestionBaseDatos.AbrirConexion();

                string consulta = "SELECT id, descripcion, monto, fecha, cliente FROM ingresos";
                MySqlCommand comando = new MySqlCommand(consulta, gestionBaseDatos.conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                dataGridViewIngresos.Rows.Clear();

                while (reader.Read())
                {
                    int idIngreso = reader.GetInt32(0); // Suponiendo que el ID está en la posición 0
                    string descripcion = reader.GetString(1);
                    decimal monto = reader.GetDecimal(2);
                    DateTime fecha = reader.GetDateTime(3);
                    string cliente = reader.GetString(4);


                    dataGridViewIngresos.Rows.Add(idIngreso, descripcion, monto, fecha, cliente);
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
                // Llama al método para calcular el total después de cargar los datos
                CalcularTotalIngresos();
            }
        }

        private void CalcularTotalIngresos()
        {
            decimal totalIngresos = 0;

            foreach (DataGridViewRow fila in dataGridViewIngresos.Rows)
            {
                // Verifica si la fila no es la fila de encabezado
                if (!fila.IsNewRow)
                {
                    totalIngresos += Convert.ToDecimal(fila.Cells["MontoColumn"].Value);
                }
            }

            lblTotalIngresos.Text = "Total: RD $" + totalIngresos.ToString("N2"); // Mostrar el total en el Label con formato de moneda
        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewIngresos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridViewIngresos.SelectedRows[0];

                int idIngreso = Convert.ToInt32(filaSeleccionada.Cells["IdColumn"].Value);
                string nuevaDescripcion = txtDescripcion.Text;
                decimal nuevoMonto = Convert.ToDecimal(txtMonto.Text);
                DateTime nuevaFecha = DateTime.Now; // Puedes obtener la fecha actual o usar un control de fecha en tu formulario
                string nuevoCliente = txtNombreCliente.Text;


                // Actualizar el ingreso en la base de datos
                gestionBaseDatos.ActualizarIngreso(idIngreso, nuevaDescripcion, nuevoMonto, nuevaFecha, nuevoCliente);

                // Recargar los ingresos en el DataGridView después de actualizar uno
                CargarIngresos();

                MessageBox.Show("Ingreso actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("Selecciona un ingreso para actualizar.");
            }
        }

        private void FrmIngresos_MouseDown(object sender, MouseEventArgs e)
        {
            // Verificar si se ha presionado el botón izquierdo del mouse
            if (e.Button == MouseButtons.Left)
            {
                mousePresionado = true;
                // Guardar la posición inicial del formulario
                posicionInicial = new Point(e.X, e.Y);
            }
        }

        private void FrmIngresos_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmIngresos_MouseUp(object sender, MouseEventArgs e)
        {
            // Se ha soltado el botón del mouse, por lo que el formulario ya no se moverá
            mousePresionado = false;
        }

        private void dataGridViewIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Verificar si el índice de la columna es válido y si la fila seleccionada no es la fila de encabezado
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el ID del ingreso seleccionado
                int idIngreso = Convert.ToInt32(dataGridViewIngresos.Rows[e.RowIndex].Cells["IdColumn"].Value);

                // Obtener los valores de la fila seleccionada
                string descripcion = dataGridViewIngresos.Rows[e.RowIndex].Cells["DescripcionColumn"].Value.ToString();
                decimal monto = Convert.ToDecimal(dataGridViewIngresos.Rows[e.RowIndex].Cells["MontoColumn"].Value);
                DateTime fecha = Convert.ToDateTime(dataGridViewIngresos.Rows[e.RowIndex].Cells["FechaColumn"].Value);

                // Mostrar los valores en los controles de entrada (TextBox, DateTimePicker, etc.)
                txtDescripcion.Text = descripcion;
                txtMonto.Text = monto.ToString();
                txtFecha.Text = fecha.ToString();
            }


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
