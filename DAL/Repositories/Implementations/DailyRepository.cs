using Core.Common;
using Core.DTO;
using DAL.models;
using DAL.Repositories.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class DailyRepository : IDailyRepository
    {
        public conthorasContext _context { get; set; }
        public DailyRepository(conthorasContext context)
        {
            _context = context;
        }
        public IEnumerable<DailyDTO> GetAll()
        {
            var dailys = _context.Daily.ToList();
            List<DailyDTO> dailysDTO = new List<DailyDTO>();

            foreach (var d in dailys)
            {
                var daily = new DailyDTO
                {
                    dailyId = new Guid(d.Dailyid),
                    dailyInout = d.Dailyinout,
                    dailyType = d.Dailytype,
                    dailyUser = new Guid(d.Dailyuser)
                };
                dailysDTO.Add(daily);
            }

            return dailysDTO;
        }

        public void Add(DailyDTO dailyDTO)
        {
            var miDaily = new Daily();

            miDaily.Dailyid = Guid.NewGuid().ToString();
            miDaily.Dailyinout = dailyDTO.dailyInout;
            miDaily.Dailytype = dailyDTO.dailyType;
            miDaily.Dailyuser = dailyDTO.dailyUser.ToString();

            _context.Daily.Add(miDaily);
            _context.SaveChanges();
        }
    }
}