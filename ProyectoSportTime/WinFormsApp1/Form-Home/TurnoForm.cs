using System.Net.Http.Json;
using Shared.Entidades;
using System.Data;
using Shared.Dtos;
using System.Text.Json;
using Newtonsoft.Json;
using Negocio.Implementations;
using Negocio.Repositorys;

namespace WinForm.Form_Home
{
    public partial class TurnoForm : Form
    {
        private readonly TurnosLogic _turnosLogic;
        private readonly HttpClient _httpClient;

        public TurnoForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7094/api/") };
            _turnosLogic = new TurnosLogic();  // Inicializa la lógica de turnos
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

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (comboBoxCancha.SelectedValue is int canchaId &&
                //comboBoxConsumicion.SelectedValue is int productoId &&
                comboBoxCliente.SelectedValue is int clienteId)
            {
                //int cantidad = (int)numericUpDownCantidad.Value;

                //var nuevaConsumicion = new ConsumicionDTO();
                ////{
                ////    Cantidad = cantidad,
                ////    Cod_Producto = productoId
                ////};

                // Asumiendo que tienes un método para crear consumiciones en el repositorio
                //var consumicionCreada =  ConsumicionesRepository.CreateConsumicion(nuevaConsumicion);

                var nuevoTurno = new TurnoDTO
                {
                    Cancha_ID = canchaId,
                    HoraInicio = dateTimePicker1.Value,
                    HoraFin = dateTimePicker2.Value,
                    Consumicion_ID = 0,
                    Cliente_ID = clienteId
                };

                await _turnosLogic.CrearTurno(nuevoTurno);

                MessageBox.Show("Turno guardado correctamente.");
                ActualizarDataGridView();
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

                var turno = await _turnosLogic.ObtenerTurnoPorId(turnoId);
                if (turno != null)
                {
                    turno.Cancha_ID = (int)comboBoxCancha.SelectedValue;
                    turno.HoraInicio = dateTimePicker1.Value;
                    turno.HoraFin = dateTimePicker2.Value;
                    turno.Cliente_ID = clienteId;

                    var consumicionResponse = await _httpClient.GetAsync($"consumiciones/{turno.Consumicion_ID}");
                    if (consumicionResponse.IsSuccessStatusCode)
                    {
                        var consumicion = await consumicionResponse.Content.ReadFromJsonAsync<Consumiciones>();
                        consumicion.Cantidad = (int)numericUpDownCantidad.Value;
                       

                        await _httpClient.PutAsJsonAsync($"consumiciones/{consumicion.Consumicion_ID}", consumicion);
                    }

                    await _turnosLogic.ModificarTurno(turnoId, turno);
                    MessageBox.Show("Turno modificado correctamente.");
                    ActualizarDataGridView();
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

                var turno = await _turnosLogic.ObtenerTurnoPorId(turnoId);
                if (turno != null)
                {
                    await _httpClient.DeleteAsync($"consumiciones/{turno.Consumicion_ID}");
                    await _turnosLogic.BorrarTurno(turnoId);
                    MessageBox.Show("Turno eliminado correctamente.");
                    ActualizarDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un turno para eliminar.");
            }
        }

        private async void ActualizarDataGridView()
        {
            var turnos = await _turnosLogic.ObtenerTodosLosTurnos();
            var productos = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>("productos");

            dataGridViewTurnos.DataSource = turnos.Select(t => new
            {
                t.Turno_ID,
                Cancha = t.Cancha_ID,
                Cliente = t.Cliente_ID,
                Producto = productos.FirstOrDefault(p => p.Producto_ID == t.Consumicion_ID)?.Tipo,
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
            dateTimePicker2.Value = DateTime.Now;
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            Close();
            var homeForm = new FormInicio();
            homeForm.Show();
        }
    }

}



