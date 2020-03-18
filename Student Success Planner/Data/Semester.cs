using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class Semester
    {
        public string Name { get; set; }

        /// <summary>
        /// Success objectives in this semester.
        /// </summary>
        public List<SuccessObjective> SuccessObjectives { get; set; }

        public Semester() { }

        public Semester(string name)
        {
            Name = name;
        }

        public Semester(string name, ICollection<SuccessObjective> successObjectives)
        {
            Name = name;
            SuccessObjectives = new List<SuccessObjective>(successObjectives);
        }
    }
}
