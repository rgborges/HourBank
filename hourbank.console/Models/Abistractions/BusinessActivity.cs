namespace HourBank.Models.Tasks
{
    /// <summary>
    /// Uma atividade de negócio é uma classe abstrata para uma tarefa de projeto ou suporte.
    /// </summary>
    public abstract class BusinessActivity
    {
        public string Title { get; set; }
        public BusinessActivityStatus Status { get; set;}
        public DateTime StartDateTime { get; set;}
        public DateTime EndDateTime { get; set; }
        public TimeSpan TotalTaskTime {set; get;}

    }

    public abstract class ProjectActivity : BusinessActivity, IBussinessTask
    {
        public abstract void Initialize();
        public abstract void Continue();
        public abstract void Hold();
        public abstract void Cancel();
        public abstract void Terminate();
    }
}