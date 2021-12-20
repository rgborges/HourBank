using HourBank.Models.Tasks;

namespace HourBank.Models.Tasks
{
    public class HourCounterService : IHourCounterService
    {
        private List<IBussinessTask>? TaskList;

        public void AppendNewCycle(IBussinessTask bussinessTask)
        {
            throw new NotImplementedException();
        }

        public double GetTotalHours(IBussinessTask businessTask)
        {
            throw new NotImplementedException();
        }
    }
}