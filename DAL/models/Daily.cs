using System;
using System.Collections.Generic;

namespace DAL.models
{
    public partial class Daily
    {
        public string Dailyid { get; set; }
        public string Dailyuser { get; set; }
        public string Dailytype { get; set; }
        public DateTime? Dailyinout { get; set; }

        public virtual User DailyuserNavigation { get; set; }
    }
}
