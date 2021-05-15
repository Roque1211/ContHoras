using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class Cabhoras
    {
        public Cabhoras()
        {
            Linhoras = new HashSet<Linhoras>();
        }

        public int Id { get; set; }
        public string Iduser { get; set; }
        public DateTime? Datecab { get; set; }

        public virtual User IduserNavigation { get; set; }
        public virtual ICollection<Linhoras> Linhoras { get; set; }
    }
}
