using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SuccessActivity : SuccessObjective
    {
        public SuccessActivity(string ID, string name, string description, string externalLink, int weight,
            SuccessObjectiveClassifier classifier)
            : base(ID, name, description, externalLink, weight, classifier) { }
    }
}
