using System;
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
        public int ID { get; set; }
        public string SubjectCode { get; set; }
        public int NumberMembers { get; set; }
    }
}
