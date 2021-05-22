using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Text;
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
        public bool CheckToken { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SessionBL(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public void Add(SessionDTO sessionDTO)
        {
            throw new NotImplementedException();
        }

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

        public String GetRole(string token)
        {
            // devuelve role del usuario
           return _sessionRepository.GetRole();
        }

        public void CheckRole(string token)
        {
            throw new NotImplementedException();
        }

    }

}
