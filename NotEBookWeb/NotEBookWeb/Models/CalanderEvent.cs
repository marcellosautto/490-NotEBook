using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotEBookWeb.Models
{
    public class CalanderEvent
    {
        public string Subject { get; set; }
        public DateTime DateEvent { get; set; }

        public DateTime DateEventTime { get; set; }
    }
}
