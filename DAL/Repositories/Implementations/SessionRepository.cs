using Core.Common;
using Core.DTO;
using DAL.models;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class SessionRepository : ISessionRepository
    {
        public conthorasContext _context { get; set; }
        public SessionRepository(conthorasContext context)
        {
            _context = context;
        }
        

        // adds a Session
        public void Add(SessionDTO sessionDTO)
        {
            Session miSes = new Session();
            miSes.Sessid = sessionDTO.sessid.ToString();
            miSes.Sesstart = sessionDTO.sesstart;
            miSes.Sesstoken = sessionDTO.sesstoken;
            miSes.Sessuser = sessionDTO.sessuser;
            miSes.Sessend = sessionDTO.sessend;

            _context.Session.Add(miSes);
            _context.SaveChanges();
        }

        // devuelve el rol del usuario de la session actual
        public string GetRole(String token)
        {
            var miSess = _context.Session.Where(b => b.Sesstoken == token).ElementAt(0);
            return _context.User.Find(miSess.Sessuser).Rol;
        }

        // chequea que el token es válido
        public bool checkToken(string token)
        {
            var miSess = _context.Session.Where(b => b.Sesstoken == token).ElementAt(0);
            if  (miSess.Sesstoken == token && miSess.Sessend == null && (miSess.Sessend.Value.Minute - miSess.Sesstart.Value.Minute) <  Constants.SESSION_EXPIRED_MINUTES)
            {
                // session correcta

                return true;
            } else
            {
                // session expirada
                miSess.Sessend = DateTime.Now;
                _context.Session.Update(miSess);
                _context.SaveChanges();
                return false;
            }
        }

        public IEnumerable<string> GetAll()
        {
            throw new NotImplementedException();
        }

        public SessionDTO Get(string token)
        {
            throw new NotImplementedException();
        }
    }
}