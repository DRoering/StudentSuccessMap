using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    /// <summary>
    /// Describes a classification of this classifier.
    /// </summary>
    public class SuccessObjectiveClassifier
    {
        /// <summary>
        /// Unique ID of this semester.
        /// </summary>
        public int ID { get; set; }

        public string Classifier { get; set; } = defaultClassifier;

        public static string defaultClassifier = "none";

        public SuccessObjectiveClassifier() { }

        public SuccessObjectiveClassifier(int ID, string classifier)
        {
            this.ID = ID;
            Classifier = classifier;
        }
    }
}
