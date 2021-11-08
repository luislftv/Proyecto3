using Formulario.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Formulario.Controller
{
    class ParticipanteControlador
    {
        

        public static async Task<Uri> agregar(Participante participante) 
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:8080/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await cliente.PostAsJsonAsync(
                "Participante/Crear", participante);
            response.EnsureSuccessStatusCode();
            

            // return URI of the created resource.
            return response.Headers.Location;
        }


        public static async Task<List<Participante>> listarAsync() 
        {


            HttpClient cliente = new HttpClient();
            List < Participante > listaParticipantes = new List<Participante>();
            HttpResponseMessage response = await cliente.GetAsync($"http://localhost:8080/Participante/Lista");

            listaParticipantes = await response.Content.ReadAsAsync<List<Participante>>();

            return listaParticipantes;


        }

        public static async Task<Uri> actualizar(Participante participante)
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:8080/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await cliente.PutAsJsonAsync(
                "Participante/Editar", participante);
            response.EnsureSuccessStatusCode();


            // return URI of the created resource.
            return response.Headers.Location;
        }

        public static async Task<Participante> buscar(int id)
        {
            HttpClient cliente = new HttpClient();
            Participante participante = null;
            HttpResponseMessage response = await cliente.GetAsync($"http://localhost:8080/Participante/Buscar/{id}");
           
                participante = await response.Content.ReadAsAsync<Participante>();
            
            return participante;
        }

        public static async Task<HttpStatusCode> eliminar(int id)
        {
            HttpClient cliente = new HttpClient();
            HttpResponseMessage response = await cliente.DeleteAsync(
                $"http://localhost:8080/Participante/Eliminar/{id}");
            return response.StatusCode;
        }

        public static async Task<int[]> estadisticas(int id)
        {
            HttpClient cliente = new HttpClient();
            int[] participante = null;
            HttpResponseMessage response = await cliente.GetAsync($"http://localhost:8080/Participante/Lista/estadisticas/{id}");

            participante = await response.Content.ReadAsAsync<int[]>();

            return participante;
        }

        public static async Task<List<Participante>> listarFiltroAsync(String apodo)
        {


            HttpClient cliente = new HttpClient();
            List<Participante> listaParticipantes = new List<Participante>();
            HttpResponseMessage response = await cliente.GetAsync($"http://localhost:8080/Participante/Lista/Filtrar/{apodo}");

            listaParticipantes = await response.Content.ReadAsAsync<List<Participante>>();

            return listaParticipantes;


        }


    }
}
