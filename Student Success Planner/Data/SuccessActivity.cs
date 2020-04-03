using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SuccessActivity : SuccessObjective
    {
        public SuccessActivity(string name, string description, string externalLink, int weight,
            SuccessObjectiveClassifier classifier)
            : base(name, description, externalLink, weight, classifier) { }
    }
}
