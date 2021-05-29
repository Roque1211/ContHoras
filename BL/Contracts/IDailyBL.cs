using Core.DTO;
using System;
using System.Collections.Generic;


namespace BL.Contracts
{
    public interface IDailyBL
    {
        IEnumerable<DailyDTO> GetAll();
        IEnumerable<string> Get(string id);

        void Add(DailyDTO dailyDTO);
        void Update(string value);
        void Delete(string id);
    }
}
