using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public interface CardItem
    {
        public CardItemData getCardItemData();
    }

    /// <summary>
    /// Holds the data associated with a CardItem.
    /// </summary>
    public struct CardItemData
    {
        public string title { get; set; }
        public string description { get; set; }

        public CardItemData(string title, string description)
        {
            this.title = title;
            this.description = description;
        }
    }
}
