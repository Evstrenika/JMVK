﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Collaboro.Models
{
    public class Group
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int ID { get; set; }    // this is the PK for Group
        public string SubjectCode { get; set; }
        public int NumberMembers { get; set; }  // the max number of members possible for this group
    }
}
