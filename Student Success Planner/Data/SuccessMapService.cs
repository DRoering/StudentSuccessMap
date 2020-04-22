using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SuccessMapService
    {
        /// <summary>
        /// Gets a SuccessMap for the given Program.
        /// </summary>
        /// <param name="program">The Program to retrieve a SuccessMap for.</param>
        public Task<SuccessMap> getSuccessMapAsync(Program program)
        {
            //Can't retrieve success map without knowing the program to retrieve from (eventually)
            if (program == null)
                return null;

            //Return program success map if already retrieved
            //Don't refresh due to low frequency of change
            if (program.successMap != null)
                return Task.FromResult(program.successMap);

            DatabaseSelect dbSelect = new DatabaseSelect();
            DataTable successMapTable = dbSelect.SelectSuccessMap(program.ID);

            //Make sure a success map was retrieved
            if (successMapTable != null && successMapTable.Rows.Count > 0)
            {
                SuccessMap successMap = DataInterpreter.getSuccessMap(successMapTable.Rows[0]);
                program.successMap = successMap;
                return Task.FromResult(successMap);
            }
            else
                return null;
        }

        /// <summary>
        /// Gets a StudentSuccessMap for the student with the given star ID and Program.
        /// </summary>
        /// /// <param name="starID">The Star ID of the student to retrieve a StudentSuccessMap for.</param>
        /// <param name="program">The Program to retrieve a SuccessMap for.</param>
        public Task<StudentSuccessMap> getStudentSuccessMapAsync(string starID, Program program)
        {
            //Can't retrieve success map without knowing the program to retrieve from (eventually)
            if (program == null)
                return null;

            //Return program success map if already retrieved
            //Don't refresh due to low frequency of change
            if (program.successMap != null && program.successMap is StudentSuccessMap)
                return Task.FromResult((StudentSuccessMap)program.successMap);

            DatabaseSelect dbSelect = new DatabaseSelect();
            DataTable studentSuccessMapTable = dbSelect.SelectStudentSuccessMap(starID, program.ID);

            //Make sure a student success map was retrieved
            if (studentSuccessMapTable != null && studentSuccessMapTable.Rows.Count > 0)
            {
                StudentSuccessMap successMap = DataInterpreter.getStudentSuccessMap(studentSuccessMapTable.Rows[0]);
                program.successMap = successMap;
                return Task.FromResult(successMap);
            }
            else
                return null;
        }
    }
}
