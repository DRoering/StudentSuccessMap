using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class SuccessMap
    {
        /// <summary>
        /// Categories of success objectives in the success map.
        /// </summary>
        public SuccessCategory[] SuccessCategories
        {
            get
            {
                return successCategories.ToArray();
            }
        }
        private List<SuccessCategory> successCategories;

        /// <summary>
        /// School years represented in the success map.
        /// </summary>
        public SchoolYear[] SchoolYears
        {
            get
            {
                return schoolYears.ToArray();
            }
        }
        private List<SchoolYear> schoolYears;

        /// <summary>
        /// Success objectives organized by success category and semester.
        /// </summary>
        private Dictionary<Tuple<SuccessCategory, Semester>, List<SuccessObjective>> successObjectives;

        public SuccessMap()
        {
            successCategories = new List<SuccessCategory>();
            schoolYears = new List<SchoolYear>();
            successObjectives = new Dictionary<Tuple<SuccessCategory, Semester>, List<SuccessObjective>>();
        }

        public SuccessMap(ICollection<SuccessCategory> successCategories, ICollection<SchoolYear> schoolYears)
        {
            this.successCategories = new List<SuccessCategory>(successCategories);
            this.schoolYears = new List<SchoolYear>(schoolYears);
            successObjectives = new Dictionary<Tuple<SuccessCategory, Semester>, List<SuccessObjective>>();
        }

        #region Success Categories

        /// <summary>
        /// Adds a success category to the success map.
        /// </summary>
        public void addSuccessCategory(SuccessCategory successCategory)
        {
            if (successCategory != null)
                successCategories.Add(successCategory);
        }

        /// <summary>
        /// Adds a collection of success categories to the success map.
        /// </summary>
        public void addSuccessCategories(ICollection<SuccessCategory> successCategories)
        {
            if (successCategories != null)
                this.successCategories.AddRange(successCategories);
        }

        #endregion Success Categories

        #region School Years

        /// <summary>
        /// Adds a school year to the success map.
        /// </summary>
        public void addSchoolYear(SchoolYear schoolYear)
        {
            if (schoolYear != null)
                schoolYears.Add(schoolYear);
        }

        /// <summary>
        /// Adds a collection of success categories to the success map.
        /// </summary>
        public void addSchoolYears(ICollection<SchoolYear> schoolYears)
        {
            if (schoolYears != null)
                this.schoolYears.AddRange(schoolYears);
        }

        #endregion School Years

        #region Success Objectives

        /// <summary>
        /// Adds a success objective to the given SuccessCategory and Semester.
        /// </summary>
        /// <param name="successCategory">Success category the objective is in.</param>
        /// <param name="semester">School semester the objective is in.</param>
        /// <param name="successObjective">The success objective to add.</param>
        public void addSuccessObjective(SuccessCategory successCategory, Semester semester,
            SuccessObjective successObjective)
        {
            if (successCategory != null && semester != null && successObjective != null)
            {
                //Category not already in the success map, add it
                if (!successCategories.Contains(successCategory))
                    successCategories.Add(successCategory);

                //Semester SchoolYear not already in the success map, add it
                if (!schoolYears.Contains(semester.SchoolYear))
                    schoolYears.Add(semester.SchoolYear);

                var key = new Tuple<SuccessCategory, Semester>(successCategory, semester);

                //Key does not exist, create it and instantiate objectives list
                if (!successObjectives.ContainsKey(key))
                    successObjectives.Add(key, new List<SuccessObjective>());

                //Add the successObjective to the list
                successObjectives[key].Add(successObjective);
            }
        }

        /// <summary>
        /// Adds success objectives to the given SuccessCategory and Semester.
        /// </summary>
        /// <param name="successCategory">Success category the objective is in.</param>
        /// <param name="semester">School semester the objective is in.</param>
        /// <param name="successObjectives">The success objectives to add.</param>
        public void addSuccessObjectives(SuccessCategory successCategory, Semester semester,
            ICollection<SuccessObjective > successObjectives)
        {
            if (successCategory != null && semester != null && successObjectives != null)
            {
                foreach (SuccessObjective objective in successObjectives)
                {
                    addSuccessObjective(successCategory, semester, objective);
                }
            }
        }

        /// <summary>
        /// Removes a success objective from the given SuccessCategory and Semester.
        /// </summary>
        /// <param name="successCategory">Success category the objective is in.</param>
        /// <param name="semester">School semester the objective is in.</param>
        /// <param name="successObjective">The success objective to remove.</param>
        public bool removeSuccessObjective(SuccessCategory successCategory, Semester semester,
            SuccessObjective successObjective)
        {
            var key = new Tuple<SuccessCategory, Semester>(successCategory, semester);

            //Key does not exist
            if (!successObjectives.ContainsKey(key))
                return false;

            //Remove the successObjective from the list
            return successObjectives[key].Remove(successObjective); ;
        }

        /// <summary>
        /// Tries to get the success objectives for the given category and semester.
        /// </summary>
        /// <param name="successCategory">Success category to search.</param>
        /// <param name="semester">Semester to search.</param>
        /// <param name="objectives">Success objectives found in the search.</param>
        /// <returns>True if success objectives are found, false otherwise.</returns>
        public bool tryGetSuccessObjectives(SuccessCategory successCategory, Semester semester,
            out SuccessObjective[] objectives)
        {
            if (successCategory != null && semester != null)
            {
                var key = new Tuple<SuccessCategory, Semester>(successCategory, semester);

                //Key exists
                if (successObjectives.ContainsKey(key))
                {
                    objectives = successObjectives[key].ToArray();
                    return true;
                }
            }

            objectives = null;
            return false;
        }

        #endregion Success Objectives
    }
}
