using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Student_Success_Planner.Data
{
    public class DatabaseSelect
    {
        private string Statement = "";

        //Selects all College table information from the database
        public void SelectColleges()
        {
            Statement = "SELECT * FROM College";
        }

        //Selects all Department table information with a CollegeID
        public void SelectDepartments(int CID)
        {
            Statement = "Select * FROM Department WHERE CollegeID =" + CID;
        }

        //Selects all Program table information with a DepartmentID
        public void SelectProgram(int DID)
        {
            Statement = "Select * FROM Program WHERE DeptID =" + DID;
        }

        //Selects all SuccessMap table information with a ProgramID
        public void SelectSuccessMap(int PID)
        {
            Statement = "Select * FROM SuccessMap WHERE PrgmID =" + PID;
        }

        //Objective ID to select Objective info
        public void SelectObjective(int OID)
        {
            Statement = "Select * FROM Objective WHERE ObjectiveID =" + OID;
        }

        //Select all years
        public void SelectAllYears()
        {
            Statement = "Select * FROM Year";
        }

        //Year to select Year info
        public void SelectYear(int Yr)
        {
            Statement = "Select * FROM Year WHERE Year =" + Yr;
        }

        //Year to select semesters
        public void SelectSemester(int Yr)
        {
            Statement = "Select * FROM  Semester WHERE Year =" + Yr;
        }

        //Success Category ID to select Success Category info
        public void SelectCategory(int CID)
        {
            Statement = "Select * FROM SuccessCategory WHERE CategoryID =" + CID;
        }

        //Objective ID to select Success Objective map
        public void SelectSuccessObjMapObjective(int OID)
        {
            Statement = "Select * FROM SuccessObjectiveMapping WHERE ObjID =" + OID;
        }

        //Semester ID to select Success Objective map
        public void SelectSuccessObjMapSemester(int SID)
        {
            Statement = "Select * FROM SuccessObjectiveMapping WHERE SMID =" + SID;
        }

    }
}
