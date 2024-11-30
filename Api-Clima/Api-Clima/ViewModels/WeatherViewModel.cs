using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Clima.ViewModels
{
    public class WeatherViewModel
    {
        [ObservableProperty]
        private string cityName;

        [ObservableProperty]
        private int temp;

        [ObservableProperty]
        private string image;

        [ObservableProperty]
        private string geral; //"poucas nuvens" nao sei como vou fazer essa bomba

        [ObservableProperty]
        private int min;
        [ObservableProperty]  //min/max sensação de feelsLike
        private int max;
        [ObservableProperty]
        private int feelsLike;

        [ObservableProperty]
        private float sunrise;
        [ObservableProperty]
        private float sunset;

        [ObservableProperty]
        private int humidade;

        [ObservableProperty]
        private float vento;

        [ObservableProperty]
        private float visibilidade;

        [ObservableProperty]
        private int pressao;

    }
}
