using Newtonsoft.Json;
using Shared.Dtos;
using System.Text;
using WinForm.Form_Home;

namespace WinForm.FormAdmin
{
    public partial class InicoSesion : Form
    {
        public InicoSesion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private async void buttonInSc_Click(object sender, EventArgs e)
        {
            LoginDTO login = new LoginDTO
            {
                Email = textBoxEmail.Text,
                Password = textBoxPassword.Text,
            };

            HttpClient httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:7094/api/administrador/login", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                var homeForm = new FormInicio();
                homeForm.Show();
                this.Hide(); // Oculta el formulario de inicio de sesión en lugar de cerrarlo
            }
            else
            {
                MessageBox.Show("Error en el inicio de sesión: " + jsonResponse);
            }

        }
    }
}
