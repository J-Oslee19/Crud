using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miForumulario.Clases
{
    public class Crud
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=UMG;Database=ControlTareas;=True;TrustServerCertificate=True;";

        // Mostrar alumnos
        public void MostrarAlumno()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM tb_alumnos where seccion = 'C' order by estudiante";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        MessageBox.Show($"Carnet:{reader["carnet"]} Nombre: {reader["estudiante"]}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }
                connection.Close();
            }
        }

        // Agregar un nuevo alumno
        public int AgregarAlumno(string carnet, string nombre, string seccion, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO tb_alumnos (carnet, estudiante, seccion, email) VALUES (@carnet, @nombre, @seccion, @email)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@seccion", seccion);
                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Alumno agregado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el alumno.");
                    }
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                return -1;
            }
        }

        // Actualizar un alumno
        public void ActualizarAlumno(string carnet, string nombre, string seccion, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE tb_alumnos SET estudiante = @nombre, seccion = @seccion, email = @email WHERE carnet = @carnet";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@seccion", seccion);
                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Alumno actualizado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el alumno.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el alumno: " + ex.Message);
            }
        }

        // Eliminar un alumno
        public void EliminarAlumno(string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM tb_alumnos WHERE carnet = @carnet";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Alumno eliminado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el alumno.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el alumno: " + ex.Message);
            }
        }

        // Agregar tarea
        public int AgregarTarea(string titulo, string descripcion, string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Tareas (titulo, descripcion, carnet) VALUES (@titulo, @descripcion, @carnet)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@titulo", titulo);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@carnet", carnet);

                    connection.Open();
                    int resultado = command.ExecuteNonQuery();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar tarea: " + ex.Message);
                return -1;
            }
        }

        // Mostrar todas las tareas
        public List<object[]> ObtenerTodasLasTareas()
        {
            List<object[]> tareas = new List<object[]>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Tarea";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tareas.Add(new object[]
                        {
                            reader["IdTarea"],
                            reader["Carnet"],
                            reader["NombreTarea"],
                            reader["Descripcion"],
                            reader["FechaEntrega"],
                            reader["Seccion"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tareas: " + ex.Message);
            }

            return tareas;
        }

        // Actualizar tarea
        public int ActualizarTarea(int idTarea, string titulo, string descripcion, string carnet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Tareas SET titulo = @titulo, descripcion = @descripcion, carnet = @carnet WHERE IdTarea = @idTarea";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idTarea", idTarea);
                    command.Parameters.AddWithValue("@titulo", titulo);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@carnet", carnet);

                    connection.Open();
                    int resultado = command.ExecuteNonQuery();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar tarea: " + ex.Message);
                return -1;
            }
        }

        // Eliminar tarea
        public int EliminarTarea(int idTarea)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Tareas WHERE IdTarea = @idTarea";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idTarea", idTarea);

                    connection.Open();
                    int resultado = command.ExecuteNonQuery();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar tarea: " + ex.Message);
                return -1;
            }
        }
    }
}
