using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Collaboro.Models
{
    public class Member
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int MemberID { get; set; }   
        public int GroupID { get; set; }            // FK from Group
        public string MemberEmail { get; set; }     // FK from Student
        public bool Confirmed { get; set; }         // Requestee Response
        public bool Displayed { get; set; }         // Requester Notified
    }
}
