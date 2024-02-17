using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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

        public int ObtenerUltimoIdPedido()
        {
            int ultimoId = 0;
            try
            {
                AbrirConexion();

                // Consulta para obtener el último ID de pedido insertado
                string consulta = "SELECT MAX(id) FROM Pedidos";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                object result = comando.ExecuteScalar();

                // Verificar si se obtuvo un resultado válido
                if (result != null && result != DBNull.Value)
                {
                    ultimoId = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener el último ID de pedido: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return ultimoId;
        }



        public void InsertarImagenPedido(int id, string rutaImagen)
        {
            try
            {
                AbrirConexion();

                // Insertar la imagen del pedido en la tabla ImagenesPedido
                string consultaImagen = "INSERT INTO ImagenesPedido (id, ruta_imagen) VALUES (@id, @ruta_imagen)";
                MySqlCommand comandoImagen = new MySqlCommand(consultaImagen, conexion);
                comandoImagen.Parameters.AddWithValue("@id", id);
                comandoImagen.Parameters.AddWithValue("@ruta_imagen", rutaImagen);
                comandoImagen.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al insertar la imagen del pedido: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
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

        public void InsertarIngreso(string descripcion, decimal monto, DateTime fecha, string cliente)
        {
            try
            {
                AbrirConexion();
                string consulta = "INSERT INTO Ingresos (descripcion, monto, fecha, cliente) VALUES (@descripcion, @monto, @fecha, @cliente)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@monto", monto);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@cliente", cliente);

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

        public void ActualizarIngreso(int idIngreso, string nuevaDescripcion, decimal nuevoMonto, DateTime nuevaFecha, string nuevoCliente)
        {
            try
            {
                AbrirConexion();
                string consulta = "UPDATE Ingresos SET descripcion = @descripcion, monto = @monto, fecha = @fecha, cliente = @cliente WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                comando.Parameters.AddWithValue("@monto", nuevoMonto);
                comando.Parameters.AddWithValue("@fecha", nuevaFecha);
                comando.Parameters.AddWithValue("@cliente", nuevoCliente);
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

        public void ActualizarPedido(int id, string nuevoCliente, string nuevaDescripcion, string nuevoEstado, DateTime nuevaFechaDePedido, DateTime nuevaFechaDeEntrega, string nuevaNota)
        {
            try
            {
                AbrirConexion();
                string consulta = "UPDATE pedidos SET cliente = @cliente, descripcion = @descripcion, estado = @estado, fecha_pedido = @fecha_pedido, fecha_entrega = @fecha_entrega, notas = @notas WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@cliente", nuevoCliente);
                comando.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                comando.Parameters.AddWithValue("@estado", nuevoEstado);
                comando.Parameters.AddWithValue("@fecha_pedido", nuevaFechaDePedido);
                comando.Parameters.AddWithValue("@fecha_entrega", nuevaFechaDeEntrega);
                comando.Parameters.AddWithValue("@notas", nuevaNota);
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

        public void ActualizarProducto(int id, string nombre, string descripcion, int cantidad, decimal precio, string linkopagina, decimal preciocompra)
        {
            try
            {
                AbrirConexion();
                string consulta = "UPDATE productos SET nombre = @nombre, descripcion = @descripcion, cantidad = @cantidad, precio = @precio, linkopagina = @linkopagina, preciocompra = @preciocompra WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@precio", precio);
                comando.Parameters.AddWithValue("@linkopagina", linkopagina);
                comando.Parameters.AddWithValue("@preciocompra", preciocompra);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar actualizar el producto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Dictionary<string, decimal> ObtenerNombresYPreciosProductos()
        {
            Dictionary<string, decimal> nombresYPreciosProductos = new Dictionary<string, decimal>();

            try
            {
                AbrirConexion();

                string consulta = "SELECT nombre, precio FROM Productos";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString("nombre");
                        decimal precio = reader.GetDecimal("precio");
                        nombresYPreciosProductos.Add(nombre, precio);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al obtener los nombres y precios de productos: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return nombresYPreciosProductos;
        }


        public void RegistrarVenta(string nombreProducto, int cantidadVendida, decimal precioUnitario, string cliente)
        {
            try
            {
                AbrirConexion();

                // Actualizar el inventario: restar la cantidad vendida del producto
                string consultaActualizarInventario = "UPDATE Productos SET cantidad = cantidad - @cantidadVendida WHERE nombre = @nombreProducto";
                MySqlCommand comandoActualizarInventario = new MySqlCommand(consultaActualizarInventario, conexion);
                comandoActualizarInventario.Parameters.AddWithValue("@cantidadVendida", cantidadVendida);
                comandoActualizarInventario.Parameters.AddWithValue("@nombreProducto", nombreProducto);
                comandoActualizarInventario.ExecuteNonQuery();

                // Agregar la venta a la tabla de ingresos
                string consultaAgregarIngreso = "INSERT INTO Ingresos (descripcion, monto, fecha, cliente) VALUES (@descripcion, @monto, @fecha, @cliente)";
                MySqlCommand comandoAgregarIngreso = new MySqlCommand(consultaAgregarIngreso, conexion);
                comandoAgregarIngreso.Parameters.AddWithValue("@descripcion", $"Venta de {cantidadVendida} {nombreProducto}");
                comandoAgregarIngreso.Parameters.AddWithValue("@monto", cantidadVendida * precioUnitario);
                comandoAgregarIngreso.Parameters.AddWithValue("@fecha", DateTime.Now);
                comandoAgregarIngreso.Parameters.AddWithValue("@cliente", cliente);
                comandoAgregarIngreso.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar registrar la venta: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }


        public void InsertarPedidos (string cliente, string descripcion, string estado, DateTime fecha_pedido, DateTime fecha_entrega, string notas)
        {
            try
            {
                AbrirConexion();

                // Agregar la venta a la tabla de ingresos
                string InsertarPedidos = "INSERT INTO pedidos (cliente, descripcion, estado, fecha_pedido, fecha_entrega, notas) VALUES (@cliente, @descripcion, @estado, @fecha_pedido, @fecha_entrega, @notas)";
                MySqlCommand comandoAgregarIngreso = new MySqlCommand(InsertarPedidos, conexion);
                comandoAgregarIngreso.Parameters.AddWithValue("@cliente", cliente);
                comandoAgregarIngreso.Parameters.AddWithValue("@descripcion", descripcion);
                comandoAgregarIngreso.Parameters.AddWithValue("@estado", estado);
                comandoAgregarIngreso.Parameters.AddWithValue("@fecha_pedido", fecha_pedido);
                comandoAgregarIngreso.Parameters.AddWithValue("@fecha_entrega", fecha_entrega);
                comandoAgregarIngreso.Parameters.AddWithValue("@notas", notas);
                comandoAgregarIngreso.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar registrar el pedido: " + ex.Message);
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

        public void EliminarProducto(int id)
        {
            try
            {
                AbrirConexion();
                string consulta = "DELETE FROM productos WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar eliminar el producto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void InsertarProducto(string nombre, string descripcion, int cantidad, decimal precio, string linkopagina, decimal preciocompra, string rutaImagen)
        {
            try
            {
                byte[] bytesImagen = File.ReadAllBytes(rutaImagen);

                AbrirConexion();

                string consulta = "INSERT INTO Productos (nombre, descripcion, cantidad, precio, linkopagina, preciocompra, imagen) VALUES (@nombre, @descripcion, @cantidad, @precio, @linkopagina, @preciocompra, @imagen)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@cantidad", cantidad);
                comando.Parameters.AddWithValue("@precio", precio);
                comando.Parameters.AddWithValue("@linkopagina", linkopagina);
                comando.Parameters.AddWithValue("@preciocompra", preciocompra);
                comando.Parameters.AddWithValue("@imagen", bytesImagen);


                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al intentar insertar el producto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }



    }
}

