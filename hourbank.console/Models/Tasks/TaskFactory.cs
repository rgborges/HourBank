namespace HourBank.Models.Tasks
{
    public class TaskFactory : BusinessTask, ITaskFactory
    {
        public ProjectTask CreateProjectTask()
        {
            return new ProjectTask();
        }

        public SupportTask CreateSupportTask()
        {
            return new SupportTask();
        }
    }

}