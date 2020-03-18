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

            seMap.SuccessCategories = new SuccessCategory[5]
            {
                new SuccessCategory("Soft Skills"),
                new SuccessCategory("Life Long Learning Ability"),
                new SuccessCategory("Special Technical Skills, Techniques and Tools"),
                new SuccessCategory("Fundamental Knowledge"),
                new SuccessCategory("Citizenship")
            };

            foreach (SuccessCategory category in  seMap.SuccessCategories)
            {
                category.SchoolYears = new SchoolYear[4]
                {
                    new SchoolYear("Freshman", new Semester("Fall"), new Semester("Spring"), new Semester("Summer")),
                    new SchoolYear("Sophomore", new Semester("Fall"), new Semester("Spring"), new Semester("Summer")),
                    new SchoolYear("Junior", new Semester("Fall"), new Semester("Spring"), new Semester("Summer")),
                    new SchoolYear("Senior", new Semester("Fall"), new Semester("Spring"), new Semester("Summer"))
                };
            }

            //Soft Skills - Freshman - Fall
            seMap.SuccessCategories[0].SchoolYears[0].Fall.SuccessObjectives = new List<SuccessObjective>()
            {
                new Course("Introduction to Computer Networking", "Test description",
                "https://catalog.stcloudstate.edu/Catalog/ViewCatalog.aspx?pageid=viewcatalog&topicgroupid=1964&entitytype=CID&entitycode=SE+221",
                "SE 221",
                CourseType.ProgramCore),
                new SuccessActivity("Hackathon", "Test description", "")
            };

            return seMap;
        }
    }
}
