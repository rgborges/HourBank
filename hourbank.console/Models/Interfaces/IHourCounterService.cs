namespace HourBank.Models.Tasks
{
    public interface IHourCounterService
    {
        //Defines the contract which business tasks have to accomplish.
        double GetTotalHours(IBussinessTask businessTask);
        /// <summary>
        /// Apends the total ammount of time corresponding to one cycle of this task. So, when the task goes from Running to Terminate.
        /// </summary>
        /// <param name="bussinessTask">Some classe which has implemented BusinessTask interface</param>
        void AppendNewCycle(IBussinessTask bussinessTask);
    }
}