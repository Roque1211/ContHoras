using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;
using DAL.models;

namespace DAL.Repositories.Contracts
{
    public interface IProjectRepository
    {
        void Add(ProjectDTO ProjectDTO);
        IEnumerable<ProjectDTO> GetAll();
        ProjectDTO Get(ProjectDTO ProjectDTO);
        void Delete(ProjectDTO ProjectDTO);
        void Put(ProjectDTO ProjectDTO);
    }
}