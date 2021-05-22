using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class SessionDTO
    {
        public Guid sessid { get; set; }
        public String sesstoken { get; set; }
        public String sessuser { get; set; }
        public DateTime sesstart { get; set; }
        public DateTime? sessend { get; set; }
    }
}
