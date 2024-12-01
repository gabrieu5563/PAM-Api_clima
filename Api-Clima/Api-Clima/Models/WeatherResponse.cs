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
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string Base { get; set; }
        public Main main { get; set; } // Corrigido para garantir a deserialização correta
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

}