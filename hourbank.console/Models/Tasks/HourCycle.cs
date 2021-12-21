namespace HourBank.Models.Tasks
{
    /// <summary>
    /// Hour cycle class represents a portion of time between Tasks state transactions.
    /// We have two states, between transactions and end transactions. Between states means
    /// that some properties are null waiting the finish of a transction.
    /// </summary>
    public class HourCycle
    {
        private static TimeSpan _timeBetweenIntervals;
        /// <summary>
        /// Represents the Last Task Status. In the initiatial state of a task, 
        /// this property is Created.
        /// </summary>
        /// <value></value>
        public BusinessTaskStatus LastTaskStatus { get; protected set; }
        /// <summary>
        /// Represents the currrent state of the task. When ever a task change its state,
        /// this property is changed to the new transition state.
        /// </summary>
        /// <value></value>
        public BusinessTaskStatus CurrentStatus {get; protected set;}
        /// <summary>
        /// Represents the last status timestamp. Whenever the task changes its state,
        /// the old state and old timestamp is saved. This properties store the the old state.
        /// </summary>
        /// <value></value>
        public DateTime LastStatusTimeStamp { get; protected set;}
        /// <summary>
        /// Represents the timestamp assigned in the last state transition. This property 
        /// stores always the start of transitions.
        /// </summary>
        /// <value></value>
        public DateTime CurrentStatusTimeStamp { get; protected set;}
        /// <summary>
        /// Represents the portion of time of a completed cycle. This property is saved in
        /// a close of task state.
        /// </summary>
        /// <value></value>
        public TimeSpan TimeBetweenStates 
        { 
            get => GetTimeBetweenTasks();
            set => _timeBetweenIntervals = value;
        }
        /// <summary>
        /// Represents a global ID for each instance of an object.
        /// </summary>
        /// <value></value>
        public Guid TaskGuid { get; protected set;}
        /// <summary>
        /// Representts the Task which this HourCycle is related to.
        /// </summary>
        /// <value></value>
        public BusinessTask Task { get; set; }
    /// <summary>
    /// Contrutor padrão para todas as propriedades.
    /// </summary>
    /// <param name="last_status"></param>
    /// <param name="current_status"></param>
    /// <param name="last_status_timestamp"></param>
    /// <param name="current_status_timestamp"></param>
    /// <param name="reference_task_guid"></param>
    /// <param name="task"></param>
        public HourCycle(BusinessTaskStatus last_status,
                         BusinessTaskStatus current_status,
                         DateTime last_status_timestamp,
                         DateTime current_status_timestamp,
                         Guid reference_task_guid,
                         BusinessTask task)
        {
            LastTaskStatus = last_status;
            CurrentStatus = current_status;
            LastStatusTimeStamp = last_status_timestamp;
            CurrentStatusTimeStamp = current_status_timestamp;
            TaskGuid = reference_task_guid;
            Task = task;
            TimeBetweenStates = last_status_timestamp.Subtract(current_status_timestamp);
        }
        /// <summary>
        /// Update status updates the values for LastStatus and the new Status
        /// </summary>
        public void UpdateTotalTimeBetweenStates()
        {
            TimeBetweenStates = LastStatusTimeStamp.Subtract(CurrentStatusTimeStamp);
        }
        private TimeSpan GetTimeBetweenTasks()
        {
           if(CurrentStatus == BusinessTaskStatus.Initiated)
           {
               return TimeSpan.Zero;
           }
           return _timeBetweenIntervals;
        }
        public override string ToString()
        {
            return $"Task: {Task.Title}, Intial Status: {this.CurrentStatus}, EndStatus: {this.LastTaskStatus}, Total Ammount: {TimeBetweenStates.Minutes}";
        }
    }
}