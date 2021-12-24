namespace HourBank.Services
{
    public abstract class TaskBook<T, U>
    {
        /// <summary>
        /// Lista de tarefas do tipo T
        /// </summary>
        public readonly List<T> _taskList;
        // Lista de tarefas do tipo U
        public readonly List<U> _hourCycle;

        public TaskBook()
        {
            _taskList = new List<T>();
            _hourCycle = new List<U>();
        }
    
    }
}