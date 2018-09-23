using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Collaboro.Models
{
    public class Meeting
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int MeetingID { get; set; }
        public int GroupID { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
    }
}
