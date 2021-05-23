﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Contracts;
using Core.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public ISessionBL _sessionBL { get; set; }
        public SessionController(ISessionBL sessionBL)
        {
            _sessionBL = sessionBL;
        }

        // Devuelve todas las sessions
        [HttpGet]
        [Route("/api/session/getall")]

        public IEnumerable<string> GetAll()
        {
            return _sessionBL.GetAll();
        }

        // GET devuelve una session con un token determinado
        [HttpGet("get/{token}")]
        [SwaggerOperation("get/{token}")]
        public SessionDTO Get(String token)
        {
            return _sessionBL.Get(token);
        }
        // GET devuelve el rol del usuario con la session abierta que corresponde al token enviado
        [HttpGet("getrole/{token}")]
        [SwaggerOperation("getrole/{token}")]
        public async Task<IActionResult> GetRole(String token)
        {
            if (_sessionBL.CheckRole(token))
            {
                return Ok(_sessionBL.GetRole(token));
            }
            else
            {
                return Unauthorized();
            }
        }
        // Modifica una session
        [HttpPut("{token}")]
        public void Put(string session)
        {
        }
        

    }
}