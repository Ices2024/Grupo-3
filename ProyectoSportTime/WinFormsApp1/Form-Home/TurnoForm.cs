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
using Negocio.Implementations;

namespace WinForm.Form_Home
{
    public partial class TurnoForm : Form
    {
        public TurnoForm()
        {
            InitializeComponent();
        }

        private void TurnoForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (var context = new ProyectoDbContext())
                {
                    // Cargar deportes
                    var deportes = context.Deportes.ToList();
                    comboBoxDeporte.DataSource = deportes;
                    comboBoxDeporte.DisplayMember = "Tipo"; // Cambiar según la propiedad que quieras mostrar
                    comboBoxDeporte.ValueMember = "Deporte_ID";

                    // Cargar canchas
                    var canchas = context.Canchas.ToList();
                    comboBoxCancha.DataSource = canchas;
                    comboBoxCancha.DisplayMember = "Codigo_Deporte"; // O una propiedad relevante para mostrar el nombre
                    comboBoxCancha.ValueMember = "Cancha_ID";

                    // Cargar productos
                    var productos = context.Productos.ToList();
                    comboBoxConsumicion.DataSource = productos;
                    comboBoxConsumicion.DisplayMember = "Tipo"; // Cambiar según la propiedad que quieras mostrar
                    comboBoxConsumicion.ValueMember = "Producto_ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (comboBoxCancha.SelectedValue is int canchaId &&
                comboBoxConsumicion.SelectedValue is int productoId)
            {
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
                    ActualizarDataGridView();
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
            var homeForm = new Form1(); // Reemplaza Form1 con el nombre real de tu formulario de inicio
            homeForm.Show(); // Muestra el formulario de inicio
        }

        private void ActualizarDataGridView()
        {
            using (var context = new ProyectoDbContext())
            {
                var turnos = context.Turnos
                    .Include(t => t.Canchas)
                    .Include(t => t.Consumicion) // Esta línea se debe ajustar para mostrar productos
                    .ToList();

                dataGridViewTurnos.DataSource = turnos.Select(t => new
                {
                    t.Turno_ID,
                    Cancha = t.Canchas.Codigo_Deporte, // Muestra el nombre o código de la cancha
                    Producto = context.Productos.FirstOrDefault(p => p.Producto_ID == t.Consumicion_ID)?.Tipo, // Muestra el tipo de producto
                    t.HoraInicio,
                    t.HoraFin
                }).ToList();
            }
        }
    }



}
