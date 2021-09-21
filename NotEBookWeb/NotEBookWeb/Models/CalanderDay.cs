using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotEBookWeb.Models
{
    public class CalanderDay
    {
        public int DayNum { get; set; }
        public DateTime Date { get; set; }
        public bool isEmpty { get; set; }

        public List<TodoItem> Events { get; set; }


    }
}
