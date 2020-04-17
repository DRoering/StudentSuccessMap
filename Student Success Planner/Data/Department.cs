using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class Department : CardItem
    {
        /// <summary>
        /// Programs contained within the department.
        /// </summary>
        public Program[] programs { get; set; }

        /// <summary>
        /// Unique ID of this department.
        /// </summary>
        public int ID { get; }

        private string name;

        public Department(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        #region CardItem

        public CardItemData getCardItemData()
        {
            return new CardItemData(name, null);
        }

        #endregion CardItem
    }
}
