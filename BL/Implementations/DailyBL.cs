using System;
using System.Collections.Generic;
using BL.Contracts;
using Core.DTO;
using DAL.Repositories.Contracts;
using DAL.Repositories.Implementations;

namespace BL.Implementations
{
    public class DailyBL : IDailyBL
    {
        public IDailyRepository _dailyRepository { get; set; }

        public DailyBL(IDailyRepository dailyRepository)
        {
            _dailyRepository = dailyRepository;
        }

        public IEnumerable<DailyDTO> GetAll()
        {
            return _dailyRepository.GetAll();
        }

        public IEnumerable<string> Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(DailyDTO dailyDTO)
        {
            _dailyRepository.Add(dailyDTO);
        }

        public void Update(string value)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DailyDTO> GetAllUser(UsuarioDTO usuarioDTO)
        {
            return _dailyRepository.GetAllUser(usuarioDTO);
        }
    }
}