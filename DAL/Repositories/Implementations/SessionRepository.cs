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


     }
}