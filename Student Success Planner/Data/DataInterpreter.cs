using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Student_Success_Planner.Data
{
    /// <summary>
    /// Provides methods to convert data from the database into objects used by this application.
    /// </summary>
    public static class DataInterpreter
    {
        public static College getCollege(DataRow data)
        {
            int ID = (int)data["CollegeID"];
            string name = data["CollegeName"].ToString();
            string abbreviation = data["Abbr"].ToString();

            return new College(ID, name, abbreviation);
        }

        public static Department getDepartment(DataRow data)
        {
            int ID = (int)data["DepartmentID"];
            string name = data["DeptName"].ToString();

            return new Department(ID, name);
        }

        public static Program getProgram(DataRow data)
        {
            int ID = (int)data["PrgmID"];
            string name = data["PrgmName"].ToString();
            string abbreviation = data["Abbr"].ToString();

            return new Program(ID, name, abbreviation);
        }
    }
}
