using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public abstract class SuccessObjective
    {
        /// <summary>
        /// Unique ID of this objective.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Name of the success objective.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// More detailed information about the success objective.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Link to an external site with more information on the success objective.
        /// </summary>
        public string ExternalLink { get; set; }

        /// <summary>
        /// How strongly this objective pertains to this category.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Classification of success objective.
        /// </summary>
        public SuccessObjectiveClassifier Classifier;

        public SuccessObjective(int ID, string name, string description, string externalLink, int weight,
            SuccessObjectiveClassifier classifier)
        {
            this.ID = ID;
            Name = name;
            Description = description;
            ExternalLink = externalLink;
            Weight = weight;
            Classifier = classifier;
        }
    }
}
