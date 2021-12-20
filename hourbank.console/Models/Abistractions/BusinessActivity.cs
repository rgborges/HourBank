using System.Collections;
using System.Collections.Generic;

namespace HourBank.Models.Tasks
{
    /// <summary>
    /// Uma atividade de negócio é uma classe abstrata para uma tarefa de projeto ou suporte.
    /// </summary>
    public abstract class BusinessTask
    {
        public Guid InstanceId { get; set;}
        public string? Title { get; set; }
        public BusinessActivityStatus Status { get; set;}
        public DateTime StartDateTime { get; set;}
        public DateTime EndDateTime { get; set; }
        public DateTime LastStatusChanged { get; set;}
        public BusinessActivityStatus LastStatus { get; set; }

    }

}