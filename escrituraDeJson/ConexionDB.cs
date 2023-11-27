using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escrituraDeJson
{
    public class ConexionDB
    {
        private MySqlConnection connection;

        string connectionString = "Server=localhost;Port=3306;Database=tpjson;Uid=root;Pwd=mysql;";
        public ConexionDB()
        {

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public void CrearTablas()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string crearTabla1SQL = "CREATE TABLE escritor ("
                    + "id BIGINT AUTO_INCREMENT PRIMARY KEY,"
                    + "apellido VARCHAR(20),"
                    + "nombre VARCHAR(20),"
                    + "dni VARCHAR(50))";

                MySqlCommand cmd1 = new MySqlCommand(crearTabla1SQL, connection);
                cmd1.ExecuteNonQuery();

                string crearTabla2SQL = "CREATE TABLE libro ("
                    + "nombre VARCHAR(30),"
                    + "anio_publicacion INT,"
                    + "editorial VARCHAR(40),"
                    + "id_escritor BIGINT,"
                    + "FOREIGN KEY (id_escritor) REFERENCES escritor(id))";

                MySqlCommand cmd2 = new MySqlCommand(crearTabla2SQL, connection);
                cmd2.ExecuteNonQuery();

                Console.WriteLine("Tablas creadas exitosamente.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { connection.Close(); }
        }


        public void CargarDatosDePruebaEscritor(string apellido, string nombre, string dni)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                // Insertar datos de prueba en la tabla Escritor
                string insertEscritorSQL = "INSERT INTO escritor (apellido, nombre, dni) VALUES (@apellido, @nombre, @dni)";
                MySqlCommand cmdInsertEscritor = new MySqlCommand(insertEscritorSQL, connection);
                cmdInsertEscritor.Parameters.AddWithValue("@apellido", apellido);
                cmdInsertEscritor.Parameters.AddWithValue("@nombre", nombre);
                cmdInsertEscritor.Parameters.AddWithValue("@dni", dni);
                cmdInsertEscritor.ExecuteNonQuery();

                Console.WriteLine("Datos de prueba cargados exitosamente.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }finally { connection.Close(); }
        }

        public void CargarDatosDePruebaLibro(string nombre, int anioPublicacion, string editorial, long idEscritor)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                // Insertar datos de prueba en la tabla Libro relacionando con el escritor
                string insertLibroSQL = "INSERT INTO libro (nombre, anio_publicacion, editorial, id_escritor) VALUES (@nombre, @anio_publicacion, @editorial, @id_escritor)";
                MySqlCommand cmdInsertLibro = new MySqlCommand(insertLibroSQL, connection);
                cmdInsertLibro.Parameters.AddWithValue("@nombre", nombre);
                cmdInsertLibro.Parameters.AddWithValue("@anio_publicacion", anioPublicacion);
                cmdInsertLibro.Parameters.AddWithValue("@editorial", editorial);
                cmdInsertLibro.Parameters.AddWithValue("@id_escritor", idEscritor); // Obtener el ID del escritor insertado
                cmdInsertLibro.ExecuteNonQuery();

                Console.WriteLine("Datos de prueba cargados exitosamente.");
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally { connection.Close(); }
        }
    }
}
