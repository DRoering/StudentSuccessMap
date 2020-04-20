using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class Semester
    {
        /// <summary>
        /// Unique ID of this semester.
        /// </summary>
        public int ID { get; set; }

        public string Name { get; set; }

        public SchoolYear SchoolYear { get; set; }

        public Semester() { }

        public Semester(int ID, string name)
        {
            this.ID = ID;
            Name = name;
        }

        public Semester(int ID, string name, SchoolYear schoolYear)
        {
            this.ID = ID;
            Name = name;
            SchoolYear = schoolYear;
        }
    }
}
