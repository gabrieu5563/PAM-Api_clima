using api_clima.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Api_Clima.Services
{
    public class WeatherService
    {
        private HttpClient httpClient;
        private WeatherResponse response;
        private JsonSerializerOptions jsonSerializerOptions;
        Uri uri = new Uri("https://api.openweathermap.org/data/2.5/weather?q=(cityInput aqui)&appid=");

        public WeatherService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        }
        public async Task<WeatherResponse> GetWeatherResponse(string cityInput)
        {
            string apiKey = "f5d0dd8e2bc7238a61ca96db64809e32";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityInput}&appid={apiKey}&lang=pt_br";

            try
            {
                var resp = await httpClient.GetAsync(url);

                if (!resp.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro ao acessar api: {resp.StatusCode}");
                }
                string jsonResponse = await resp.Content.ReadAsStringAsync();
                Debug.WriteLine($"Resposta JSON: {jsonResponse}");
                return JsonSerializer.Deserialize<WeatherResponse>(jsonResponse, jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar informações do clima: {ex.Message}");
            }
        }
    }
}