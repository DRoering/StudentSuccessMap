using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class College : Abbreviatable, CardItem
    {
        /// <summary>
        /// Departments contained within the college.
        /// </summary>
        public Department[] departments { get; set; }

        private string name;
        private string abbreviation;

        public College(string name, string abbreviation)
        {
            this.name = name;
            this.abbreviation = abbreviation;
        }

        #region Abbreviatable

        public string getAbbreviation()
        {
            return abbreviation;
        }

        public string getName()
        {
            return name;
        }

        #endregion Abbreviatable

        #region CardItem

        public string getTitle()
        {
            return abbreviation;
        }

        public string getDescription()
        {
            return name;
        }

        #endregion CardItem
    }
}
