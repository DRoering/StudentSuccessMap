using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SuccessMap
    {
        /// <summary>
        /// Categories of success objectives.
        /// </summary>
        public SuccessCategory[] SuccessCategories { get; set; }

        public SuccessMap() { }

        public SuccessMap(SuccessCategory[] successCategories)
        {
            SuccessCategories = successCategories;
        }
    }
}
