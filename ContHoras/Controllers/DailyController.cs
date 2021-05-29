using BL.Contracts;
using Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpGet]
        public IEnumerable<DailyDTO> GetAll()
        {
            return _dailyBL.GetAll();
        }

        // GET devuelve un diario con un id determinado
        [HttpGet("{id}")]
        public IEnumerable<string> Get(String id)
        {
            return _dailyBL.Get(id);
        }

        // Add an daily
        [HttpPost]
        public void Post([FromBody] DailyDTO dailyDTO)
        {
            _dailyBL.Add(dailyDTO);
        }

        // Modifica un daily
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _dailyBL.Update(value);

        }

        // Borra un daily con un id determinado
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _dailyBL.Delete(id);
        }
    }
}
