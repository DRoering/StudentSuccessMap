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

        /// <summary>
        /// Unique ID of this college.
        /// </summary>
        public int ID { get; }

        private string name;
        private string abbreviation;

        public College(int ID, string name, string abbreviation)
        {
            this.ID = ID;
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

        public CardItemData getCardItemData()
        {
            return new CardItemData(abbreviation, name);
        }

        #endregion CardItem
    }
}
