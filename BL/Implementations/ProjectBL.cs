using BL.Contracts;
using Core.DTO;
using DAL.Repositories.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Implementations
{
    public class ProjectBL : IProjectBL
    {
        public IProjectRepository _projectRepository { get; set; }
        public ProjectBL(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

       
        // add project
        public void Add(ProjectDTO projectDTO)
        {
            _projectRepository.Add(projectDTO);
        }

        // devuelve listado de projects
        public IEnumerable<ProjectDTO> GetAll()
        {
            return _projectRepository.GetAll();
  
        }

        // devuelve project con un id determinado
        ProjectDTO IProjectBL.Get(ProjectDTO projectDTO)
        {
            return _projectRepository.Get(projectDTO);
        }

        // borrar project
        public void Delete(ProjectDTO projectDTO)
        {
            _projectRepository.Delete(projectDTO);
        }

        public void Put(ProjectDTO projectDTO)
        {
            _projectRepository.Put(projectDTO);
        }
    }
}