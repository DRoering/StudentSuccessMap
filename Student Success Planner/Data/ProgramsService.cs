using System;
using System.Collections.Generic;
using System.Data;
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

            //Get programs from database
            DatabaseSelect dbSelect = new DatabaseSelect();
            DataTable programsTable = dbSelect.SelectPrograms(department.ID);

            //Convert data to Program objects
            List<Program> programs = new List<Program>();
            foreach (DataRow row in programsTable.Rows)
            {
                programs.Add(DataInterpreter.getProgram(row));
            }

            return Task.FromResult(programs.ToArray());
        }
    }
}
