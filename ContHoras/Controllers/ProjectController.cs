using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;
using BL.Contracts;
using Core.DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public IProjectBL _projectBL { get; set; }
        public ProjectController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // Devuelve datos de todos los proyectos
        [HttpGet, Route("/api/project/getall")]
        [SwaggerOperation("getall")]

        public IEnumerable<ProjectDTO> Get()
        {
            return _projectBL.GetAll();
        }

        // GET devuelve un Project con un id determinado
        [HttpGet]
        [Route("/api/project/get")]
        public ProjectDTO Get(ProjectDTO ProjectDTO)
        {
            return _projectBL.Get(ProjectDTO);
        }

        // Add an project
        [HttpPut]
        [Route("/api/project/post")]

        public void Add([FromBody] ProjectDTO ProjectDTO)
        {
            _projectBL.Add(ProjectDTO);
        }

        // Modifica un Project
        [HttpPut]
        [Route("/api/project/put")]
        [SwaggerOperation("/project/put")]
        public void Put([FromBody] ProjectDTO ProjectDTO)
        {
            _projectBL.Put(ProjectDTO);
        }

        // Borra un Project con un id determinado
        [HttpPut]
        [Route("/api/project/delete")]
        public void Delete([FromBody] ProjectDTO ProjectDTO)
        {
            _projectBL.Delete(ProjectDTO);
        }
    }
}
