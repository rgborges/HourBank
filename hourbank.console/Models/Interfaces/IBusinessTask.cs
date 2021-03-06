namespace HourBank.Models.Tasks
{

    public interface IBussinessTask
    {

        /// <summary>
        /// Determines what this task has to accomplish when in Initialize state. This state defines when the task is 
        /// created.
        /// </summary>
        public void Initialize();
        /// <summary>
        /// Determines wha this task has to accomplish when in Continue state. It's used to leave the Hold or Cancel
        /// state.
        /// </summary>
        public void Continue();
        /// <summary>
        /// Define the Hold action on this task.
        /// </summary>
        public void Hold();
        /// <summary>
        /// Defines the Cancel action on this task.
        /// </summary>
        public void Cancel();
        /// <summary>
        /// Ends a Task.
        /// </summary>
        public void Terminate();
    }

}