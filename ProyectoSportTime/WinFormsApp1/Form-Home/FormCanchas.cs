using Negocio.Implementations;
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
    public partial class FormCanchas : Form
    {
        private readonly CanchasLogic _canchasLogic;
        private List<DeporteDTO> _deportes;

        public FormCanchas()
        {
            InitializeComponent();
            _canchasLogic = new CanchasLogic();  // Lógica de negocio
            CargarDeportes();
        }

        private async void CargarDeportes()
        {
            _deportes = await _canchasLogic.ObtenerTodosLosDeportes();  // Obtiene los deportes desde la lógica
            comboBoxDeporte.DataSource = _deportes;
            comboBoxDeporte.DisplayMember = "Nombre";
            comboBoxDeporte.ValueMember = "Deporte_ID";
        }

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (comboBoxDeporte.SelectedValue is int deporteId && !string.IsNullOrEmpty(txtTipo.Text))
            {
                var nuevaCancha = new CanchaDTO
                {
                    Deporte_ID = deporteId,
                    Tipo = textBoxTipo.Text
                };

                await _canchasLogic.AltaCancha(nuevaCancha);  // Llamar a la lógica para guardar
                MessageBox.Show("Cancha guardada correctamente.");
                ActualizarDataGridView();  // Actualizar la vista
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.");
            }
        }

        private async void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
            comboBoxDeporte.SelectedValue is int deporteId &&
            !string.IsNullOrEmpty(txtTipo.Text))
            {
                var filaSeleccionada = dataGridView1.SelectedRows[0];
                int canchaId = (int)filaSeleccionada.Cells["Cancha_ID"].Value;

                var canchaModificada = new CanchaDTO
                {
                    Deporte_ID = deporteId,
                    Tipo = txtTipo.Text
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
            var canchas = await _canchasLogic.ObtenerTodasLasCanchas();  // Obtiene las canchas desde la lógica
            dataGridView1.DataSource = canchas.Select(c => new
            {
                c.Cancha_ID,
                Deporte = _deportes.FirstOrDefault(d => d.Deporte_ID == c.Deporte_ID)?.Nombre,
                c.Tipo
            }).ToList();
        }

    }
}

