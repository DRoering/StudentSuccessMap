using System;
using System.Collections.Generic;
using System.Data;
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

            //Get departments from database
            DatabaseSelect dbSelect = new DatabaseSelect();
            DataTable departmentsTable = dbSelect.SelectDepartments(college.ID);

            //Convert data to Department objects
            List<Department> departments = new List<Department>();
            foreach (DataRow row in departmentsTable.Rows)
            {
                departments.Add(DataInterpreter.getDepartment(row));
            }

            return Task.FromResult(departments.ToArray());
        }
    }
}
