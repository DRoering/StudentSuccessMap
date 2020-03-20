using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class Semester
    {
        public string Name { get; set; }

        public SchoolYear SchoolYear { get; set; }

        public Semester() { }

        public Semester(string name)
        {
            Name = name;
        }

        public Semester(string name, SchoolYear schoolYear)
        {
            Name = name;
            SchoolYear = schoolYear;
        }
    }
}
