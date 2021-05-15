
using BL.Implementations;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{

    public interface IUsuarioBL
    {
        UsuarioInfo Login(UsuarioDTO usuarioDTO);
        void Add(string usuarioDTO);
        IEnumerable<String> Get();
        string Get(string id);
        void Delete(string id);
    }
}