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
    }
}
