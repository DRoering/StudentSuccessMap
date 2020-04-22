using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class DatabaseSelect
    {
        DBConnector Connector = new DBConnector();

        private string Statement = "";

        //Selects all College table information from the database
        public DataTable SelectColleges()
        {
            Statement = "SELECT * FROM College";

            return Connector.QueryDatabase(Statement);
        }

        //Selects all Department table information with a CollegeID
        public DataTable SelectDepartments(int CID)
        {
            Statement = "Select * FROM Department WHERE CollegeID =" + CID;

            return Connector.QueryDatabase(Statement);
        }

        //Selects all Program table information with a DepartmentID
        public DataTable SelectPrograms(int DID)
        {
            Statement = "Select * FROM Program WHERE DeptID =" + DID;

            return Connector.QueryDatabase(Statement);
        }

        //Selects all SuccessMap table information with a ProgramID
        public DataTable SelectSuccessMap(int PID)
        {
            Statement = "Select * FROM SuccessMap WHERE PrgmID =" + PID;

            return Connector.QueryDatabase(Statement);
        }

        //Selects all StudentSuccessMap table information with a StarID and Program
        public DataTable SelectStudentSuccessMap(string starID, int PID)
        {
            Statement = "Select * FROM StudentSuccessMap WHERE StarID = '" + starID + "' AND PrgmID = " + PID;

            return Connector.QueryDatabase(Statement);
        }

        //Selects all CompletedObjectives with the given StarID
        public DataTable SelectCompletedObjectives(string starID)
        {
            Statement = "Select * FROM CompletedObjective WHERE StarID = '" + starID + "'";

            return Connector.QueryDatabase(Statement);
        }

        //Objective ID to select Objective info
        public DataTable SelectObjective(string OID)
        {
            Statement = "Select * FROM Objective WHERE ObjID = '" + OID + "'";

            return Connector.QueryDatabase(Statement);
        }

        //Select all years
        public DataTable SelectAllYears()
        {
            Statement = "Select * FROM Year";

            return Connector.QueryDatabase(Statement);
        }

        //Year to select Year info
        public DataTable SelectYear(int Yr)
        {
            Statement = "Select * FROM Year WHERE Year =" + Yr;

            return Connector.QueryDatabase(Statement);
        }

        //Year to select semesters
        //public DataTable SelectSemester(int Yr)
        //{
        //    Statement = "Select * FROM  Semester WHERE Year =" + Yr;

        //    return Connector.QueryDatabase(Statement);
        //}

        //Semester ID to select semesters
        public DataTable SelectSemester(int semesterID)
        {
            Statement = "Select * FROM  Semester WHERE SemesterID =" + semesterID;

            return Connector.QueryDatabase(Statement);
        }

        //Success Category ID to select Success Category info
        public DataTable SelectCategory(int CID)
        {
            Statement = "Select * FROM SuccessCategory WHERE CategoryID =" + CID;

            return Connector.QueryDatabase(Statement);
        }

        //Success Objective Classifier ID to select Success Objective Classifier info
        public DataTable SelectClassifier(int classificationID)
        {
            Statement = "Select * FROM SuccessObjectiveClassification WHERE ClassificationID =" + classificationID;

            return Connector.QueryDatabase(Statement);
        }

        //Objective ID to select Success Objective map
        public DataTable SelectSuccessObjMapObjective(int OID)
        {
            Statement = "Select * FROM SuccessObjectiveMapping WHERE ObjID =" + OID;

            return Connector.QueryDatabase(Statement);
        }

        //Success Map ID to select Success Objective map
        public DataTable SelectSuccessObjMapSuccessMap(int SID)
        {
            Statement = "Select * FROM SuccessObjectiveMapping WHERE SMID =" + SID;

            return Connector.QueryDatabase(Statement);
        }

    }
}
