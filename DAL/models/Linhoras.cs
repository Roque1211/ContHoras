using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class Linhoras
    {
        public int Idlin { get; set; }
        public int Idcab { get; set; }
        public int? Idproject { get; set; }
        public TimeSpan Firsttime { get; set; }
        public TimeSpan Lasttime { get; set; }

        public virtual Cabhoras IdcabNavigation { get; set; }
    }
}
