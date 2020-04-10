using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SuccessMapSearchService
    {
        /// <summary>
        /// Current success map being searched.
        /// </summary>
        private SuccessMap successMap;

        /// <summary>
        /// Current value of the search.
        /// </summary>
        public string Search { get; private set; } = "";

        /// <summary>
        /// Current search filter value for success objective type.
        /// </summary>
        public string TypeFilter { get; private set; } = SuccessMapSearchFilters.NONE;

        /// <summary>
        /// Current search filter value for success objective classifier.
        /// </summary>
        public string ClassifierFilter { get; private set; } = SuccessMapSearchFilters.NONE;

        /// <summary>
        /// Collection of all success objectives relevant to the current search criteria.
        /// </summary>
        private List<SuccessObjective> relevantSuccessObjectives;

        /// <summary>
        /// Indexes the success objectives based on the filter(s) they apply to.
        /// </summary>
        private Dictionary<string, List<SuccessObjective>> filteredObjectives;

        /// <summary>
        /// Determines if the relevant success objectives need to be updated.
        /// </summary>
        private bool needsUpdate = true;

        /// <summary>
        /// Initializes based on the given success map.
        /// </summary>
        private void init(SuccessMap successMap)
        {
            this.successMap = successMap;

            relevantSuccessObjectives = new List<SuccessObjective>();

            filteredObjectives = new Dictionary<string, List<SuccessObjective>>();
            filteredObjectives[SuccessMapSearchFilters.GOAL_AREAS] = new List<SuccessObjective>();
            filteredObjectives[SuccessMapSearchFilters.PROGRAM_CORE] = new List<SuccessObjective>();
            filteredObjectives[SuccessMapSearchFilters.ELECTIVES] = new List<SuccessObjective>();
            filteredObjectives[SuccessMapSearchFilters.SUCCESS_ACTIVITIES] = new List<SuccessObjective>();
            filteredObjectives[SuccessMapSearchFilters.NONE] = new List<SuccessObjective>(successMap.AllSuccessObjectives);

            //Index success objectives according to filter options for quicker searching later
            foreach (SuccessObjective objective in successMap.AllSuccessObjectives)
            {
                if (objective is Course)
                {
                    Course course = (Course)objective;
                    switch (course.Type)
                    {
                        case CourseType.GoalArea:
                            filteredObjectives[SuccessMapSearchFilters.GOAL_AREAS].Add(objective);
                            break;
                        case CourseType.ProgramCore:
                            filteredObjectives[SuccessMapSearchFilters.PROGRAM_CORE].Add(objective);
                            break;
                        case CourseType.Elective:
                            filteredObjectives[SuccessMapSearchFilters.ELECTIVES].Add(objective);
                            break;
                    }
                }
                else if (objective is SuccessActivity)
                {
                    filteredObjectives[SuccessMapSearchFilters.SUCCESS_ACTIVITIES].Add(objective);
                }
            }

            needsUpdate = true;
        }

        /// <summary>
        /// Gets the success objectives relevant to the current search criteria.
        /// </summary>
        public SuccessObjective[] getRelevantSuccessObjectives(SuccessMap successMap)
        {
            if (this.successMap != successMap)
                init(successMap);

            if (needsUpdate)
            {
                //No classifier filter, only check for search value
                if (ClassifierFilter == SuccessMapSearchFilters.NONE)
                    relevantSuccessObjectives = filteredObjectives[TypeFilter].FindAll(objective =>
                            objective.Name.Contains(Search)
                        );
                else //Classifier filter active
                    relevantSuccessObjectives = filteredObjectives[TypeFilter].FindAll(objective =>
                            objective.Classifier != null &&
                            objective.Classifier.Classifier == ClassifierFilter &&
                            objective.Name.Contains(Search)
                        );
            }

            return relevantSuccessObjectives.ToArray();
        }

        /// <summary>
        /// Gets the success objectives relevant to the current search criteria.
        /// </summary>
        public void onSearchChanged(string search)
        {
            Search = search == null ? "" : search;
            
            needsUpdate = true;
        }

        /// <summary>
        /// Handles the event of the success map search type filter changing.
        /// </summary>
        public void onSearchTypeFilterChanged(string filter)
        {
            TypeFilter = filter;
            needsUpdate = true;
        }

        /// <summary>
        /// Handles the event of the success map search classifier filter changing.
        /// </summary>
        public void onSearchClassifierFilterChanged(string filter)
        {
            ClassifierFilter = filter;
            needsUpdate = true;
        }
    }

    public static class SuccessMapSearchFilters
    {
        public const string NONE = "None";
        public const string GOAL_AREAS = "Goal Areas";
        public const string PROGRAM_CORE = "Program Core";
        public const string ELECTIVES = "Electives";
        public const string SUCCESS_ACTIVITIES = "Success Activities";

        /// <summary>
        /// Search filters for success objective type.
        /// </summary>
        public static string[] TypeFilters { get; } = new string[]
        {
            NONE,
            GOAL_AREAS,
            ELECTIVES,
            SUCCESS_ACTIVITIES
        };
    }
}
