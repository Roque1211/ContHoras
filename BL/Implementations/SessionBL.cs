using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using BL.Contracts;
using Core.DTO;
using DAL.Repositories.Contracts;
using DAL.Repositories.Implementations;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BL.Implementations
{
    public class SessionBL:ISessionBL
    {
        public ISessionRepository _sessionRepository { get; set; }
 
        public SessionBL(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        // check if a token exists and is valid
        public bool CheckToken(String token)
        {
            return _sessionRepository.checkToken(token);
         }

        // adds a session
        public void Add(SessionDTO sessionDTO)
        {
            _sessionRepository.Add(sessionDTO);
        }
        // comienza una sessioin
        public void StartSession(string token, Guid id)
        {
            // inicia la sesión
            {
                var curSession = new SessionDTO();

                curSession.sessid = new Guid();
                curSession.sesstoken = token;
                curSession.sesstart = DateTime.Now;
                curSession.sessend = null;
                _sessionRepository.Add(curSession);
            }
        }

        // devuelve role del usuario con un token determinado
        public String GetRole(string token)
        {
           return _sessionRepository.GetRole(token);
        }

        // devuelve todas las sesiones
        public IEnumerable<string> GetAll()
        {
            return _sessionRepository.GetAll();
        }

        // devuelve la session actual
        public SessionDTO Get(string token)
        {
            return _sessionRepository.Get(token);
        }

        public bool CheckRole(string token)
        {
            throw new NotImplementedException();
        }
    }

}
