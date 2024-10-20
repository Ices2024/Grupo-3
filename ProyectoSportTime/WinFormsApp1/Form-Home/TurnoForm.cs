using API.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Form_Home
{
    public partial class TurnoForm : Form
    {
        private string? deporteSeleccionado;

        public TurnoForm()
        {
            InitializeComponent();
            CargarCancha(); // Cargar las canchas al inicio
            CargarProductos(); // Cargar productos al inicio
        }

        public void SetDeporteSeleccionado(int deporteId)
        {
            Deporte_ID = deporteId; // Guarda el ID del deporte
                                    // Opcionalmente puedes mostrar información relacionada al deporte aquí
        }

        private void CargarCancha()
        {
            using (var context = new ProyectoDbContext())
            {
                var canchas = context.Canchas.Where(c => c.Codigo_Deporte == Deporte_ID).ToList();
                comboBoxCancha.DataSource = canchas;
                comboBoxCancha.DisplayMember = "Cancha_ID"; // Asegúrate de que muestre un campo representativo
                comboBoxCancha.ValueMember = "Cancha_ID"; // ID de la cancha
            }
        }

        private void ActualizarDataGridView()
        {
            using (var context = new ProyectoDbContext())
            {
                // Obtiene la lista de turnos con sus consumiciones y canchas
                var turnos = context.Turnos
                    .Include(t => t.Consumicion) // Asegúrate de que la relación esté cargada
                    .Include(t => t.Canchas) // Incluye la relación con Canchas
                    .ToList();

                // Limpia el DataGridView
                dataGridViewTurnos.DataSource = null;
                dataGridViewTurnos.Rows.Clear();

                // Establece el DataSource del DataGridView
                dataGridViewTurnos.DataSource = turnos.Select(t => new
                {
                    Turno_ID = t.Turno_ID,
                    Cancha_ID = t.Cancha_ID,
                    HoraInicio = t.HoraInicio,
                    HoraFin = t.HoraFin,
                    Consumicion = t.Consumicion?.Producto?.Tipo, // Muestra el nombre del producto
                    Cantidad = t.Consumicion?.Cantidad // Muestra la cantidad
                }).ToList();

                // Configura las columnas si es necesario
                dataGridViewTurnos.Columns["Turno_ID"].Visible = false; // Ocultar el ID si no es necesario mostrarlo
            }
        }


        private void CargarProductos()
        {
            using (var context = new ProyectoDbContext())
            {
                var productos = context.Productos.ToList();
                comboBoxConsumicion.DataSource = productos;
                comboBoxConsumicion.DisplayMember = "Tipo"; // Nombre del producto
                comboBoxConsumicion.ValueMember = "Producto_ID"; // ID del producto
            }
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            // Asegúrate de que la selección sea válida
            if (comboBoxCancha.SelectedValue is int canchaId &&
                comboBoxConsumicion.SelectedValue is int productoId)
            {
                // Obtén la cantidad del NumericUpDown
                int cantidad = (int)numericUpDownCantidad.Value;

                using (var context = new ProyectoDbContext())
                {
                    var nuevaConsumicion = new Consumiciones
                    {
                        Cantidad = cantidad,
                        Cod_Producto = productoId
                    };

                    context.Consumiciones.Add(nuevaConsumicion);
                    context.SaveChanges();

                    var nuevoTurno = new Turnos
                    {
                        Cancha_ID = canchaId,
                        HoraInicio = dateTimePicker1.Value,
                        HoraFin = dateTimePicker2.Value,
                        Consumicion_ID = nuevaConsumicion.Consumicion_ID // Guardar ID de consumición
                    };

                    context.Turnos.Add(nuevoTurno);
                    context.SaveChanges();

                    MessageBox.Show("Turno guardado correctamente.");
                    ActualizarDataGridView(); // Actualiza el DataGridView si es necesario
                }
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos correctamente.");
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTurnos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewTurnos.SelectedRows[0];
                int turnoId = (int)filaSeleccionada.Cells["Turno_ID"].Value;

                using (var context = new ProyectoDbContext())
                {
                    var turno = context.Turnos.Find(turnoId);
                    if (turno != null)
                    {
                        turno.Cancha_ID = (int)comboBoxCancha.SelectedValue;
                        turno.HoraInicio = dateTimePicker1.Value;
                        turno.HoraFin = dateTimePicker2.Value;

                        // Actualiza la consumición
                        var consumicion = context.Consumiciones.Find(turno.Consumicion_ID);
                        if (consumicion != null)
                        {
                            consumicion.Cantidad = (int)numericUpDownCantidad.Value;
                            consumicion.Cod_Producto = (int)comboBoxConsumicion.SelectedValue;
                        }

                        context.SaveChanges();
                        MessageBox.Show("Turno modificado correctamente.");
                        ActualizarDataGridView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un turno para modificar.");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTurnos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewTurnos.SelectedRows[0];
                int turnoId = (int)filaSeleccionada.Cells["Turno_ID"].Value;

                using (var context = new ProyectoDbContext())
                {
                    var turno = context.Turnos.Find(turnoId);
                    if (turno != null)
                    {
                        // También elimina la consumición asociada
                        var consumicion = context.Consumiciones.Find(turno.Consumicion_ID);
                        if (consumicion != null)
                        {
                            context.Consumiciones.Remove(consumicion);
                        }

                        context.Turnos.Remove(turno);
                        context.SaveChanges();
                        MessageBox.Show("Turno eliminado correctamente.");
                        ActualizarDataGridView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un turno para eliminar.");
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            // Limpia los campos
            comboBoxCancha.SelectedIndex = -1;
            comboBoxConsumicion.SelectedIndex = -1;
            numericUpDownCantidad.Value = 1; // o el valor que consideres por defecto
            dateTimePicker1.Value = DateTime.Now; // o el valor por defecto que quieras
            dateTimePicker2.Value = DateTime.Now.AddHours(1); // por ejemplo, agregar una hora por defecto
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
            var homeForm = new Form1(); // Reemplaza HomeForm con el nombre real de tu formulario de inicio
            homeForm.Show(); // Muestra el formulario de inicio
        }
    }
}
