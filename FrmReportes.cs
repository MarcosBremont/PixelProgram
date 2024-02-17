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
using System.IO;

namespace Pixel_Program
{
    public partial class FrmReportes : Form
    {
        private GestionBaseDeDatos gestionBaseDatos;
        private Dictionary<string, decimal> diccionarioNombresYPreciosProductos;

        private bool mousePresionado;
        private Point posicionInicial;
        public FrmReportes()
        {
            InitializeComponent();
            gestionBaseDatos = new GestionBaseDeDatos();
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas en los DateTimePicker
            DateTime fechaInicio = dateTimePicker1Ingresos.Value.Date;
            DateTime fechaFin = dateTimePicker2Ingresos.Value.Date.AddDays(1).AddSeconds(-1); // Asegurarse de que la fecha final sea al final del día seleccionado

            try
            {
                // Abrir la conexión a la base de datos
                gestionBaseDatos.AbrirConexion();

                // Construir la consulta SQL para seleccionar los registros de ingresos dentro del rango de fechas especificado
                string consulta = "SELECT * FROM ingresos WHERE fecha BETWEEN @fechaInicio AND @fechaFin";
                MySqlCommand comando = new MySqlCommand(consulta, gestionBaseDatos.conexion);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", fechaFin);

                // Ejecutar la consulta y obtener los resultados
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tablaIngresos = new DataTable();
                adaptador.Fill(tablaIngresos);

                // Mostrar los resultados en el DataGridView
                dataGridViewIngresos.DataSource = tablaIngresos;

                // Calcular el total de los ingresos
                decimal totalIngresos = 0;
                foreach (DataRow fila in tablaIngresos.Rows)
                {
                    totalIngresos += Convert.ToDecimal(fila["monto"]);
                }

                // Mostrar el total de ingresos en el Label
                lblTotalIngresos.Text = "Total Ingresos RD $ " + totalIngresos.ToString("N2"); // Formato de moneda

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al filtrar los registros de ingresos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                gestionBaseDatos.CerrarConexion();
            }

        }     
        private void btnFiltrarGastos_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas en los DateTimePicker
            DateTime fechaInicio = dateTimePicker1Gastos.Value.Date;
            DateTime fechaFin = dateTimePicker2Gastos.Value.Date.AddDays(1).AddSeconds(-1); // Asegurarse de que la fecha final sea al final del día seleccionado

            try
            {
                // Abrir la conexión a la base de datos
                gestionBaseDatos.AbrirConexion();

                // Construir la consulta SQL para seleccionar los registros de ingresos dentro del rango de fechas especificado
                string consulta = "SELECT * FROM gastos WHERE fecha BETWEEN @fechaInicio AND @fechaFin";
                MySqlCommand comando = new MySqlCommand(consulta, gestionBaseDatos.conexion);
                comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@fechaFin", fechaFin);

                // Ejecutar la consulta y obtener los resultados
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tablaGastos = new DataTable();
                adaptador.Fill(tablaGastos);

                // Mostrar los resultados en el DataGridView
                dataGridViewGastos.DataSource = tablaGastos;

                // Calcular el total de los ingresos
                decimal totalGastos = 0;
                foreach (DataRow fila in tablaGastos.Rows)
                {
                    totalGastos += Convert.ToDecimal(fila["monto"]);
                }

                // Mostrar el total de ingresos en el Label
                lblTotalGastos.Text = "Total Gastos RD $ " + totalGastos.ToString("N2"); // Formato de moneda

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al filtrar los registros de gastos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                gestionBaseDatos.CerrarConexion();
            }

        }

       
    }
}

