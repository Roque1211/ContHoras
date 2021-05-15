using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class Project
    {
        public Project()
        {
            UserProject = new HashSet<UserProject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserProject> UserProject { get; set; }
    }
}
