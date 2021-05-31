using BL.Contracts;
using Core.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyController : ControllerBase
    {
        public IDailyBL _dailyBL { get; set; }
        public DailyController(IDailyBL dailyBL)
        {
            _dailyBL = dailyBL;
        }

        // obtiene listado de diarios para usuario admin
        [HttpGet]
        [Route("/api/daily/getall")]
        [SwaggerOperation("getall")]
        [EnableCors("EnableCorsForLocalhost")]
        public IEnumerable<DailyDTO> GetAll()
        {
            return _dailyBL.GetAll();
        }
        // obtiene listado de diarios para usuario normal
        [HttpPost]
        [Route("/api/daily/getalluser")]
        [SwaggerOperation("getalluser")]
        [EnableCors("EnableCorsForLocalhost")]
        public IEnumerable<DailyDTO> GetAllUser([FromBody] UsuarioDTO usuarioDTO)
        {
            return _dailyBL.GetAllUser(usuarioDTO);
        }

        // Add a daily
        [HttpPost]
        [Route("/api/daily/post")]
        [SwaggerOperation("post {daily}")]
        [EnableCors("EnableCorsForLocalhost")]
        public void Post([FromBody] DailyDTO dailyDTO)
        {
            _dailyBL.Add(dailyDTO);
        }


    }
}

