using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Student_Success_Planner.Data
{
    public class CollegesService
    {
        /// <summary>
        /// Gets an array of Colleges in the university asynchronously.
        /// </summary>
        public Task<College[]> getCollegesAsync()
        {
            //Get colleges from database
            DatabaseSelect dbSelect = new DatabaseSelect();
            DataTable collegeTable = dbSelect.SelectColleges();

            //Convert data to College objects
            List<College> colleges = new List<College>();
            foreach (DataRow row in collegeTable.Rows)
            {
                colleges.Add(DataInterpreter.getCollege(row));
            }

            return Task.FromResult(colleges.ToArray());
        }
    }
}
