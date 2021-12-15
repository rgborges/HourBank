namespace HourBank.Models
{
    public interface IBussinessTask
    {

        /// <summary>
        /// Determine what this task has to accomplish when in Initialize state. This state defines when the task is 
        /// created.
        /// </summary>
        public void Initialize();
        /// <summary>
        /// Determine wha this task has to accomplish when in Continue state. It's used to leave the Hold or Cancel
        /// state.
        /// </summary>
        public void Continue();
        public void Hold();
        public void Cancel();
        public void Terminate();
    }

}