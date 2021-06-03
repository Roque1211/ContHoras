using BL.Contracts;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
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
        public IUsuarioBL _usuarioBL { get; set; }
        public UserController( IUsuarioBL usuarioBL)
        {
            _usuarioBL = usuarioBL;
        }
        // Devuelve datos de todos los usuarios
        [HttpGet]
        [Route("/api/user/getall")]
        public IEnumerable<UsuarioDTO> GetAll()
        {
            return _usuarioBL.GetAll();
        }

        // GET devuelve un usuario con un id determinado
        [HttpGet]
        [Route("/api/user/get")]
        public UsuarioDTO Get(UsuarioDTO usuarioDTO)
        {
            return _usuarioBL.Get(usuarioDTO);
        }

        // Add an user
        [HttpPut]
        [Route("/api/user/post")]

        public void Add([FromBody] UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Add(usuarioDTO);
        }

        // Modifica un usuario
        [HttpPut]
        [Route("/api/user/put")]
        [SwaggerOperation("/user/put")]
        public void Put([FromBody] UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Put(usuarioDTO);
        }

        // Borra un usuario con un id determinado
        [HttpPut]
        [Route("/api/user/delete")]
        public void Delete([FromBody] UsuarioDTO usuarioDTO)
        {
            _usuarioBL.Delete(usuarioDTO);
        }
    }
}
