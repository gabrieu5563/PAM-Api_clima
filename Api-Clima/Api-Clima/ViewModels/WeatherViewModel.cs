﻿using api_clima.Models;
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
using System.Diagnostics;


namespace Api_Clima.ViewModels
{
    public partial class WeatherViewModel: ObservableObject
    {
        [ObservableProperty]
        private string cityInput;

        [ObservableProperty]
        private string escolha;

        [ObservableProperty]
        private string cityName;

        [ObservableProperty]
        private string temp;

        [ObservableProperty]
        private string image;

        [ObservableProperty]
        private string geral;

        [ObservableProperty]
        private string tempextra;

        [ObservableProperty]
        private string sunrise;
        [ObservableProperty]
        private string sunset;

        [ObservableProperty]
        private string humidade;

        [ObservableProperty]
        private string vento;

        [ObservableProperty]
        private string visibilidade;

        [ObservableProperty]
        private string pressao;

        private string lat;
        private string lon;
        private int fuso;
        private string test;

        [ObservableProperty]
        private string color;

        public ICommand GetCommand { get; }
        private WeatherService service;

        public WeatherViewModel()
        {
            service = new WeatherService();
            GetCommand = new RelayCommand(async() => await getWeather());
            Escolha = "Cidade";
            Color = "#5288c1";
        }

        public void AssignValues(WeatherResponse response)
        {
            Temp = Math.Round(response.main.temp - 273.15) + "ºC";
            Geral = char.ToUpper(response.weather[0].description[0]) + response.weather[0].description.Substring(1).ToLower();
            Tempextra = Math.Round(response.main.temp_max - 273.15) + "ºC/" + Math.Round(response.main.temp_min - 273.15) + "ºC. Sensação de " + Math.Round(response.main.feels_like - 273.15) + "ºC";
            Humidade = response.main.humidity + "%";
            Vento = response.wind.speed + "km/h";
            Visibilidade = response.visibility / 1000f + "km";
            Pressao = response.main.pressure + "mb";
            Image = "a" + response.weather[0].icon + "_t.png";
            fuso = response.timezone + 10800;
            Sunrise = DateTimeOffset.FromUnixTimeSeconds(response.sys.sunrise).AddSeconds(fuso).ToLocalTime().ToString("HH:mm");
            Sunset = DateTimeOffset.FromUnixTimeSeconds(response.sys.sunset).AddSeconds(fuso).ToLocalTime().ToString("HH:mm");
        }

        private async Task getWeather()
        {
            if (string.IsNullOrEmpty(cityInput))
            {
                App.Current.MainPage.DisplayAlert("Erro", "Escolha a cidade ou coordenada que deseja buscar", "ok");
                return;
            } else
            {
                if(Escolha == "Cidade")
                {
                    var response = await service.GetWeatherResponse(cityInput);

                    if (response != null)
                    {
                        CityName = response.name;
                        AssignValues(response);
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert($"Erro", $"Não foi possível recuperar as informações do clima de {cityInput}.", "Ok");
                    }
                }
                else
                {
                    if(Escolha == "Coordenada")
                    {
                        string[] temp = cityInput.Split(' ');
                        try
                        {
                            lat = temp[0];
                            lon = temp[1];
                            if (temp.Length > 2)
                            {
                                test = temp[2];
                            }
                            else
                            {
                                test = null;
                            }
                        }
                        catch
                        {
                            App.Current.MainPage.DisplayAlert($"Erro", $"Não foi possível recuperar as informações do clima de {cityInput}.", "Ok");
                            return;
                        }

                        if (string.IsNullOrEmpty(test))
                        {
                            var response = await service.GetWeatherByCoord(lat, lon);

                            if (response != null)
                            {
                                CityName = cityInput;
                                AssignValues(response);
                            }
                            else
                            {
                                App.Current.MainPage.DisplayAlert($"Erro", $"Não foi possível recuperar as informações do clima de {cityInput}.", "Ok");
                            }
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert($"Erro", $"Mais de 2 coordenadas fornecidas. Digite apenas latitude e longitude.", "Ok");
                        }
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert($"Erro", "Escolha cidade ou coordenada.", "Ok");
                    }
                }
            }
        }
    }
}
