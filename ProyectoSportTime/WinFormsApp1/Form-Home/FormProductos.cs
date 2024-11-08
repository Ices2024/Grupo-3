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
    public partial class FormProductos : Form
    {
        private readonly ProductosLogic _productosLogic;

        public FormProductos()
        {
            InitializeComponent();
            _productosLogic = new ProductosLogic();  // Lógica de negocio
            ActualizarDataGridView();
        }

        private async void ActualizarDataGridView()
        {
            var productos = await _productosLogic.ObtenerTodosLosProductos();  // Obtiene los productos desde la lógica
            dataGridView1.DataSource = productos.Select(p => new
            {
                p.Producto_ID,
                p.Tipo,
                p.Descripcion,
                p.Proveedor
            }).ToList();
        }

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTipo.Text) &&
            !string.IsNullOrEmpty(txtDescripcion.Text) &&
            !string.IsNullOrEmpty(txtProveedor.Text))
            {
                var nuevoProducto = new ProductoDTO
                {
                    Tipo = txtTipo.Text,
                    Descripcion = txtDescripcion.Text,
                    Proveedor = txtProveedor.Text
                };

                await _productosLogic.AltaProducto(nuevoProducto);  // Llamar a la lógica para guardar el producto
                MessageBox.Show("Producto guardado correctamente.");
                ActualizarDataGridView();  // Actualizar la vista
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.");
            }
        }

        private async void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridView1.SelectedRows[0];
                int productoId = (int)filaSeleccionada.Cells["Producto_ID"].Value;

                await _productosLogic.BajaProducto(productoId);  // Llamar a la lógica para eliminar el producto
                MessageBox.Show("Producto eliminado correctamente.");
                ActualizarDataGridView();  // Actualizar la vista
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
            }
        }

        private async void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
           !string.IsNullOrEmpty(txtTipo.Text) &&
           !string.IsNullOrEmpty(txtDescripcion.Text) &&
           !string.IsNullOrEmpty(txtProveedor.Text))
            {
                var filaSeleccionada = dataGridView1.SelectedRows[0];
                int productoId = (int)filaSeleccionada.Cells["Producto_ID"].Value;

                var productoModificado = new ProductoDTO
                {
                    Tipo = txtTipo.Text,
                    Descripcion = txtDescripcion.Text,
                    Proveedor = textBoxProveedor.Text
                };

                await _productosLogic.ModificarProducto(productoId, productoModificado);  // Llamar a la lógica para modificar
                MessageBox.Show("Producto modificado correctamente.");
                ActualizarDataGridView();  // Actualizar la vista
            }
            else
            {
                MessageBox.Show("Seleccione un producto para modificar.");
            }
        }
    }
}
