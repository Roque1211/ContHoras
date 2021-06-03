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
        IEnumerable<UsuarioDTO> GetAll();
        UsuarioDTO Get(UsuarioDTO usuarioDTO);
        void Delete(UsuarioDTO usuarioDTO);
        void Put(UsuarioDTO usuarioDTO);
    }
}