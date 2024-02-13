using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Program
{
    public class GestionBaseDeDatos
    {
        public MySqlConnection conexion;
        private string cadenaConexion = "Server=localhost;Database=pixeldatabase;Uid=root;Pwd=1234;";

        public GestionBaseDeDatos()
        {
            conexion = new MySqlConnection(cadenaConexion);
        }

        public void AbrirConexion()
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar abrir la conexión: " + ex.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar cerrar la conexión: " + ex.Message);
            }
        }

        public void InsertarIngreso(string descripcion, decimal monto, DateTime fecha)
        {
            try
            {
                AbrirConexion();
                string consulta = "INSERT INTO Ingresos (descripcion, monto, fecha) VALUES (@descripcion, @monto, @fecha)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@monto", monto);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar insertar el ingreso: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void ActualizarIngreso(int idIngreso, string nuevaDescripcion, decimal nuevoMonto, DateTime nuevaFecha)
        {
            try
            {
                AbrirConexion();
                string consulta = "UPDATE Ingresos SET descripcion = @descripcion, monto = @monto, fecha = @fecha WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                comando.Parameters.AddWithValue("@monto", nuevoMonto);
                comando.Parameters.AddWithValue("@fecha", nuevaFecha);
                comando.Parameters.AddWithValue("@id", idIngreso);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar actualizar el ingreso: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void EliminarIngreso(int idIngreso)
        {
            try
            {
                AbrirConexion();
                string consulta = "DELETE FROM Ingresos WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", idIngreso);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar eliminar el ingreso: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }



        public void ActualizarGasto(int id, string descripcion, decimal monto, DateTime fecha)
        {
            try
            {
                AbrirConexion();
                string consulta = "UPDATE gastos SET descripcion = @descripcion, monto = @monto, fecha = @fecha WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@monto", monto);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar actualizar el gasto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }


        public void InsertarGasto(string descripcion, decimal monto, DateTime fecha)
        {
            try
            {
                AbrirConexion();
                string consulta = "INSERT INTO gastos (descripcion, monto, fecha) VALUES (@descripcion, @monto, @fecha)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@monto", monto);
                comando.Parameters.AddWithValue("@fecha", fecha); // Cambiar esto para usar la fecha proporcionada
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar insertar el gasto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }


        public void EliminarGasto(int idGasto)
        {
            try
            {
                AbrirConexion();
                string consulta = "DELETE FROM gastos WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", idGasto);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar eliminar el gasto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

    }
}

