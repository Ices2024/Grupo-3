using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Newtonsoft.Json;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        // aca ta la papa 
        private async void buttonInSc_Click(object sender, EventArgs e)
        {
            // Crea el DTO para enviar el email y la contraseña del formulario
            LoginDTO login = new LoginDTO
            {
                Email = textBoxEmail.Text,
                Password = textBoxPassword.Text,
            };

            // El HttpClient puede ser una variable reutilizable en toda la aplicación, pero si lo usas solo acá, está bien
            using (HttpClient httpClient = new HttpClient())
            {
                // Serializa el DTO a JSON
                var json = JsonConvert.SerializeObject(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Realiza la solicitud HTTP POST al API de login
                    var response = await httpClient.PostAsync("https://localhost:7094/api/administrador/login", content);

                    // Lee la respuesta como string
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    // Puedes deserializar la respuesta si sabes qué tipo de objeto esperas
                    // Ejemplo: var responseObj = JsonConvert.DeserializeObject<ResponseDTO>(jsonResponse);
                    // Para ahora, simplemente lo deserializas como objeto dinámico
                    var responseObj = JsonConvert.DeserializeObject(jsonResponse);

                    // Muestra el código de estado de la respuesta (OK, Unauthorized, etc.)
                    MessageBox.Show(response.StatusCode.ToString());

                    // Muestra el contenido de la respuesta (puedes darle formato para mayor claridad)
                    MessageBox.Show(jsonResponse);
                }
                catch (Exception ex)
                {
                    // Captura cualquier excepción y muestra un mensaje de error
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
