using Formulario.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Controller
{
    class PartidoControlador
    {

        public static async Task<Uri> agregar(Partido partido)
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:8080/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await cliente.PostAsJsonAsync(
                "Partido/Crear", partido);
            response.EnsureSuccessStatusCode();


            // return URI of the created resource.
            return response.Headers.Location;
        }


        public static async Task<List<Partido>> listarAsync()
        {


            HttpClient cliente = new HttpClient();
            List<Partido> listaPartidos = new List<Partido>();
            HttpResponseMessage response = await cliente.GetAsync($"http://localhost:8080/Partido/Lista");

            listaPartidos = await response.Content.ReadAsAsync<List<Partido>>();

            return listaPartidos;


        }

        public static async Task<Uri> actualizar(Partido participante)
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:8080/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await cliente.PutAsJsonAsync(
                "Partido/Editar", participante);
            response.EnsureSuccessStatusCode();


            // return URI of the created resource.
            return response.Headers.Location;
        }

        public static async Task<Partido> buscar(Id id)
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:8080/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            Partido partido = null;

            HttpResponseMessage response = await cliente.PostAsJsonAsync(
                "Partido/Buscar", id);
           // response.EnsureSuccessStatusCode();

            partido = await response.Content.ReadAsAsync<Partido>();

            // return URI of the created resource.
            return partido;


            /* var handler = new WinHttpHandler();
             HttpClient cliente = new HttpClient(handler);
             Partido partido = null;
             string json = JsonConvert.SerializeObject(id);

             var request = new HttpRequestMessage
             {
                 Method = HttpMethod.Get,
                 RequestUri = new Uri("http://localhost:8080/Partido/Buscar"),
                 Content = new StringContent(json, Encoding.UTF8, "application/json"),
             };


             HttpResponseMessage response = await cliente.SendAsync(request);
             response.EnsureSuccessStatusCode();

             partido = await response.Content.ReadAsAsync<Partido>();

             return partido;*/
        }

        public static async Task<HttpStatusCode> eliminar(Id id)
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:8080/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
          //  Partido partido = null;

            HttpResponseMessage response = await cliente.PostAsJsonAsync(
                "Partido/Eliminar", id);
            // response.EnsureSuccessStatusCode();

            //partido = await response.Content.ReadAsAsync<Partido>();

            // return URI of the created resource.
            return response.StatusCode;
        }
    }
}
