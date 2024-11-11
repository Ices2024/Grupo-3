using Negocio.Implementations;
using Negocio.Repositorys;
using Shared.Dtos;
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
    public partial class FormCliente : Form
    {

        private readonly ClientesLogic _clientesLogic;
        private int? _clienteIdSeleccionado = null;

        public FormCliente()
        {
            InitializeComponent();
            _clientesLogic = new ClientesLogic();
            CargarClientes();
        }

        private async void CargarClientes()
        {
            var clientes = await _clientesLogic.ObtenerTodosLosClientes();
            dataGridView1.DataSource = clientes;
        }

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNombre.Text) &&
            !string.IsNullOrEmpty(textBoxTelefono.Text))
            {
                var nuevoCliente = new ClienteDTO
                {
                    Nombre = textBoxNombre.Text,
                    NumeroTelefono = int.Parse(textBoxTelefono.Text)
                };

                // Llamamos a la lógica para guardar el cliente
                var (success, message) = await _clientesLogic.AltaCliente(nuevoCliente);

                if (success)
                {
                    MessageBox.Show(message);  // Mensaje de éxito
                    ActualizarDataGridView();  // Actualizamos el DataGridView
                }
                else
                {
                    MessageBox.Show(message);  // Mensaje de error (si el cliente no se puede guardar)
                }
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.");
            }
        }

        private async void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridView1.SelectedRows[0];
                int clienteId = (int)filaSeleccionada.Cells["Cliente_ID"].Value;

                var cliente = await _clientesLogic.ObtenerClientePorId(clienteId);
                if (cliente != null)
                {
                    cliente.Nombre = textBoxNombre.Text;
                    cliente.NumeroTelefono = int.Parse(textBoxTelefono.Text);

                    await _clientesLogic.ModificarCliente(clienteId, cliente);
                    ActualizarDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para modificar.");
            }
        }

        private async void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridView1.SelectedRows[0];
                int clienteId = (int)filaSeleccionada.Cells["Cliente_ID"].Value;

                var cliente = await _clientesLogic.ObtenerClientePorId(clienteId);
                if (cliente != null)
                {
                    try
                    {
                        await _clientesLogic.BajaCliente(clienteId);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    // Llamamos a la lógica para eliminar el cliente
                    MessageBox.Show("Cliente eliminado correctamente.");
                    ActualizarDataGridView();  // Actualizamos el DataGridView
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
            }
        }

        private async void ActualizarDataGridView()
        {
            var clientes = await _clientesLogic.ObtenerTodosLosClientes();  // Obtenemos la lista de clientes
            dataGridView1.DataSource = clientes.Select(c => new
            {
                c.Cliente_ID,
                c.Nombre,
                c.NumeroTelefono
            }).ToList();  // Llenamos el DataGridView con los clientes
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
