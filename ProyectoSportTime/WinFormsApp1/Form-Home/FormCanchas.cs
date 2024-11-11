using Negocio.Implementations;
using Newtonsoft.Json;
using Shared.Dtos;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Form_Home
{
    public partial class FormCanchas : Form
    {
        private readonly CanchasLogic _canchasLogic;
        private readonly DeportesLogic _deportesLogic;
        private List<DeporteDTO> _deportes;
        private readonly HttpClient _httpClient;

        public FormCanchas()
        {
            InitializeComponent();

            // Inicialización de HttpClient para hacer llamadas a la API
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7094/api/") };

            // Inicialización de lógica de negocio, si es necesario
            _canchasLogic = new CanchasLogic();
            _deportesLogic = new DeportesLogic();

            CargarDeportes();
        }

        private async void CargarDeportes()
        {
            try
            {
                var responseDeportes = await _httpClient.GetAsync("Deportes"); // Llamada al endpoint correcto de deportes
                if (responseDeportes.IsSuccessStatusCode)
                {
                    var deportesJson = await responseDeportes.Content.ReadAsStringAsync();
                    var deportes = JsonConvert.DeserializeObject<List<DeporteDTO>>(deportesJson); // Cambia "Deportes" por "DeporteDTO"

                    if (deportes != null && deportes.Count > 0)
                    {
                        comboBoxDeporte.DataSource = deportes;
                        comboBoxDeporte.DisplayMember = "Deporte_ID";
                        comboBoxDeporte.ValueMember = "Deporte_ID";
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron deportes.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar deportes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (comboBoxDeporte.SelectedValue is int deporteId)
            {
                // El tipo de deporte se obtendrá automáticamente de la base de datos
                var nuevaCancha = new CanchaDTO
                {
                    Deporte_ID = deporteId,
                    // El tipo se obtiene al crear la cancha, no se necesita un TextBox para esto
                };

                await _canchasLogic.AltaCancha(nuevaCancha);  // Llamar a la lógica para guardar
                MessageBox.Show("Cancha guardada correctamente.");
                ActualizarDataGridView();  // Actualizar la vista
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un deporte.");
            }
        }

        private async void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && comboBoxDeporte.SelectedValue is int deporteId)
            {
                var filaSeleccionada = dataGridView1.SelectedRows[0];
                int canchaId = (int)filaSeleccionada.Cells["Cancha_ID"].Value;

                var canchaModificada = new CanchaDTO
                {
                    Deporte_ID = deporteId,
                };

                await _canchasLogic.ModificarCancha(canchaId, canchaModificada);  // Llamar a la lógica para modificar
                MessageBox.Show("Cancha modificada correctamente.");
                ActualizarDataGridView();  // Actualizar la vista
            }
            else
            {
                MessageBox.Show("Seleccione una cancha para modificar.");
            }
        }

        private async void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridView1.SelectedRows[0];
                int canchaId = (int)filaSeleccionada.Cells["Cancha_ID"].Value;

                await _canchasLogic.BajaCancha(canchaId);  // Llamar a la lógica para eliminar
                MessageBox.Show("Cancha eliminada correctamente.");
                ActualizarDataGridView();  // Actualizar la vista
            }
            else
            {
                MessageBox.Show("Seleccione una cancha para eliminar.");
            }
        }

        private async void ActualizarDataGridView()
        {
            var canchas = await _canchasLogic.ObtenerTodasLasCanchas();

            dataGridView1.DataSource = canchas.Select(c => new
            {
                c.Cancha_ID,
                c.Deporte_ID,
                c.Tipo  // El tipo de deporte será mostrado aquí, automáticamente recuperado
            }).ToList();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


