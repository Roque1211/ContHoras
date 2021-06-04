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
            if (_context.User.Any(u => u.Mail == usuarioDTO.mail && u.Pwd == usuarioDTO.pwd)) 
            {
                var query = _context.User.Where(u => u.Mail == usuarioDTO.mail && u.Pwd == usuarioDTO.pwd);
                miUser = query.First<User>();
                userinfo.Id = new Guid(miUser.Id);
                userinfo.Nombre = miUser.Name;
                userinfo.Apellidos = miUser.Surname;
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
            if (usuarioDTO.lastlogin != "") { miUser.LastLogin = DateTime.Parse(usuarioDTO.lastlogin);} else { miUser.LastLogin = null; };
            if (usuarioDTO.firstlogin != "") { miUser.FirstLogin = DateTime.Parse(usuarioDTO.firstlogin); } else { miUser.FirstLogin = null; };

            _context.User.Add(miUser);
            _context.SaveChanges();
        }

        // devuelve la lista de usuarios
        public IEnumerable<UsuarioDTO> GetAll()
        {
            var usuarios = _context.User.ToList();
            List<UsuarioDTO> usuariosdto = new List<UsuarioDTO>();

            foreach (var u in usuarios)
            {
                var usuario = new UsuarioDTO
                {
                    id = u.Id,
                    nick = u.Nick,
                    pwd = u.Pwd,
                    name = u.Name,
                    surname = u.Surname,
                    rol = u.Rol,
                    lastlogin = u.LastLogin.ToString(),
                    mail = u.Mail,
                    firstlogin = u.FirstLogin.ToString(),
                };
                usuariosdto.Add(usuario);
            }

            return usuariosdto;

        }

        //devuelve un usuario con un id determinado
        public UsuarioDTO Get(UsuarioDTO usuarioDTO)
        {
            User miUser = _context.User.Find(usuarioDTO.id.ToString());
            UsuarioDTO result = new UsuarioDTO();

            result.id = miUser.Id;
            result.nick = miUser.Nick;
            result.pwd = miUser.Pwd;
            result.name = miUser.Name;
            result.surname = miUser.Surname;
            result.mail = miUser.Mail;
            result.rol = miUser.Rol;
            result.lastlogin = miUser.LastLogin.ToString();
            result.firstlogin = miUser.FirstLogin.ToString();
            return result;
        }

        // borra un usuario
        public void Delete(UsuarioDTO usuarioDTO)
        {
            User miUser = new User();

            miUser.Id = usuarioDTO.id.ToString();
            miUser.Nick = usuarioDTO.nick;
            miUser.Pwd = usuarioDTO.pwd;
            miUser.Name = usuarioDTO.name;
            miUser.Surname = usuarioDTO.surname;
            miUser.Mail = usuarioDTO.mail;
            miUser.Rol = usuarioDTO.rol;
            if (usuarioDTO.lastlogin != "") { miUser.LastLogin = DateTime.Parse(usuarioDTO.lastlogin); } else { miUser.LastLogin = null; };
            if (usuarioDTO.firstlogin != "") { miUser.FirstLogin = DateTime.Parse(usuarioDTO.firstlogin); } else { miUser.FirstLogin = null; };

            _context.User.Remove(miUser);
            _context.SaveChanges();
        }

        public void Put(UsuarioDTO usuarioDTO)
        {
            User miUser = new User();

            miUser.Id = usuarioDTO.id.ToString();
            miUser.Nick = usuarioDTO.nick;
            miUser.Pwd = usuarioDTO.pwd;
            miUser.Name = usuarioDTO.name;
            miUser.Surname = usuarioDTO.surname;
            miUser.Mail = usuarioDTO.mail;
            miUser.Rol = usuarioDTO.rol;
            if (usuarioDTO.lastlogin != "") { miUser.LastLogin = DateTime.Parse(usuarioDTO.lastlogin); } else { miUser.LastLogin = null; };
            if (usuarioDTO.firstlogin != "") { miUser.FirstLogin = DateTime.Parse(usuarioDTO.firstlogin); } else { miUser.FirstLogin = null; };
            _context.User.Update(miUser);
            _context.SaveChanges();
        }
    }
}