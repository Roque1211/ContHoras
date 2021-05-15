using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class UsuarioDTO
    {
        public Guid id { get; set; }
        public string nick { get; set; }
        public string pwd { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string mail { get; set; }
        public string rol { get; set; }
        public DateTime? firstlogin { get; set; }
        public DateTime? lastlogin { get; set; }

    }
}