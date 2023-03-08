using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoftde.Datas
{
    public class Conexion
    {
       //public static string Rutaconexion = "Server=http://127.0.0.1:1433;Initial Catalog=Prubatienda;User Id=sa;Password=mssql1Ipw;Integrated Security=True; TrustServerCertificate=True;";
        public static string Rutaconexion = "Server=localhost,1433; Database=Prubatienda; User=sa; Password =mssql1Ipw;TrustServerCertificate=True";
    }
}