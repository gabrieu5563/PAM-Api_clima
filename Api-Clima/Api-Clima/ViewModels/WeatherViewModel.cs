using api_clima.Models;
using Api_Clima.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Api_Clima.Services;


namespace Api_Clima.ViewModels
{
    public partial class WeatherViewModel: ObservableObject
    {
        [ObservableProperty]
        private string cityInput;

        [ObservableProperty]
        private string cityName;

        [ObservableProperty]
        private string temp;

        [ObservableProperty]
        private string image;

        [ObservableProperty]
        private string geral; //"poucas nuvens" nao sei como vou fazer essa bomba

        private int min;  //min/max sensação de feelsLike
        private int max;
        private int feelsLike;

        [ObservableProperty]
        private string tempExtra;

        [ObservableProperty]
        private float sunrise;
        [ObservableProperty]
        private float sunset;

        [ObservableProperty]
        private string humidade;

        [ObservableProperty]
        private string vento;

        [ObservableProperty]
        private string visibilidade;

        [ObservableProperty]
        private string pressao;

        public ICommand GetCommand { get; }
        private WeatherService service;

        public WeatherViewModel()
        {
            service = new WeatherService();
            GetCommand = new RelayCommand(async() => await getWeather());
        }

        private async Task getWeather()
        {
            if (string.IsNullOrEmpty(cityInput))
            {
                App.Current.MainPage.DisplayAlert("Erro", "Escolha a cidade que deseja buscar", "ok");
                return;
            } else
            {
                var response = await service.GetWeatherResponse(cityInput);

                if (response != null && response.main != null)
                {
                    CityName = response.name;
                    Temp = (response.main.temp - 273.15) + "ºC";
                    Geral = response.weather[0].main;
                    //Min = (int)(response.main.temp_min - 273.15);
                    //Max = (int)(response.main.temp_max - 273.15);
                    //FeelsLike = (int)(response.main.feels_like - 273.15);
                    tempExtra = (int)(response.main.temp_max - 273.15) + "ºC/" + (int)(response.main.temp_min - 273.15) + "ºC. Sensação de " + (int)(response.main.feels_like - 273.15);
                    Humidade = response.main.humidity + "%";
                    Vento = response.wind.speed + "km/h";
                    Visibilidade = response.visibility/ 1000f + "km";
                    Pressao = response.main.pressure + "mb";
                } else
                {
                    App.Current.MainPage.DisplayAlert($"Erro", $"Não foi possível recuperar as informações do clima de {cityInput}.", "Ok");
                }

            }
        }
    }
}
