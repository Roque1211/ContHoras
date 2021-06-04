using Core.DTO;
using System;
using System.Collections.Generic;

namespace DAL.Repositories.Contracts
{

    public interface IDailyRepository
    {
        IEnumerable<DailyDTO> GetAll();
        void Add(DailyDTO dailyDTO);
        IEnumerable<DailyDTO> GetAllUser(UsuarioDTO usuarioDTO);
        void Put(DailyDTO dailyDTO);
        void Delete(DailyDTO dailyDTO);
    }

}
