using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class ProgramsService
    {
        /// <summary>
        /// Gets an array of Programs in the specified Department asynchronously.
        /// </summary>
        /// <param name="department">The Department to retrieve Programs for.</param>
        public Task<Program[]> getProgramsAsync(Department department)
        {
            //Can't retrieve departments without knowing the college to retrieve from (eventually)
            if (department == null)
                return null;

            //Return department programs if already retrieved
            //Don't refresh due to low frequency of change
            if (department.programs != null)
                return Task.FromResult(department.programs);

            //Retrieve data here

            ////Hard code data for now, only for Computer Science & Information Technology
            //if (department.getName() == "Computer Science & Information Technology")
            //{
            //    Program[] programs = new Program[4]
            //    {
            //        new Program("Computer Science", "CSCI"),
            //        new Program("Cyber Security", "CNA"),
            //        new Program("Software Engineering", "SE"),
            //        new Program("Computer Science (MS)", "CSCI MS")
            //    };

            //    //Populate the college with the departments for later reference
            //    department.programs = programs;

            //    return Task.FromResult(programs);
            //}
            //else
                return null;
        }
    }
}
