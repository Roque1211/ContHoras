using BL.Contracts;
using Core.DTO;
using DAL.Repositories.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        public void Add(string value)
        {
            UsuarioDTO usuarioDTO =  JsonConvert.DeserializeObject<UsuarioDTO>(value);
            _usuarioRepository.Add(usuarioDTO);
        }

        // devuelve listado de usuarios
        public IEnumerable<String> Get()
        {
            var usuarios = _usuarioRepository.Get();
            var strList = new List<String>();

            foreach (UsuarioDTO u in  usuarios )
            {
                strList.Add(JsonConvert.SerializeObject(u));
            }
            return strList;
        }

        // devuelve usuario con un id determinado
        string IUsuarioBL.Get(string id)
        {
            return JsonConvert.SerializeObject(_usuarioRepository.Get(id));
        }

        // borrar usuario
        public void Delete(string id)
        {
            _usuarioRepository.Delete(id);
        }
    }
}