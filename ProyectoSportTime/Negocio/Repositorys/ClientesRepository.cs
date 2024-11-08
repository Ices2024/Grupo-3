using Negocio.ClienteHttp;
using Newtonsoft.Json;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repositorys
{
    public class ClientesRepository
    {
        // Crear un nuevo cliente
        public static async Task CreateCliente(ClienteDTO clienteDto)
        {
            ArgumentNullException.ThrowIfNull(clienteDto);

            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint("clientes");
            var content = new StringContent(JsonConvert.SerializeObject(clienteDto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        // Actualizar un cliente existente
        public static async Task UpdateCliente(int clienteID, ClienteDTO clienteModificadoDto)
        {
            ArgumentNullException.ThrowIfNull(clienteModificadoDto);

            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint($"clientes/{clienteID}");
            var content = new StringContent(JsonConvert.SerializeObject(clienteModificadoDto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }

        // Eliminar un cliente
        public static async Task DeleteCliente(int clienteID)
        {
            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint($"clientes/{clienteID}");

            var response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        // Obtener todos los clientes
        public static async Task<List<ClienteDTO>> GetAllClientes()
        {
            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint("clientes");

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ClienteDTO>>(result);
        }

        // Obtener un cliente por su ID
        public static async Task<ClienteDTO?> GetClienteById(int id)
        {
            var client = ApiServer.ObtenerClientHttp();
            var url = ApiServer.ObtenerUrlEndPoint($"clientes/{id}");

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClienteDTO>(result);
        }
    }

}
