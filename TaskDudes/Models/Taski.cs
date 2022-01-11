using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDudes.Models
{
    public class Taski
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }

        public string TaskDescriptíon { get; set; }

        public DateTime Date { get; set; }

        public bool TaskIsDone { get; set; }

        public bool Repeating { get; set; }

        public DayOfWeek RepeatTime { get; set; }

        public User User { get; set; }
    }
}
