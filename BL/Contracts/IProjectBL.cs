
using BL.Implementations;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{

    public interface IProjectBL
    {
        void Add(ProjectDTO ProjectDTO);
        IEnumerable<ProjectDTO> GetAll();
        ProjectDTO Get(ProjectDTO Project);
        void Delete(ProjectDTO Project);
        void Put(ProjectDTO ProjectDTO);
    }
}