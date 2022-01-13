﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskDudes.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public decimal Weight { get; set; }

        public List<Taski> Tasks { get; set; } = new List<Taski>();

        public Settings Settings { get; set; } = new Settings();
    }
}
