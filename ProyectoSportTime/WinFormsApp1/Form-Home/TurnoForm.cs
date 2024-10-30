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
        private readonly HttpClient _httpClient;

        public TurnoForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("http://tu-api-url/api/") };
        }

        private async void TurnoForm_Load(object sender, EventArgs e)
        {
            await CargarDatos();
            await ActualizarDataGridView();

            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker2.Format = DateTimePickerFormat.Time;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddHours(1);
        }

        private async Task CargarDatos()
        {
            try
            {
                // Cargar deportes
                var deportes = await _httpClient.GetFromJsonAsync<List<Deportes>>("deportes");
                comboBoxDeporte.DataSource = deportes;
                comboBoxDeporte.DisplayMember = "Tipo";
                comboBoxDeporte.ValueMember = "Deporte_ID";

                // Cargar canchas
                var canchas = await _httpClient.GetFromJsonAsync<List<Canchas>>("canchas");
                comboBoxCancha.DataSource = canchas;
                comboBoxCancha.DisplayMember = "Codigo_Deporte";
                comboBoxCancha.ValueMember = "Cancha_ID";

                // Cargar productos
                var productos = await _httpClient.GetFromJsonAsync<List<Productos>>("productos");
                comboBoxConsumicion.DataSource = productos;
                comboBoxConsumicion.DisplayMember = "Tipo";
                comboBoxConsumicion.ValueMember = "Producto_ID";

                // Cargar clientes
                var clientes = await _httpClient.GetFromJsonAsync<List<Clientes>>("clientes");
                comboBoxCliente.DataSource = clientes;
                comboBoxCliente.DisplayMember = "Nombre";
                comboBoxCliente.ValueMember = "Cliente_ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (comboBoxCancha.SelectedValue is int canchaId &&
                comboBoxConsumicion.SelectedValue is int productoId &&
                comboBoxCliente.SelectedValue is int clienteId)
            {
                int cantidad = (int)numericUpDownCantidad.Value;

                var nuevaConsumicion = new Consumiciones
                {
                    Cantidad = cantidad,
                    Cod_Producto = productoId
                };

                // Enviar nueva consumición a la API
                var responseConsumicion = await _httpClient.PostAsJsonAsync("consumiciones", nuevaConsumicion);
                responseConsumicion.EnsureSuccessStatusCode();
                var consumicionCreada = await responseConsumicion.Content.ReadFromJsonAsync<Consumiciones>();

                var nuevoTurno = new Turnos
                {
                    Cancha_ID = canchaId,
                    HoraInicio = dateTimePicker1.Value,
                    HoraFin = dateTimePicker2.Value,
                    Consumicion_ID = consumicionCreada.Consumicion_ID,
                    Cliente_ID = clienteId
                };

                // Enviar nuevo turno a la API
                var responseTurno = await _httpClient.PostAsJsonAsync("turnos", nuevoTurno);
                responseTurno.EnsureSuccessStatusCode();

                MessageBox.Show("Turno guardado correctamente.");
                await ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos correctamente.");
            }
        }

        private async void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTurnos.SelectedRows.Count > 0 &&
                comboBoxCliente.SelectedValue is int clienteId)
            {
                var filaSeleccionada = dataGridViewTurnos.SelectedRows[0];
                int turnoId = (int)filaSeleccionada.Cells["Turno_ID"].Value;

                // Obtener el turno existente desde la API
                var response = await _httpClient.GetAsync($"turnos/{turnoId}");
                if (response.IsSuccessStatusCode)
                {
                    var turno = await response.Content.ReadFromJsonAsync<Turnos>();
                    if (turno != null)
                    {
                        turno.Cancha_ID = (int)comboBoxCancha.SelectedValue;
                        turno.HoraInicio = dateTimePicker1.Value;
                        turno.HoraFin = dateTimePicker2.Value;
                        turno.Cliente_ID = clienteId;

                        // Obtener y modificar la consumición existente
                        var consumicionResponse = await _httpClient.GetAsync($"consumiciones/{turno.Consumicion_ID}");
                        if (consumicionResponse.IsSuccessStatusCode)
                        {
                            var consumicion = await consumicionResponse.Content.ReadFromJsonAsync<Consumiciones>();
                            consumicion.Cantidad = (int)numericUpDownCantidad.Value;
                            consumicion.Cod_Producto = (int)comboBoxConsumicion.SelectedValue;

                            // Actualizar la consumición
                            await _httpClient.PutAsJsonAsync($"consumiciones/{consumicion.Consumicion_ID}", consumicion);
                        }

                        // Actualizar el turno
                        await _httpClient.PutAsJsonAsync($"turnos/{turnoId}", turno);
                        MessageBox.Show("Turno modificado correctamente.");
                        await ActualizarDataGridView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un turno para modificar.");
            }
        }

        private async void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTurnos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridViewTurnos.SelectedRows[0];
                int turnoId = (int)filaSeleccionada.Cells["Turno_ID"].Value;

                // Obtener el turno existente
                var response = await _httpClient.GetAsync($"turnos/{turnoId}");
                if (response.IsSuccessStatusCode)
                {
                    var turno = await response.Content.ReadFromJsonAsync<Turnos>();
                    if (turno != null)
                    {
                        // Obtener la consumición y eliminarla
                        await _httpClient.DeleteAsync($"consumiciones/{turno.Consumicion_ID}");

                        // Eliminar el turno
                        await _httpClient.DeleteAsync($"turnos/{turnoId}");
                        MessageBox.Show("Turno eliminado correctamente.");
                        await ActualizarDataGridView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un turno para eliminar.");
            }
        }

        private async Task ActualizarDataGridView()
        {
            var turnos = await _httpClient.GetFromJsonAsync<List<Turnos>>("turnos");

            dataGridViewTurnos.DataSource = turnos.Select(t => new
            {
                t.Turno_ID,
                Cancha = t.Canchas.Deporte_ID,
                Cliente = t.Cliente.Nombre,
                Producto = _context.Productos.FirstOrDefault(p => p.Producto_ID == t.Consumicion_ID)?.Tipo,
                t.HoraInicio,
                t.HoraFin
            }).ToList();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            comboBoxCancha.SelectedIndex = -1;
            comboBoxConsumicion.SelectedIndex = -1;
            comboBoxCliente.SelectedIndex = -1;
            numericUpDownCantidad.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddHours(1);
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var homeForm = new Form1();
            homeForm.Show();
        }
    }
}


