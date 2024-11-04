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
            LoginDTO login = new LoginDTO
            {
                Email = textBoxEmail.Text,  
                Password = textBoxPassword.Text,
            };
            
            // TOdo esto lo van a tener que generar por cada solicitud que hagan a menos que reutilicen creando meotodos por cada verbo




            // este es el objeto que te permite hacer solicitudes http asi chiquito como lo ves es mas potente que la mierda
            HttpClient httpClient = new HttpClient();

            // se crea un json serializando el dto loginDTO
            
            var json = JsonConvert.SerializeObject(login);

            // se crea un content con ese json , lo demas es configuracion por defeco osea el encofing y el formato application/json
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // aca se usa el objeto httpclient para hacer la solidictud post, se le pasa el endpoint y el content para sumarlo al body de la solicitu 
            var response = await httpClient.PostAsync("https://localhost:7094/api/administrador/login",content);

            // aca se lee el content de la repsuesta y se lo convierte en un string , pero tiene formato json
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // aca podrian deserializar ese json y convertirlo en un objeto para poder acceder a sus propiedades, asi seria:
            //var Response = JsonConvert.DeserializeObject<ELobjeto>(jsonResponse);
            var Response = JsonConvert.DeserializeObject(jsonResponse);
            
            // aca para que el usuraio vean si anda o no , osea tendria que tiar OK si ta bien Unauthorized si esta mal la password o el email
            MessageBox.Show(response.StatusCode.ToString());

            // esto es lo que ustedes pusieron en el action resultmostrado en pantalla
            MessageBox.Show(jsonResponse);

            //suerte
        }
    }
}
