using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class DailyDTO
    {
        public Guid dailyId { get; set; }
        public string dailyUser { get; set; }
        public String dailyType { get; set; }
        public string dailyInout { get; set; }
        public string token { get; set; }
    }
}
