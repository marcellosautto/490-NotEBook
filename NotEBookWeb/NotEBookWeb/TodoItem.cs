using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotEBookWeb
{
    public class TodoItem
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public bool IsDone { get; set; }

    }


}
