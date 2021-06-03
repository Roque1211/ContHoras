
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
        void Add(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> GetAll();
        UsuarioDTO Get(UsuarioDTO usuario);
        void Delete(UsuarioDTO usuario);
        void Put(UsuarioDTO usuarioDTO);
    }
}