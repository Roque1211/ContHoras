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



        public void Add(DailyDTO dailyDTO)
        {
            _dailyRepository.Add(dailyDTO);
        }

        public void Put(DailyDTO dailyDTO)
        {
            _dailyRepository.Put(dailyDTO);
        }

        public void Delete(DailyDTO dailyDTO)
        {
            _dailyRepository.Delete(dailyDTO);
        }

        public IEnumerable<DailyDTO> GetAllUser(UsuarioDTO usuarioDTO)
        {
            return _dailyRepository.GetAllUser(usuarioDTO);
        }


    }
}