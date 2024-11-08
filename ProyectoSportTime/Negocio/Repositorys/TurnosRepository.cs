using System;
using Shared.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entidades;
using Negocio.ClienteHttp;
using Negocio.Helper;
using Newtonsoft.Json;

namespace Negocio.Repositorys
{
    public class TurnosRepository
    {
        public static async Task CreateTurno(TurnoDTO turno)
        {
            ArgumentNullException.ThrowIfNull(turno);

            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint("turnos");
            var content = new StringContent(JsonConvert.SerializeObject(turno), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        public static async Task UpdateTurno(int turnoID, TurnoDTO turnoModificar)
        {
            ArgumentNullException.ThrowIfNull(turnoModificar);

            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint($"turnos/{turnoID}");
            var content = new StringContent(JsonConvert.SerializeObject(turnoModificar), Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        public static async Task DeleteTurno(int turnoID)
        {
            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint($"turnos/{turnoID}");

            var response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        public static async Task<List<TurnoDTO>> GetAllTurnos()
        {
            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint("turnos");

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TurnoDTO>>(result);
        }

        public static async Task<TurnoDTO?> GetTurnoById(int id)
        {
            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint($"turnos/{id}");

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TurnoDTO>(result);
        }
    }

}
