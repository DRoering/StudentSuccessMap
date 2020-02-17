using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class Program : Abbreviatable, CardItem
    {
        /// <summary>
        /// Success Map for the Program.
        /// </summary>
        public SuccessMap successMap { get; set; }

        private string name;
        private string abbreviation;

        public Program(string name, string abbreviation)
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
