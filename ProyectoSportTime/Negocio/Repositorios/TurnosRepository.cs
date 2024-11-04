using Microsoft.AspNetCore.Hosting.Server;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Clientehttp;
using Negocio.Helper;
using Newtonsoft.Json;
using Negocio.Repositorios;



namespace Shared.Repositorios
{
    internal class TurnosRepository : ITurnosRepository
    {
        public async Task<List<TurnoDTO>> ObtenerTodosAsync()
        {
            try
            {
                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(
                        ApiServer.ObtenerUrlEndPoint(
                            ApplicationConfiguration.GetSetting(
                                "ApiServer:EndPoints:Turnos:ObtenerTodo"
                            )
                        )
                    );

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<TurnoDTO>>(result);
                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception("Failed to connect to API server");
            }
        }

        public async Task<TurnoDTO?> ObtenerPorIdAsync(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Turnos:ObtenerPorId"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<TurnoDTO>(result);
                    return returnModel!;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"Failed to retrieve item returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception("Failed to connect to API server");
            }
        }

        public async Task<TurnoDTO> CrearAsync(TurnoDTO nuevoTurno)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Turnos:Crear");
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(nuevoTurno),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PostAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<TurnoDTO>(result);
                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to create item returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception("Failed to connect to API server");
            }
        }

        public async Task EliminarAsync(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Turnos:Borrar"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .DeleteAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to delete item returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception("Failed to connect to API server");
            }
        }

        public async Task<TurnoDTO> UpdateAsync(int id, TurnoDTO turnoModificado)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Turnos:Actualizar"
                );
                path = string.Format(path, id);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(turnoModificado),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PutAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<TurnoDTO>(result);
                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to update item returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception("Failed to connect to API server");
            }
        }


        /*
        public static async Task<List<TurnoDTO>> ObtenerTodosAsync()
        {
            try
            {
                var response = await ApiServer
                .ObtenerClientHttp()
                    .GetAsync(
                        ApiServer.ObtenerUrlEndPoint(
                            ApplicationConfiguration.GetSetting(
                                "ApiServer:EndPoints:Turnos:ObtenerTodo"
                            )
                        )
                    );

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<TurnoDTO>>(result);
                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<TurnoDTO?> ObtenerPorIdAsync(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Turnos:ObtenerPorId"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<TurnoDTO>(result);
                    return returnModel!;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"Failed to retrieve item returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<TurnoDTO> CrearAsync(TurnoDTO nuevoTurno)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Turnos:Crear");
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(nuevoTurno),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                .ObtenerClientHttp()
                    .PostAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<TurnoDTO>(result);
                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to create items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task EliminarAsync(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Turnos:Borrar"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                .ObtenerClientHttp()
                    .DeleteAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to delete items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<TurnoDTO> UpdateAsync(int id, TurnoDTO turnoModificado)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Turnos:Actualizar"
                );
                path = string.Format(path, id);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(turnoModificado),
                    Encoding.UTF8,
                "application/json"
                );

                var response = await ApiServer
                .ObtenerClientHttp()
                    .PutAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<TurnoDTO>(result);
                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to update items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }
    }
    */
    }
}
