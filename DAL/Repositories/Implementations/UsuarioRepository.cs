using Core.DTO;
using DAL.models;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public conthorasContext _context { get; set; }
        public UsuarioRepository(conthorasContext context)
        {
            _context = context;
        }
        // devuelve UsuarioDTO si el login es correcto
        // devuelve null si el login es incorrecto
        public UsuarioInfo Login(UsuarioDTO usuarioDTO)
        {
            var miUser = new User();
            var userinfo = new UsuarioInfo();
            if (_context.User.Any(u => u.Nick == usuarioDTO.nick && u.Pwd == usuarioDTO.pwd)) 
            {
                var query = _context.User.Where(u => u.Nick == usuarioDTO.nick && u.Pwd == usuarioDTO.pwd);
                miUser = query.First<User>();
                userinfo.Id = new Guid(miUser.Id);
                userinfo.Nombre = miUser.Name;
                userinfo.Apellidos = miUser.Mail;
                userinfo.Email = miUser.Mail;
                userinfo.Rol = miUser.Rol;
                return userinfo;
            }
            else
            {
                return null;
            }
        }

        // adds an user
        public void Add(UsuarioDTO usuarioDTO)
        {
            var miUser = new User();
      
            miUser.Id = Guid.NewGuid().ToString();
            miUser.Nick = usuarioDTO.nick;
            miUser.Pwd = usuarioDTO.pwd;
            miUser.Name = usuarioDTO.name;
            miUser.Surname = usuarioDTO.surname;
            miUser.Mail = usuarioDTO.mail;
            miUser.Rol = usuarioDTO.rol;
            miUser.LastLogin = usuarioDTO.lastlogin;
            miUser.FirstLogin = usuarioDTO.firstlogin;

            _context.User.Add(miUser);
            _context.SaveChanges();
        }

        // devuelve la lista de usuarios
        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _context.User.ToList();
            List<UsuarioDTO> usuariosdto = new List<UsuarioDTO>();

            foreach (var u in usuarios)
            {
                var usuario = new UsuarioDTO
                {
                    id = new Guid(u.Id),
                    nick = u.Nick,
                    pwd = u.Pwd,
                    name = u.Name,
                    rol = u.Rol,
                    lastlogin = u.LastLogin,
                    mail = u.Mail,
                    firstlogin = u.FirstLogin,
                };
                usuariosdto.Add(usuario);
            }

            return usuariosdto;

        }

        //devuelve un usuario con un id determinado
        User IUsuarioRepository.Get(string id)
        {
            return _context.User.Find(id);
        }

        // borra un usuario
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}