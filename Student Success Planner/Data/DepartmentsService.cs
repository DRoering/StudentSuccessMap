using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class DepartmentsService
    {
        /// <summary>
        /// Gets an array of Departments in the specified College asynchronously.
        /// </summary>
        /// <param name="college">The College to retrieve Departments for.</param>
        public Task<Department[]> getDepartmentsAsync(College college)
        {
            //Can't retrieve departments without knowing the college to retrieve from (eventually)
            if (college == null)
                return null;

            //Return college departments if already retrieved
            //Don't refresh due to low frequency of change
            if (college.departments != null)
                return Task.FromResult(college.departments);

            //Retrieve data here

            //Hard code data for now, only for COSE
            if (college.getAbbreviation() == "COSE")
            {
                Department[] departments = new Department[10]
                {
                    new Department("Biology"),
                    new Department("Chemistry & Biochemistry"),
                    new Department("Physics & Astronomy"),
                    new Department("Mathematics & Statistics"),
                    new Department("Applied Education in the MedTech Industry"),
                    new Department("Atmospheric and Hydrologic Sciences"),
                    new Department("Computer Science & Information Technology"),
                    new Department("Electrical & Computer Engineering"),
                    new Department("Environment & Technological Studies"),
                    new Department("Mechanical & Manufacturing Engineering")
                };

                //Populate the college with the departments for later reference
                college.departments = departments;

                return Task.FromResult(departments);
            }
            else
                return null;
        }
    }
}
