using System;
using System.Collections.Generic;
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

            //Retrieve data here

            //Hard code data for now, only for SE
            if (program.getAbbreviation() == "SE")
            {
                SuccessMap successMap = getTestSESuccessMap();

                //Populate the college with the departments for later reference
                program.successMap = successMap;

                return Task.FromResult(successMap);
            }
            else
                return null;
        }

        /// <summary>
        /// Gets a test success map for the SE program.
        /// </summary>
        /// <returns></returns>
        private SuccessMap getTestSESuccessMap()
        {
            SuccessMap seMap = new SuccessMap();

            seMap.addSuccessCategories(new SuccessCategory[5]
            {
                new SuccessCategory("Soft Skills"),
                new SuccessCategory("Life Long Learning Ability"),
                new SuccessCategory("Special Technical Skills, Techniques and Tools"),
                new SuccessCategory("Fundamental Knowledge"),
                new SuccessCategory("Citizenship")
            });

            seMap.addSchoolYears(new SchoolYear[4]
            {
                new SchoolYear("Freshman"),
                new SchoolYear("Sophomore"),
                new SchoolYear("Junior"),
                new SchoolYear("Senior")
            });

            foreach (SchoolYear schoolYear in seMap.SchoolYears)
            {
                schoolYear.Fall = new Semester("Fall", schoolYear);
                schoolYear.Spring = new Semester("Spring", schoolYear);
                schoolYear.Summer = new Semester("Summer", schoolYear);
            }

            #region Success Objective Classifers

            SuccessObjectiveClassifier labs = new SuccessObjectiveClassifier("Labs & Experiential Learning");
            SuccessObjectiveClassifier rsd =
                new SuccessObjectiveClassifier("Read Search & Discuss (Exploratory assignment: literature review + oral presentation + report)");
            SuccessObjectiveClassifier groupProjects = new SuccessObjectiveClassifier("Group-based Semester Long Industry-Directed Projects");
            SuccessObjectiveClassifier researchActivities = new SuccessObjectiveClassifier("Research Activities");
            SuccessObjectiveClassifier workExperience = new SuccessObjectiveClassifier("Professional Working Experience");

            Dictionary<string, SuccessObjectiveClassifier> classifiers = new Dictionary<string, SuccessObjectiveClassifier>();
            classifiers.Add(labs.Classifier, labs);
            classifiers.Add(rsd.Classifier, rsd);
            classifiers.Add(groupProjects.Classifier, groupProjects);
            classifiers.Add(researchActivities.Classifier, researchActivities);
            classifiers.Add(workExperience.Classifier, workExperience);

            #endregion Success Objective Classifers

            #region Soft Skills

            #region Freshman

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[0].Fall, new List<SuccessObjective>()
            {
                new Course("Introduction to Computer Networking", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+221",
                1, rsd, "SE 221", CourseType.Elective),
                new SuccessActivity("Hackathons", "Test description", "", 1, null)
            });

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[0].Spring, new List<SuccessObjective>()
            {
                new Course("Introduction to Computer Security", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+231",
                1, rsd, "SE 231", CourseType.ProgramCore),
                new SuccessActivity("Hackathons", "Test description", "", 1, null),
                new SuccessActivity("Husky Invent", "Test description", "", 1, null),
            });

            #endregion Freshman

            #region Sophomore

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[1].Fall, new List<SuccessObjective>()
            {
                new Course("Applied Undergraduate Research", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+342",
                1, groupProjects, "SE 340", CourseType.ProgramCore),
                new Course("Communication in the Workplace", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=CMST+341",
                1, null, "CMST 341", CourseType.GoalArea),
                new SuccessActivity("Std. Res. Grant", "Student Research Grant", "", 1, null)
            });

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[1].Spring, new List<SuccessObjective>()
            {
                new Course("Applied Undergraduate Research", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+342",
                1, groupProjects,  "SE 341", CourseType.ProgramCore),
                new Course("Software Engineering and Human Computer Interaction", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+350",
                1, groupProjects, "SE 350", CourseType.ProgramCore),
                new SuccessActivity("Std. Res. Grant", "Student Research Grant", "", 1, null),
                new SuccessActivity("SCSU Colloquium", "Test description", "", 1, null)
            });

            #endregion Sophomore

            #region Junior

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[2].Fall, new List<SuccessObjective>()
            {
                new SuccessActivity("Hackathons", "Test description", "", 1, null),
                new SuccessActivity("Corporate Visits", "Test description", "", 1, null)
            });

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[2].Spring, new List<SuccessObjective>()
            {
                new SuccessActivity("Hackathons", "Test description", "", 1, null),
                new SuccessActivity("Mock Interview", "Test description", "", 1, null),
                new SuccessActivity("Corporate Visits", "Test description", "", 1, null)
            });

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[2].Summer, new List<SuccessObjective>()
            {
                new Course("Internship", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+444",
                1, workExperience, "SE 444", CourseType.ProgramCore),
                new SuccessActivity("Research Assist.", "Test description", "", 1, null)
            });

            #endregion Junior

            #region Senior

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[3].Fall, new List<SuccessObjective>()
            {
                new Course("Software Project 1", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+490",
                1, groupProjects, "SE 490", CourseType.ProgramCore),
                new SuccessActivity("Hackathons", "Test description", "", 1, null),
                new SuccessActivity("Corporate Visits", "Test description", "", 1, null)
            });

            seMap.addSuccessObjectives(seMap.SuccessCategories[0], seMap.SchoolYears[3].Spring, new List<SuccessObjective>()
            {
                new Course("Software Project 2", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+491",
                1, groupProjects, "SE 491", CourseType.ProgramCore),
                new SuccessActivity("Hackathons", "Test description", "", 1, null),
                new SuccessActivity("Mock Interview", "Test description", "", 1, null),
                new SuccessActivity("Corporate Visits", "Test description", "", 1, null)
            });

            #endregion Senior

            #endregion Soft Skills

            return seMap;
        }
    }
}
