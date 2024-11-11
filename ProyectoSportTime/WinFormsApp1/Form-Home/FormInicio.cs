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
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            // Cargar configuraciones o ajustes necesarios al abrir el formulario
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Manejo de eventos de clic para etiquetas (si es necesario)
        }

        private void buttonTurno_Click(object sender, EventArgs e)
        {
            // Oculta FormInicio y abre el formulario de Turnos
            this.Hide();
            TurnoForm turnoForm = new TurnoForm();

            turnoForm.FormClosed += (s, args) => this.Show(); // Muestra FormInicio cuando TurnoForm se cierra
            turnoForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Oculta FormInicio y abre el formulario de Canchas
            this.Hide();
            FormCanchas formCanchas = new FormCanchas();

            formCanchas.FormClosed += (s, args) => this.Show(); // Muestra FormInicio cuando FormCanchas se cierra
            formCanchas.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Oculta FormInicio y abre el formulario de Cliente
            this.Hide();
            FormCliente formCliente = new FormCliente();

            formCliente.FormClosed += (s, args) => this.Show(); // Muestra FormInicio cuando FormCliente se cierra
            formCliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Oculta FormInicio y abre el formulario de Productos
            this.Hide();
            FormProductos formProductos = new FormProductos();

            formProductos.FormClosed += (s, args) => this.Show(); // Muestra FormInicio cuando FormProductos se cierra
            formProductos.Show();
        }
    }
}

