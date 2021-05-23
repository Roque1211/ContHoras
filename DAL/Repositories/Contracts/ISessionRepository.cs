using Core.DTO;
using System;
using System.Collections.Generic;

namespace DAL.Repositories.Contracts
{

    public interface ISessionRepository
    {
        void Add(SessionDTO curSession);
        String GetRole(String token);
        bool checkToken(string token);
        IEnumerable<string> GetAll();
        SessionDTO Get(string token);
    }

}
