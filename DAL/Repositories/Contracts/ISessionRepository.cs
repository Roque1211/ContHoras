using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Contracts
{

    public interface ISessionRepository
    {
        void Add(SessionDTO curSession);
        String GetRole();
    }

}
