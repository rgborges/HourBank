using System.ComponentModel.DataAnnotations.Schema;
using HourBank.Models.Tasks;

public abstract class BusinessHourCycle {
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
          /// <summary>
        /// Represents the Task which this HourCycle is related to.
        /// </summary>
        /// <value></value>
        [NotMapped]
        public BusinessTask Task { get; set; }

}