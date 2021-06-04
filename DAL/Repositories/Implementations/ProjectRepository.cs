using Core.DTO;
using DAL.models;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        public conthorasContext _context { get; set; }
        public ProjectRepository(conthorasContext context)
        {
            _context = context;
        }
        // devuelve ProjectDTO si el login es correcto
        // devuelve null si el login es incorrecto
       
        // adds a project
        public void Add(ProjectDTO ProjectDTO)
        {
            var miProject = new Project();
      
            miProject.Name = ProjectDTO.name;

            _context.Project.Add(miProject);
            _context.SaveChanges();
        }

        // devuelve la lista de Projects
        public IEnumerable<ProjectDTO> GetAll()
        {
            var Projects = _context.Project.ToList();
            List<ProjectDTO> Projectsdto = new List<ProjectDTO>();

            foreach (var p in Projects)
            {
                var Project = new ProjectDTO
                {
                    id = p.Id.ToString(),
                    name = p.Name,
                };
                Projectsdto.Add(Project);
            }
            return Projectsdto;

        }

        //devuelve un Project con un id determinado
        public ProjectDTO Get(ProjectDTO ProjectDTO)
        {
            Project miProject = _context.Project.Find(Int32.Parse(ProjectDTO.id));
            ProjectDTO result = new ProjectDTO();

            result.id = miProject.Id.ToString();
            result.name = miProject.Name;
            return result;
        }

        // borra un Project
        public void Delete(ProjectDTO ProjectDTO)
        {
            Project miProject = new Project();

            miProject.Id = Int32.Parse(ProjectDTO.id);
            miProject.Name = ProjectDTO.name;
  
            _context.Project.Remove(miProject);
            _context.SaveChanges();
        }

        public void Put(ProjectDTO ProjectDTO)
        {
            Project miProject = new Project();

            miProject.Id = Int32.Parse(ProjectDTO.id);
            miProject.Name = ProjectDTO.name;

            _context.Project.Update(miProject);
            _context.SaveChanges();
        }
    }
}