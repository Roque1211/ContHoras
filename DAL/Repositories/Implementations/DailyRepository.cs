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

                string tipo = "";
                var miUser = _context.User.Find(d.Dailyuser);
                if (d.Dailytype == "E")
                {
                    tipo = "Entrada";
                } else
                {
                    tipo = "Salida";
                }

                var daily = new DailyDTO
                {
                    dailyId = new Guid(d.Dailyid),
                    dailyInout = d.Dailyinout.ToString(),
                    dailyType = tipo,
                    dailyUser = miUser.Name + " " + miUser.Surname
                };
                dailysDTO.Add(daily);
            }

            return dailysDTO;
        }

        public void Add(DailyDTO dailyDTO)
        {
            var query = _context.Session.Where(s => s.Sesstoken == dailyDTO.token);
            Session miSes = query.First<Session>();

            var miDaily = new Daily();

            miDaily.Dailyid = Guid.NewGuid().ToString();
            //miDaily.Dailyinout = dailyDTO.dailyInout;
            miDaily.Dailyinout = DateTime.Now;
            miDaily.Dailytype = dailyDTO.dailyType.ElementAt(0).ToString();
            miDaily.Dailyuser = miSes.Sessuser.ToString();

            _context.Daily.Add(miDaily);
            _context.SaveChanges();
        }

        public IEnumerable<DailyDTO> GetAllUser(UsuarioDTO usuarioDTO)
        {
            var dailys = _context.Daily.Where(d => d.Dailyuser == usuarioDTO.id.ToString()).ToList();
            List<DailyDTO> dailysDTO = new List<DailyDTO>();

            foreach (var d in dailys)
            {

                string tipo = "";
                var miUser = _context.User.Find(d.Dailyuser);
                if (d.Dailytype == "E")
                {
                    tipo = "Entrada";
                }
                else
                {
                    tipo = "Salida";
                }

                var daily = new DailyDTO
                {
                    dailyId = new Guid(d.Dailyid),
                    dailyInout = d.Dailyinout.ToString(),
                    dailyType = tipo,
                    dailyUser = miUser.Name + " " + miUser.Surname
                };
                dailysDTO.Add(daily);
            }

            return dailysDTO;
        }
    }
}