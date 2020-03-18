using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SuccessCategory
    {
        /// <summary>
        /// Name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// School years containing success objectives for this category.
        /// </summary>
        public SchoolYear[] SchoolYears { get; set; }

        public SuccessCategory() { }

        public SuccessCategory(string name)
        {
            Name = name;
        }

        public SuccessCategory(string name, SchoolYear[] schoolYears)
        {
            Name = name;
            SchoolYears = schoolYears;
        }
    }
}
