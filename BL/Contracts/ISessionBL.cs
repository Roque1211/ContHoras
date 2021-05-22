using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface ISessionBL
    {
        bool CheckToken { get; set; }

        void Add(SessionDTO sessionDTO);
        void StartSession(string token, Guid id);
        void CheckRole(String token);
        String GetRole(string token);
    }
}
