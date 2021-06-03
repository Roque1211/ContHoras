using BL.Contracts;
using Core.DTO;
using DAL.Repositories.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IUsuarioRepository _usuarioRepository { get; set; }
        public UsuarioBL(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // login
        public UsuarioInfo Login(UsuarioDTO usuarioDTO)
        {
            return(_usuarioRepository.Login(usuarioDTO));
        }

        // add user
        public void Add(UsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Add(usuarioDTO);
        }

        // devuelve listado de usuarios
        public IEnumerable<UsuarioDTO> GetAll()
        {
            return _usuarioRepository.GetAll();
  
        }

        // devuelve usuario con un id determinado
        UsuarioDTO IUsuarioBL.Get(UsuarioDTO usuarioDTO)
        {
            return _usuarioRepository.Get(usuarioDTO);
        }

        // borrar usuario
        public void Delete(UsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Delete(usuarioDTO);
        }

        public void Put(UsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Put(usuarioDTO);
        }
    }
}