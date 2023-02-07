using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoftde.Models
{
    public class Productos
    {
        public int id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Decimal Costos { get; set; }
        public Boolean Estado { get; set; }
    }
}