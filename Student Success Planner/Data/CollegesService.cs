using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class CollegesService
    {
        /// <summary>
        /// Gets an array of Colleges in the university asynchronously.
        /// </summary>
        public Task<College[]> getCollegesAsync()
        {
            //Retrieve data here

            //Hard code data for now
            College[] colleges = new College[6]
            {
                new College("Liberal Arts", "CLA"),
                new College("Herberger Business School", "HBS"),
                new College("School of Public Affairs", "SOPA"),
                new College("College of Science and Engineering", "COSE"),
                new College("School of Education", "SOE"),
                new College("School of Health and Human Services", "SHHS")
            };

            return Task.FromResult(colleges);
        }
    }
}
