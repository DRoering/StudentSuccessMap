using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class Course : SuccessObjective
    {
        /// <summary>
        /// ID for the course. Example: SE 221
        /// </summary>
        public string CourseID { get; set; }

        /// <summary>
        /// Type of the course.
        /// </summary>
        public CourseType Type { get; set; }

        public Course(string name, string description, string externalLink, int weight,
            SuccessObjectiveClassifier classifier, string courseID, CourseType type)
            : base(name, description, externalLink, weight, classifier)
        {
            CourseID = courseID;
            Type = type;
        }
    }

    /// <summary>
    /// Type of a course.
    /// </summary>
    public enum CourseType
    {
        GoalArea,
        ProgramCore,
        Elective
    }
}
