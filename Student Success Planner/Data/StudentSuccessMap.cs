using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Success_Planner.Data
{
    public class StudentSuccessMap : SuccessMap
    {
        /// <summary>
        /// Star ID of the student this success map is for.
        /// </summary>
        public string StarID { get; }

        /// <summary>
        /// ID of the program this success map is for.
        /// </summary>
        public int ProgramID { get; }

        /// <summary>
        /// Student's progress in completing all the required Success Objectives in the Success Map as a percentage between 0 and 100.
        /// </summary>
        public float Progress
        {
            get
            {
                return getProgress(AllSuccessObjectives);
            }
        }

        /// <summary>
        /// IDs of the success objectives completed within this success map by the specified student.
        /// </summary>
        private List<string> completedObjectives;


        public StudentSuccessMap(int successMapID, string successMapName, string starID, int programID) :
            base (successMapID, successMapName)
        {
            StarID = starID;
            ProgramID = programID;
            completedObjectives = new List<string>();
        }

        /// <summary>
        /// Adds an objective to the collection of completed objectives.
        /// </summary>
        /// <param name="objectiveID">ID of the completed objective.</param>
        public void addCompletedObjective(string objectiveID)
        {
            //Add the objective ID if not already present
            if (!completedObjectives.Contains(objectiveID))
                completedObjectives.Add(objectiveID);
        }

        /// <summary>
        /// Determines if the given success objective has been compelted.
        /// </summary>
        public bool isCompleted(SuccessObjective objective)
        {
            return completedObjectives.Contains(objective.ID);
        }

        /// <summary>
        /// Tries to get the student's progress in the given success category as a percentage between 0 and 100.
        /// </summary>
        /// <param name="category">Success category to get the progress for.</param>
        /// <param name="progress">Progress in the success category as a percentage between 0 and 100.</param>
        /// <returns>True if the category was found in this success map, false otherwise.</returns>
        public bool tryGetSuccessCategoryProgress(SuccessCategory category, out float progress)
        {
            if (category != null)
            {
                if (tryGetSuccessObjectivesByCategory(category, out SuccessObjective[] objectives))
                {
                    progress = getProgress(objectives);
                    return true;
                }
            }

            progress = default;
            return false;
        }

        /// <summary>
        /// Gets progress of the completion of the given objectives.
        /// </summary>
        /// <returns>Progress as a percentage.</returns>
        private float getProgress(SuccessObjective[] objectives)
        {
            /* Get success objectives that are required,
                       success activities not required, should not count in progress calculation */
            SuccessObjective[] requiredObjectives = getRequiredObjectives(objectives);

            int totalRequired = requiredObjectives.Length;
            int totalCompleted = 0;

            //Calculate number of objectives completed
            foreach (SuccessObjective objective in requiredObjectives)
            {
                if (isCompleted(objective))
                    totalCompleted++;
            }

            float progressDecimal = (float)totalCompleted / totalRequired;

            //Return progress as a percentage
            return progressDecimal * 100;
        }

        /// <summary>
        /// Gets the success objectives that are required to be completed.
        /// </summary>
        private SuccessObjective[] getRequiredObjectives(SuccessObjective[] objectives)
        {
            List<SuccessObjective> requiredObjectives = new List<SuccessObjective>();
            foreach (SuccessObjective objective in objectives)
            {
                //Only consider Courses to be required, not success activities
                if (objective is Course)
                    requiredObjectives.Add(objective);
            }
            return requiredObjectives.ToArray();
        }
    }
}
