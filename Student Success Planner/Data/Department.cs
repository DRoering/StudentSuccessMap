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

        private string name;

        public Department(string name)
        {
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
