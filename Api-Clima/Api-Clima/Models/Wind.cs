using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_clima.Models
{
    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }
}