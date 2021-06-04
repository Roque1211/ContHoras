using Core.DTO;
using System;
using System.Collections.Generic;


namespace BL.Contracts
{
    public interface IDailyBL
    {
        IEnumerable<DailyDTO> GetAll();
        void Add(DailyDTO dailyDTO);
        void Put(DailyDTO dailyDTO);
        void Delete(DailyDTO dailyDTO);
        IEnumerable<DailyDTO> GetAllUser(UsuarioDTO usuarioDTO);
    }
}
