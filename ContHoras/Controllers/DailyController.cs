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

        // obtiene listado de diarios
        [HttpGet]
        [Route("/api/daily/getall")]
        [SwaggerOperation("get {daily}")]
        [EnableCors("EnableCorsForLocalhost")]
        public IEnumerable<DailyDTO> GetAll()
        {
            return _dailyBL.GetAll();
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

        // Modifica un daily
        /*
        [HttpPut("{daily}")]
        [Route("/api/daily/put")]
        [SwaggerOperation("put {daily}")]
        [EnableCors("EnableCorsForLocalhost")]
        public void Put(int id, [FromBody] string value)
        {
            _dailyBL.Update(value);

        }

        // Borra un daily con un id determinado
        [HttpDelete("{id}")]
        [Route("/api/daily/delete")]
        [SwaggerOperation("delete {daily}")]
        [EnableCors("EnableCorsForLocalhost")]
        public void Delete(string id)
        {
            _dailyBL.Delete(id);
        }
        */
    }
}
