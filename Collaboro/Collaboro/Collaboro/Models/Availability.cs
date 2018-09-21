using System;
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
        public bool Mon8a { get; set; }
        public bool Mon9a { get; set; }
        public bool Mon10a { get; set; }
        public bool Mon11a { get; set; }
        public bool Mon12p { get; set; }
        public bool Mon1p { get; set; }
        public bool Mon2p { get; set; }
        public bool Mon3p { get; set; }
        public bool Mon4p { get; set; }
        public bool Mon5p { get; set; }
        public bool Mon6p { get; set; }
        public bool Mon7p { get; set; }
        public bool Mon8p { get; set; }
        public bool Mon9p { get; set; }
        public bool Tue8a { get; set; }
        public bool Tue9a { get; set; }
        public bool Tue10a { get; set; }
        public bool Tue11a { get; set; }
        public bool Tue12p { get; set; }
        public bool Tue1p { get; set; }
        public bool Tue2p { get; set; }
        public bool Tue3p { get; set; }
        public bool Tue4p { get; set; }
        public bool Tue5p { get; set; }
        public bool Tue6p { get; set; }
        public bool Tue7p { get; set; }
        public bool Tue8p { get; set; }
        public bool Tue9p { get; set; }
        public bool Wed8a { get; set; }
        public bool Wed9a { get; set; }
        public bool Wed10a { get; set; }
        public bool Wed11a { get; set; }
        public bool Wed12p { get; set; }
        public bool Wed1p { get; set; }
        public bool Wed2p { get; set; }
        public bool Wed3p { get; set; }
        public bool Wed4p { get; set; }
        public bool Wed5p { get; set; }
        public bool Wed6p { get; set; }
        public bool Wed7p { get; set; }
        public bool Wed8p { get; set; }
        public bool Wed9p { get; set; }
        public bool Thur8a { get; set; }
        public bool Thur9a { get; set; }
        public bool Thur10a { get; set; }
        public bool Thur11a { get; set; }
        public bool Thur12p { get; set; }
        public bool Thur1p { get; set; }
        public bool Thur2p { get; set; }
        public bool Thur3p { get; set; }
        public bool Thur4p { get; set; }
        public bool Thur5p { get; set; }
        public bool Thur6p { get; set; }
        public bool Thur7p { get; set; }
        public bool Thur8p { get; set; }
        public bool Thur9p { get; set; }
        public bool Fri8a { get; set; }
        public bool Fri9a { get; set; }
        public bool Fri10a { get; set; }
        public bool Fri11a { get; set; }
        public bool Fri12p { get; set; }
        public bool Fri1p { get; set; }
        public bool Fri2p { get; set; }
        public bool Fri3p { get; set; }
        public bool Fri4p { get; set; }
        public bool Fri5p { get; set; }
        public bool Fri6p { get; set; }
        public bool Fri7p { get; set; }
        public bool Fri8p { get; set; }
        public bool Fri9p { get; set; }
        public bool Sat8a { get; set; }
        public bool Sat9a { get; set; }
        public bool Sat10a { get; set; }
        public bool Sat11a { get; set; }
        public bool Sat12p { get; set; }
        public bool Sat1p { get; set; }
        public bool Sat2p { get; set; }
        public bool Sat3p { get; set; }
        public bool Sat4p { get; set; }
        public bool Sat5p { get; set; }
        public bool Sat6p { get; set; }
        public bool Sat7p { get; set; }
        public bool Sat8p { get; set; }
        public bool Sat9p { get; set; }
        public bool Sun8a { get; set; }
        public bool Sun9a { get; set; }
        public bool Sun10a { get; set; }
        public bool Sun11a { get; set; }
        public bool Sun12p { get; set; }
        public bool Sun1p { get; set; }
        public bool Sun2p { get; set; }
        public bool Sun3p { get; set; }
        public bool Sun4p { get; set; }
        public bool Sun5p { get; set; }
        public bool Sun6p { get; set; }
        public bool Sun7p { get; set; }
        public bool Sun8p { get; set; }
        public bool Sun9p { get; set; }
    }
}
