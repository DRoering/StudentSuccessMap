using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SchoolYear
    {
        /// <summary>
        /// Year in school for a student. Example: Freshman
        /// </summary>
        public string StudentClass { get; set; }

        public Semester Fall { get; set; }

        public Semester Spring { get; set; }

        public Semester Summer { get; set; }

        public SchoolYear() { }

        public SchoolYear(string studentClass)
        {
            StudentClass = studentClass;
        }

        public SchoolYear(string studentClass, Semester fall, Semester spring, Semester summer)
        {
            StudentClass = studentClass;
            Fall = fall;
            Spring = spring;
            Summer = summer;
        }
    }
}
