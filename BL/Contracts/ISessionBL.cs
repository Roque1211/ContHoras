using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts
{
    public interface ISessionBL
    {
       
        void Add(SessionDTO sessionDTO);
        void StartSession(string token, string id);
        UsuarioDTO GetRole(string token);
        IEnumerable<SessionDTO> GetAll();
        SessionDTO Get(string token);
        bool CheckRole(string token);
        bool CheckToken(String token);
    }
}
