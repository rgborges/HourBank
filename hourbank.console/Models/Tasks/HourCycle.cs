namespace HourBank.Models.Tasks
{
    /// <summary>
    /// Hour cycle class represents a portion of time between Tasks transactions.
    /// </summary>
    public class HourCycle
    {
        public BusinessTaskStatus LastStatus { get; protected set; }
        public BusinessTaskStatus CurrentStatus {get; protected set;}
        public DateTime LastStatusTimeStamp { get; protected set;}
        public DateTime CurrentStatusTimeStamp { get; protected set;}
        public TimeSpan AmmountOfTime { get; protected set;}
        public Guid TaskGuid { get; protected set;}
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
            LastStatus = last_status;
            CurrentStatus = current_status;
            LastStatusTimeStamp = last_status_timestamp;
            CurrentStatusTimeStamp = current_status_timestamp;
            TaskGuid = reference_task_guid;
            Task = task;
            AmmountOfTime = LastStatusTimeStamp.Subtract(CurrentStatusTimeStamp);
        }
        /// <summary>
        /// Update status updates the values for LastStatus and the new Status
        /// </summary>
        public void UpdateStatus(BusinessTaskStatus newStatus)
        {
            /// <summary>
            /// O estado anterior da tarefa se torna armazena o estado corrente.
            /// </summary>
            LastStatus = this.CurrentStatus;
            /// <summary>
            /// O estado corrente da tarefa é atualizado então para o estado de recebimento
            /// </summary>
            this.CurrentStatus = newStatus;
            /// <summary>
            /// O último timestamp da mudança da tarefa assume o valor da propriedade que armazena o time corrente.
            /// </summary>
            this.LastStatusTimeStamp = CurrentStatusTimeStamp;
            /// <summary>
            /// O time corrente da tarefa é atualizada para a estampa atual
            /// </summary>
            this.CurrentStatusTimeStamp = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Task: {Task.Title}, Guid: {Task.InstanceId}, LastStatus:{Task.LastStatusChanged}, Total Ammount: {AmmountOfTime}";
        }
    }
}