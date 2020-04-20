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

        public static SuccessMap getSuccessMap(DataRow data)
        {
            int ID = (int)data["SMID"];
            string name = data["SMName"].ToString();

            SuccessMap successMap = new SuccessMap(ID, name);

            DatabaseSelect dbSelect = new DatabaseSelect();

            DataTable objectiveMappingsTable = dbSelect.SelectSuccessObjMapSuccessMap(ID);

            //The success map has success objectives
            if (objectiveMappingsTable != null && objectiveMappingsTable.Rows.Count > 0)
            {
                Dictionary<int, SuccessCategory> categories = new Dictionary<int, SuccessCategory>();
                Dictionary<int, SuccessObjectiveClassifier> classifiers = new Dictionary<int, SuccessObjectiveClassifier>();
                Dictionary<int, Semester> semesters = new Dictionary<int, Semester>();
                Dictionary<int, SchoolYear> schoolYears = new Dictionary<int, SchoolYear>();

                foreach (DataRow mappingData in objectiveMappingsTable.Rows)
                {
                    string objectiveID = mappingData["ObjID"].ToString();
                    int semesterID = (int)mappingData["SemesterID"];
                    int categoryID = (int)mappingData["CategoryID"];
                    int weight = (int)mappingData["Weight"];

                    //Classifier optional
                    int classifierID;
                    try
                    {
                        classifierID = (int)mappingData["ClassificationID"];

                        //Get success objective classifier if it doesn't already exist
                        if (!classifiers.ContainsKey(classifierID))
                        {
                            DataTable classifierTable = dbSelect.SelectClassifier(classifierID);
                            if (classifierTable != null && classifierTable.Rows.Count > 0) //Classifier exists
                            {
                                classifiers.Add(classifierID, getSuccessObjectiveClassifier(classifierTable.Rows[0]));
                            }
                        }
                    }
                    catch
                    {
                        classifierID = default;
                        Console.WriteLine("Classifier ID not provided for objective: " + objectiveID);
                    }

                    SuccessObjective successObjective = null;

                    //Get success objective
                    DataTable objectiveTable = dbSelect.SelectObjective(objectiveID);
                    if (objectiveTable != null && objectiveTable.Rows.Count > 0) //Objective exists
                    {
                        //Check if objective has a classifier
                        SuccessObjectiveClassifier classifier = classifierID != default ? classifiers[classifierID] : null;
                        successObjective = getSuccessObjective(objectiveTable.Rows[0], weight, classifier);
                    }
                    else
                        Console.WriteLine("Could not retrieve success objective with ID: " + objectiveID);

                    //Get success category if it doesn't already exist
                    if (!categories.ContainsKey(categoryID))
                    {
                        DataTable categoryTable = dbSelect.SelectCategory(categoryID);
                        if (categoryTable != null && categoryTable.Rows.Count > 0) //Category exists
                        {
                            categories.Add(categoryID, getSuccessCategory(categoryTable.Rows[0]));
                        }
                        else
                            Console.WriteLine("Could not retrieve success category with ID: " + categoryID);
                    }

                    //Get semester if it doesn't already exist
                    if (!semesters.ContainsKey(semesterID))
                    {
                        DataTable semesterTable = dbSelect.SelectSemester(semesterID);
                        if (semesterTable != null && semesterTable.Rows.Count > 0) //Semester exists
                        {
                            int year;
                            semesters.Add(semesterID, getSemester(semesterTable.Rows[0], out year));

                            //Get year if it doesn't already exist
                            if (!schoolYears.ContainsKey(year))
                            {
                                DataTable yearTable = dbSelect.SelectYear(year);
                                if (yearTable != null && yearTable.Rows.Count > 0) //Year exists
                                {
                                    schoolYears.Add(year, getSchoolYear(yearTable.Rows[0]));
                                }
                                else
                                    Console.WriteLine("Could not retrieve school year with ID: " + year);
                            }

                            //Add semester to year
                            Semester semester = semesters[semesterID];
                            SchoolYear schoolYear = schoolYears[year];
                            semester.SchoolYear = schoolYear;

                            //Associate semester with school year
                            string lowerCaseName = semester.Name.ToLower();
                            if (lowerCaseName.Contains("fall"))
                                schoolYear.Fall = semester;
                            else if (lowerCaseName.Contains("spring"))
                                schoolYear.Spring = semester;
                            else if (lowerCaseName.Contains("summer"))
                                schoolYear.Summer = semester;
                        }
                    }

                    SuccessCategory category = categories[categoryID];
                    Semester objectiveSemester = semesters[semesterID];

                    //Add success objective to the success map if all the required data is present
                    if (successObjective != null && category != null && objectiveSemester != null)
                        successMap.addSuccessObjective(category, objectiveSemester, successObjective);
                    else
                        Console.WriteLine("Could not add success objective to success map, missing required data.");
                }

                //Add classifiers to success map
                successMap.addSuccessObjectiveClassifiers(classifiers.Values);
            }

            return successMap;
        }

        public static SuccessObjective getSuccessObjective(DataRow data, int weight, SuccessObjectiveClassifier classifier)
        {
            string ID = data["ObjID"].ToString();
            string name = data["ObjName"].ToString();
            string description = data["Description"].ToString();
            string link = data["Link"].ToString();
            string type = data["Type"].ToString().ToLower();

            if (type.Contains("course"))
            {
                if (type.Contains("goalarea"))
                    return new Course(ID, name, description, link, weight, classifier, ID, CourseType.GoalArea);
                else if (type.Contains("programcore"))
                    return new Course(ID, name, description, link, weight, classifier, ID, CourseType.ProgramCore);
                else //Elective
                    return new Course(ID, name, description, link, weight, classifier, ID, CourseType.Elective);
            }
            else if (type.Contains("activity"))
                return new SuccessActivity(ID, name, description, link, weight, classifier);
            else
                return null;

        }

        public static SuccessCategory getSuccessCategory(DataRow data)
        {
            int ID = (int)data["CategoryID"];
            string name = data["Name"].ToString();
            return new SuccessCategory(ID, name);
        }

        public static SuccessObjectiveClassifier getSuccessObjectiveClassifier(DataRow data)
        {
            int ID = (int)data["ClassificationID"];
            string name = data["Name"].ToString();
            return new SuccessObjectiveClassifier(ID, name);
        }

        public static Semester getSemester(DataRow data, out int year)
        {
            int ID = (int)data["SemesterID"];
            year = (int)data["Year"];
            string name = data["SemesterName"].ToString();

            return new Semester(ID, name);
        }

        public static SchoolYear getSchoolYear(DataRow data)
        {
            int year = (int)data["Year"];
            string studentClass = data["Class"].ToString();

            return new SchoolYear(year, studentClass);
        }
    }
}
