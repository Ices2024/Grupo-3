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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonTurno_Click(object sender, EventArgs e)
        {

            TurnoForm turnoForm = new TurnoForm();
            turnoForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCanchas formCanchas = new FormCanchas();
            formCanchas.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente();
            formCliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.Show();
        }
    }
}
