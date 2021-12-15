namespace HourBank.Models
{
    public enum BusinessActivityStatus
    {
        Canceled,
        Stopped,
        Running,
        OnHold,
        Completed
    }
    public class BusinessActivity
    {
        public string Title { get; set; }
        public BusinessActivityStatus Status { get;}
        public DateTime StartDateTime {get;}
        public DateTime EndDateTime {get;}

    }
}