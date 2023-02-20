using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Microsoftde.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha { get; set; }
        public int dni { get; set; }
        public string domicilio { get; set; }
        public string email { get; set; }
        public string passwrd { get; set; }

        public string permiso { get; set; }
    }
}