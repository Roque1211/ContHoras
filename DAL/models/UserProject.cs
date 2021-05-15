using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class UserProject
    {
        public string Iduser { get; set; }
        public int Idproject { get; set; }

        public virtual Project IdprojectNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }
    }
}
