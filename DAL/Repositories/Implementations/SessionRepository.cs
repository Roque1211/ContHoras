using Core.Common;
using Core.DTO;
using DAL.models;
using DAL.Repositories.Contracts;
using Newtonsoft.Json;
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
        public string GetRole(string token)
        {
            var miSess = _context.Session.Single(b => b.Sesstoken == token);
            string role = _context.User.Find(miSess.Sessuser).Rol;
            string result = new string ("{ role: " + role + " }");
            string output = JsonConvert.SerializeObject(result);
            return output;
        }

        // chequea que el token es válido
        public bool checkToken(string token)
        {
            var miSess = _context.Session.Single(s => s.Sesstoken == token);

            if (!(miSess.Sessend is null))
            {
                if ((miSess.Sessend.Value - miSess.Sesstart.Value).Minutes > Constants.SESSION_EXPIRED_MINUTES)
                {
                    // la session ha expirado
                    miSess.Sessend = DateTime.Now;
                    _context.Session.Update(miSess);
                    _context.SaveChanges();
                    return false;
                }
                else
                {
                    // session correcta
                    return true;
                }
            }
            else
            {
                // session expirada
                return true;
            }
        }

        public IEnumerable<SessionDTO> GetAll()
        {
            var sessions = _context.Session.ToList();
            List<SessionDTO> sessionsDTO = new List<SessionDTO>();

            foreach (var s in sessions)
            {
                var session = new SessionDTO
                {
                    sessid = new Guid(s.Sessid),
                    sessend = s.Sessend,
                    sesstart = s.Sesstart,
                    sesstoken = s.Sesstoken,
                    sessuser = s.Sessuser,
                };
                sessionsDTO.Add(session);
            }

            return sessionsDTO;
        }

        public SessionDTO Get(string token)
        {
            throw new NotImplementedException();
        }
    }
}