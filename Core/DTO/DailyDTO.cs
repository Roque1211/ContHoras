using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class DailyDTO
    {
        public Guid dailyId { get; set; }
        public Guid dailyUser { get; set; }
        public String dailyType { get; set; }
        public DateTime? dailyInout { get; set; }
    }
}
