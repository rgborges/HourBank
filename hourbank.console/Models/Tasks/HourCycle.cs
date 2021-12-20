namespace HourBank.Models.Tasks
{
    /// <summary>
    /// Hour cycle class represents a portion of time between Tasks transactions.
    /// </summary>
    public class HourCycle
    {
        public BusinessActivityStatus LastStatus { get; set; }
        public BusinessActivityStatus CurrentStatus {get; set;}
        public DateTime LastStatusTimeStamp { get; set;}
        public DateTime CurrentStatusTimeStamp { get; set;}
        public TimeSpan AmmountOfTime { get; protected set;}
        public Guid TaskGuid { get; protected set;}

        public HourCycle(BusinessActivityStatus last_status,
                         BusinessActivityStatus current_status,
                         DateTime last_status_timestamp,
                         DateTime current_status_timestamp,
                         Guid reference_task_guid)
        {
            LastStatus = last_status;
            CurrentStatus = current_status;
            LastStatusTimeStamp = last_status_timestamp;
            CurrentStatusTimeStamp = current_status_timestamp;
            TaskGuid = reference_task_guid;
            AmmountOfTime = LastStatusTimeStamp.Subtract(CurrentStatusTimeStamp);
        }

    }
}