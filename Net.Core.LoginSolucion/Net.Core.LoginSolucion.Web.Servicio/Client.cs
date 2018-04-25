using Net.Core.LoginSolucion.Api.ModeloDeDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.LoginSolucion.Web.Servicio
{
    public class Client
    {
        private readonly string BaseAddress = "http://localhost:50554/api/";

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            IEnumerable<Usuario> ListUsuarios = new List<Usuario>();

            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseAddress);
                cliente.DefaultRequestHeaders.Clear();

                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage mensaje = await cliente.GetAsync("Usuarios/GetAll");
                if (mensaje.IsSuccessStatusCode)
                {
                    var result = mensaje.Content.ReadAsStringAsync().Result;
                    ListUsuarios = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(result);
                }
                return ListUsuarios;
            }
        }

        public Usuario CreateUsuario(Usuario model)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(BaseAddress);
                cliente.DefaultRequestHeaders.Clear();

                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                               

                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                HttpResponseMessage res = cliente.PostAsync("Usuarios/Post", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return model;
                }
                return null;
            }
        }
    }
}
