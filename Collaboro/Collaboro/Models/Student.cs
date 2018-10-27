using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collaboro.Models
{
    public class Student
    {
        [PrimaryKey, Unique]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string University { get; set; }
        public string Password { get; set; }
        //public string Salt { get; set; }          // Future release content
        //public int Rating { get; set; }
    }
}
