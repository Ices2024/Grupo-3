using System.Net.Http.Json;
using Shared.Entidades;
using System.Data;
using Shared.Dtos;
using System.Text.Json;
using Newtonsoft.Json;

namespace WinForm.Form_Home
{
    public partial class TurnoForm : Form
    {
        private readonly HttpClient _httpClient;

        public TurnoForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7094/api/") };
            CargarDatos();
            ActualizarDataGridView();
        }

        private async void CargarDatos()
        {
            try
            {
                var responseCanchas = await _httpClient.GetAsync("Canchas");
              
                if (responseCanchas.IsSuccessStatusCode)
                {
                    var canchasJson = await responseCanchas.Content.ReadAsStringAsync();
                    var canchas = JsonConvert.DeserializeObject<List<Canchas>>(canchasJson);

                    if (canchas != null && canchas.Count > 0)
                    {
                        comboBoxCancha.DataSource = canchas;
                        comboBoxCancha.DisplayMember = "DisplayName"; // Usar la propiedad calculada
                        comboBoxCancha.ValueMember = "Cancha_ID";
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron canchas.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar canchas.");
                }

                var responseProductos = await _httpClient.GetAsync("productos");
                if (responseProductos.IsSuccessStatusCode)
                {
                    var productosJson = await responseProductos.Content.ReadAsStringAsync();
                    var productos = JsonConvert.DeserializeObject<List<Productos>>(productosJson);

                    if (productos != null && productos.Count > 0)
                    {
                        comboBoxConsumicion.DataSource = productos;
                        comboBoxConsumicion.DisplayMember = "DisplayName"; // Usar la propiedad calculada
                        comboBoxConsumicion.ValueMember = "Producto_ID";
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron productos.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar productos.");
                }

                var responseClientes = await _httpClient.GetAsync("clientes");
                if (responseClientes.IsSuccessStatusCode)
                {
                    var clientesJson = await responseClientes.Content.ReadAsStringAsync();
                    var clientes = JsonConvert.DeserializeObject<List<Clientes>>(clientesJson);

                    if (clientes != null && clientes.Count > 0)
                    {
                        comboBoxCliente.DataSource = clientes;
                        comboBoxCliente.DisplayMember = "DisplayName"; // Usar la propiedad calculada
                        comboBoxCliente.ValueMember = "Cliente_ID";
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron clientes.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar clientes.");
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
                comboBoxConsumicion.SelectedValue is int productoId &&
                comboBoxCliente.SelectedValue is int clienteId)
            {
                int cantidad = (int)numericUpDownCantidad.Value;

                var nuevaConsumicion = new Consumiciones
                {
                    Cantidad = cantidad,
                    Cod_Producto = productoId
                };

                var responseConsumicion = _httpClient.PostAsJsonAsync("consumiciones", nuevaConsumicion).Result;
                responseConsumicion.EnsureSuccessStatusCode();
                var consumicionCreada = responseConsumicion.Content.ReadFromJsonAsync<Consumiciones>().Result;

                var nuevoTurno = new Turnos
                {
                    Cancha_ID = canchaId,
                    HoraInicio = dateTimePicker1.Value,
                    HoraFin = dateTimePicker2.Value,
                    Consumicion_ID = consumicionCreada.Consumicion_ID,
                    Cliente_ID = clienteId
                };

                var responseTurno = _httpClient.PostAsJsonAsync("turnos", nuevoTurno).Result;
                responseTurno.EnsureSuccessStatusCode();

                MessageBox.Show("Turno guardado correctamente.");
                ActualizarDataGridView();
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos correctamente.");
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTurnos.SelectedRows.Count > 0 &&
                comboBoxCliente.SelectedValue is int clienteId)
            {
                var filaSeleccionada = dataGridViewTurnos.SelectedRows[0];
                int turnoId = (int)filaSeleccionada.Cells["Turno_ID"].Value;

                var response = _httpClient.GetAsync($"turnos/{turnoId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var turno = response.Content.ReadFromJsonAsync<Turnos>().Result;
                    if (turno != null)
                    {
                        turno.Cancha_ID = (int)comboBoxCancha.SelectedValue;
                        turno.HoraInicio = dateTimePicker1.Value;
                        turno.HoraFin = dateTimePicker2.Value;
                        turno.Cliente_ID = clienteId;

                        var consumicionResponse = _httpClient.GetAsync($"consumiciones/{turno.Consumicion_ID}").Result;
                        if (consumicionResponse.IsSuccessStatusCode)
                        {
                            var consumicion = consumicionResponse.Content.ReadFromJsonAsync<Consumiciones>().Result;
                            consumicion.Cantidad = (int)numericUpDownCantidad.Value;
                            consumicion.Cod_Producto = (int)comboBoxConsumicion.SelectedValue;

                            _httpClient.PutAsJsonAsync($"consumiciones/{consumicion.Consumicion_ID}", consumicion).Wait();
                        }

                        _httpClient.PutAsJsonAsync($"turnos/{turnoId}", turno).Wait();
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

                var response = _httpClient.GetAsync($"turnos/{turnoId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var turno = response.Content.ReadFromJsonAsync<Turnos>().Result;
                    if (turno != null)
                    {
                        _httpClient.DeleteAsync($"consumiciones/{turno.Consumicion_ID}").Wait();
                        _httpClient.DeleteAsync($"turnos/{turnoId}").Wait();
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

        private void ActualizarDataGridView()
        {
            var turnos = _httpClient.GetFromJsonAsync<List<TurnoDTO>>("turnos").Result;
            var productos = _httpClient.GetFromJsonAsync<List<ProductoDTO>>("productos").Result;

            dataGridViewTurnos.DataSource = turnos.Select(t => new
            {
                t.Turno_ID,
                Cancha = t.Cancha_ID,
                Cliente = t.Cliente_ID,
                Producto = productos.FirstOrDefault(p => p.Producto_ID == t.Consumicion_ID)?.Tipo,
                t.HoraInicio,
                t.HoraFin,
                t.Consumicion.Cantidad,
                t.Consumicion.Producto.DisplayName
            
            }).ToList();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            comboBoxCancha.SelectedIndex = -1;
            comboBoxConsumicion.SelectedIndex = -1;
            comboBoxCliente.SelectedIndex = -1;
            numericUpDownCantidad.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            Close();
            var homeForm = new Form1();
            homeForm.Show();
        }
    }

}



