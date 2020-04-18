using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SuccessCategory
    {
        /// <summary>
        /// Unique ID of this success category.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Name of the category.
        /// </summary>
        public string Name { get; set; }

        public SuccessCategory() { }

        public SuccessCategory(int ID, string name)
        {
            this.ID = ID;
            Name = name;
        }
    }
}
