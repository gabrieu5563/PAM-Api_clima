using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace api_clima.Models
{
    public class WeatherResponse
    {
        public Coord coord;
        public List<Weather> weather;
        public string Base;
        public Main main;
        public int visibility;
        public Wind wind;
        public Clouds clouds;
        public int dt;
        public Sys sys;
        public int timezone;
        public int id;
        public string name;
        public int cod;
    }
}