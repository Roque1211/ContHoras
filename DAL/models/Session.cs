using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class Session
    {
        public string Sessid { get; set; }
        public string Sesstoken { get; set; }
        public string Sessuser { get; set; }
        public DateTime? Sesstart { get; set; }
        public DateTime? Sessend { get; set; }

        public virtual User SessuserNavigation { get; set; }
    }
}
