using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class User
    {
        public User()
        {
            Cabhoras = new HashSet<Cabhoras>();
            UserProject = new HashSet<UserProject>();
        }

        public string Id { get; set; }
        public string Nick { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Rol { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? FirstLogin { get; set; }

        public virtual ICollection<Cabhoras> Cabhoras { get; set; }
        public virtual ICollection<UserProject> UserProject { get; set; }
    }
}
