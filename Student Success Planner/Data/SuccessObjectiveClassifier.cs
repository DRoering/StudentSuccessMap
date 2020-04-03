using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    /// <summary>
    /// Describes a classification of success objective.
    /// </summary>
    public class SuccessObjectiveClassifier
    {
        public string Classifier { get; set; } = defaultClassifier;

        public static string defaultClassifier = "none";

        public SuccessObjectiveClassifier() { }

        public SuccessObjectiveClassifier(string classifier)
        {
            Classifier = classifier;
        }
    }
}
