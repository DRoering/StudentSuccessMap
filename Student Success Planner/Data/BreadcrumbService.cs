
namespace Student_Success_Planner.Data
{
    public class BreadcrumbService
    {
        bool flag = true;
        /// <summary>
        /// The College currently being viewed.
        /// </summary>
        public College selectedCollege { get; private set; }

        /// <summary>
        /// The Department currently being viewed.
        /// </summary>
        public Department selectedDepartment { get; private set; }

        /// <summary>
        /// The Program currently being viewed.
        /// </summary>
        public Program selectedProgram { get; private set; }
        public delegate void _BreadcrumbEvent();
        public _BreadcrumbEvent OnAuthorizationSet;

        public void AuthorizeSetter(bool something)
        {
            OnAuthorizationSet?.Invoke();
            flag = something;
        }

        public bool getFlag()
        {
            return flag;
        }

        #region Event Handling

        /// <summary>
        /// Handles the event of a College being selected for viewing.
        /// </summary>
        public void handleCollegeSelection(College college)
        {
            selectedCollege = college;

            //Deselect any existing selections below the college navigation level
            selectedDepartment = null;
            selectedProgram = null;
        }

        /// <summary>
        /// Handles the event of a College being deselected for viewing.
        /// </summary>
        public void handleCollegeDeselection()
        {
            selectedCollege = null;
            selectedDepartment = null;
            selectedProgram = null;
        }

        /// <summary>
        /// Handles the event of a Department being selected for viewing.
        /// </summary>
        public void handleDepartmentSelection(Department department)
        {            
            selectedDepartment = department;

            //Deselect any existing selections below the department navigation level
            selectedProgram = null;
        }

        /// <summary>
        /// Handles the event of a Department being deselected for viewing.
        /// </summary>
        public void handleDepartmentDeselection()
        {
            selectedDepartment = null;
            selectedProgram = null;
        }

        /// <summary>
        /// Handles the event of a Program being selected for viewing.
        /// </summary>
        public void handleProgramSelection(Program program)
        {
            selectedProgram = program;
        }

        /// <summary>
        /// Handles the event of a Program being deselected for viewing.
        /// </summary>
        public void handleProgramDeselection()
        {
            selectedProgram = null;
        }

        #endregion Event Handling
    }
}
