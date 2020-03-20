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

        public SuccessCategory() { }

        public SuccessCategory(string name)
        {
            Name = name;
        }
    }
}
