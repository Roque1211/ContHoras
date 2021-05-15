using BL.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // usuario BL
        public IUsuarioBL _usuarioBL { get; set; }
        public UserController( IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }
        // Devuelve todos los usuarios
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _usuarioBL.Get();
        }

        // GET devuelve un usuario con un id determinado
        [HttpGet("{id}")]
        public string Get(String id)
        {
            return _usuarioBL.Get(id);
        }

        // Add an user
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _usuarioBL.Add(value);
        }

        // Modifica un usuario
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // Borra un usuario con un id determinado
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _usuarioBL.Delete(id);
        }
    }
}
