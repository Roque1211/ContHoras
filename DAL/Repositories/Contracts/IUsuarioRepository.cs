using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;
using DAL.models;

namespace DAL.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        UsuarioInfo Login(UsuarioDTO usuarioDTO);
        void Add(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> Get();
        User Get(string id);
        void Delete(string id);
    }
}