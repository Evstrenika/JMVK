﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Collaboro.Models
{
    public class Availability
    {
        [PrimaryKey, Unique]
        public string Email { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Activity { get; set; }    // May be a class
    }
}
