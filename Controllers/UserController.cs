using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoftde.Datas;
using Microsoftde.Models;

namespace Microsoftde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public List<Usuarios> Get()
        {
            return UserConexion.ListarUser();
        }
        [HttpGet("{id}")]
        public Usuarios Get(int id)
        {
            return UserConexion.Obtener(id);
        }
        [HttpPost]
        public string Post([FromBody] Usuarios usuarios)
        {
            return UserConexion.GuardarUser(usuarios);
        }
        [HttpPut]
        public bool Put([FromBody] Usuarios usuarios)
        {
            return UserConexion.Actualizaruser(usuarios);
        }
        /*[HttpDelete]
        public bool Delete(int id){

            return UserConexion.Actualizaruser
        }*/
    }
}