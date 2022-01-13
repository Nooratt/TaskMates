using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDudes.Models
{
    public class Taski
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public DateTime Date { get; set; }

        public bool TaskIsDone { get; set; }

        public bool Repeating { get; set; }

        public DayOfWeek RepeatTime { get; set; }

        public User User { get; set; }
    }
}
