using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SchoolYear
    {
        /// <summary>
        /// Which year of school this is. Ex: 1, 2, 3, 4
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Year in school for a student. Example: Freshman
        /// </summary>
        public string StudentClass { get; set; }

        public Semester Fall { get; set; }

        public Semester Spring { get; set; }

        public Semester Summer { get; set; }

        /// <summary>
        /// Array containing all semesters in the school year.
        /// </summary>
        public Semester[] Semesters
        {
            get
            {
                return new Semester[3]
                {
                    Fall, Spring, Summer
                };
            }
        }

        public SchoolYear() { }

        public SchoolYear(int year, string studentClass)
        {
            Year = year;
            StudentClass = studentClass;
        }

        public SchoolYear(int year, string studentClass, Semester fall, Semester spring, Semester summer)
        {
            Year = year;
            StudentClass = studentClass;
            Fall = fall;
            Spring = spring;
            Summer = summer;
        }
    }
}
