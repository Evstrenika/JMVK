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
        [PrimaryKey]
        public int GroupID { get; set; }
        [PrimaryKey]
        public string MemberEmail { get; set; }
        public bool Confirmed { get; set; }
    }
}
