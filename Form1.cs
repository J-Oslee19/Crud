using miForumulario.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace miForumulario
{
    
    public partial class btmInsertarTarea : Form
    {

        Crud Micrud = new Crud();


        private void CargarTareas()
        {
            dgvTareas.DataSource = Micrud.ObtenerTodasLasTareas();
        }
        public btmInsertarTarea()
        {
            InitializeComponent();
        
            InitializeComponent();
            CargarTareas();
            
      
            InitializeComponent();
            dgvTareas.CellClick += dgvTareas_CellClick; 
            CargarTareas(); 
        

        }

        private void dgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvTareas.Rows[e.RowIndex];

                // Asigna los valores de las celdas de la fila seleccionada a los TextBox
                textBoxID.Text = fila.Cells["id"].Value.ToString();
                textBoxTitulo.Text = fila.Cells["titulo"].Value.ToString();
                textBoxDescripcion.Text = fila.Cells["descripcion"].Value.ToString();
                textBoxCarnet.Text = fila.Cells["carnet"].Value.ToString();
            }
        }


        private void buttonSaludar_Click(object sender, EventArgs e)
        {
            String saludo = $"Hola {textBoxNombre.Text} te saludo desde el formulario";
            MessageBox.Show(saludo,"Un Saludo ✌️✌️");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text;
            string nombre = textBoxNombre.Text;
            string seccion = textBoxSeccion.Text;
            string email =  textBoxCorreo.Text;
            int resultado = Micrud.AgregarAlumno(carnet, nombre, seccion, email);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSeccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTitulo.Text;
            string descripcion = textBoxDescripcion.Text;
            string carnet = textBoxCarnet.Text;

            int resultado = Micrud.AgregarTarea(titulo, descripcion, carnet);

            if (resultado > 0)
            {
                MessageBox.Show("✅ Tarea guardada exitosamente.");
                CargarTareas(); 
            }
            else
            {
                MessageBox.Show("❌ No se pudo guardar la tarea.");
            }
        }
        // Eliminar tarea
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxID.Text, out int idTarea))
            {
                int resultado = Micrud.EliminarTarea(idTarea);

                if (resultado > 0)
                {
                    MessageBox.Show("✅ Tarea eliminada exitosamente.");
                    CargarTareas();
                }
                else
                {
                    MessageBox.Show("❌ No se pudo eliminar la tarea.");
                }
            }
            else
            {
                MessageBox.Show("⚠️ Ingresa un ID válido para eliminar.");
            }
        }

        // Actualizar tarea
        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxID.Text, out int idTarea))
            {
                string titulo = textBoxTitulo.Text;
                string descripcion = textBoxDescripcion.Text;
                string carnet = textBoxCarnet.Text;

                int resultado = Micrud.ActualizarTarea(idTarea, titulo, descripcion, carnet);

                if (resultado > 0)
                {
                    MessageBox.Show("✅ Tarea actualizada exitosamente.");
                    CargarTareas();
                }
                else
                {
                    MessageBox.Show("❌ No se pudo actualizar la tarea.");
                }
            }
            else
            {
                MessageBox.Show("⚠️ Ingresa un ID válido para actualizar.");
            }
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

