using System.Net.Http.Json;
using Shared.Entidades;
using System.Data;
using Shared.Dtos;
using System.Text.Json;
using Negocio.Implementations;
using Negocio.Repositorios;

namespace WinForm.Form_Home
{
    public partial class TurnoForm : Form
    {
        private readonly TurnosLogic _turnosLogic;

        public TurnoForm(TurnosLogic turnosLogic)
        {
            InitializeComponent();
            _turnosLogic = turnosLogic;
            CargarDatos();
            ActualizarDataGridView();
        }

        private async void CargarDatos()
        {
            try
            {
                var canchas = await _turnosLogic.ObtenerCanchasAsync();
                comboBoxCancha.DataSource = canchas;
                comboBoxCancha.DisplayMember = "DisplayName";
                comboBoxCancha.ValueMember = "Cancha_ID";

                var productos = await _turnosLogic.ObtenerProductosAsync();
                comboBoxConsumicion.DataSource = productos;
                comboBoxConsumicion.DisplayMember = "DisplayName";
                comboBoxConsumicion.ValueMember = "Producto_ID";

                var clientes = await _turnosLogic.ObtenerClientesAsync();
                comboBoxCliente.DataSource = clientes;
                comboBoxCliente.DisplayMember = "DisplayName";
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

                var consumicionCreada = await _turnosLogic.CrearConsumicionAsync(nuevaConsumicion);
                var nuevoTurno = new Turnos
                {
                    Cancha_ID = canchaId,
                    HoraInicio = dateTimePicker1.Value,
                    HoraFin = dateTimePicker2.Value,
                    Consumicion_ID = consumicionCreada.Consumicion_ID,
                    Cliente_ID = clienteId
                };

                await _turnosLogic.CrearTurnoAsync(nuevoTurno);
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

                var turno = await _turnosLogic.ObtenerPorId(turnoId);
                if (turno != null)
                {
                    turno.Cancha_ID = (int)comboBoxCancha.SelectedValue;
                    turno.HoraInicio = dateTimePicker1.Value;
                    turno.HoraFin = dateTimePicker2.Value;
                    turno.Cliente_ID = clienteId;

                    var consumicion = await _turnosLogic.ObtenerConsumicion(turno.Consumicion_ID);
                    consumicion.Cantidad = (int)numericUpDownCantidad.Value;
                    consumicion.Cod_Producto = (int)comboBoxConsumicion.SelectedValue;

                    await _turnosLogic.ModificarConsumicionAsync(consumicion);
                    await _turnosLogic.ModificarTurnoAsync(turnoId, turno);
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

                var turno = await _turnosLogic.ObtenerPorId(turnoId);
                if (turno != null)
                {
                    await _turnosLogic.Borrar(turnoId);
                    await _turnosLogic.BorrarConsumicion(turno.Consumicion_ID);
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
            var turnos = await _turnosLogic.ObtenerTodos();
            var productos = await _turnosLogic.ObtenerProductosAsync();

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
            dateTimePicker2.Value = DateTime.Now.AddHours(1);
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var homeForm = new Form1();
            homeForm.Show();
        }

    }



