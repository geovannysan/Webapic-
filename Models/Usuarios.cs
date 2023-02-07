using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoftde.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fechacreacion { get; set; }
        public Boolean Estado { get; set; }

    }
}