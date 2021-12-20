namespace HourBank.Models.Tasks
{
    class ProjectTask : ProjectActivity
    {
        public Guid InstanceId { get; set;}
        // The tile of your project as a string.
        public string? Project { get; set; }

        // Reference to a Hour Conter Service 
        private IHourCounterService? _conterservice;
        /// <summary>
        /// This is the empity constructor. When use it you must set the Project and other properties in {}.
        /// If you use this constructor you need to implement Guid.NewGuid in InstanceId
        /// </summary>
        public ProjectTask() => InstanceId = Guid.NewGuid();
        /// <summary>
        /// Standard constructor.
        /// </summary>
        /// <param name="title">The title of the task</param>
        /// <param name="project">The project name its related to</param>
        public ProjectTask(string title,
                           string project, IHourCounterService service)
        {
            Title = title;
            Project = project;
            Status = BusinessActivityStatus.Created;
            StartDateTime = DateTime.Now;
            InstanceId = Guid.NewGuid();
            this._conterservice = service;
        }
        public override void Initialize()
        {
            this.TotalTaskTime = TimeSpan.Zero;
            this.Status = BusinessActivityStatus.Created;
        }
        
        public override void Terminate()
        {
            this.TotalTaskTime += this.EndDateTime.Subtract(this.StartDateTime);
            this.Status = BusinessActivityStatus.Stopped;
        }

        public override void Continue()
        {
            this.Status = BusinessActivityStatus.Running;
        }
        /// <summary>
        /// This is the Pause state from the interface
        /// </summary>
        public override void Hold()
        {
            
        }

        public override void Cancel()
        {
            this.Status = BusinessActivityStatus.Canceled;
        }
/// <summary>
/// Portuguish: Subistitui a forma como o Objeto é mostrado no console via método ToString()
/// </summary>
/// <returns>Retorna uma string representante do objeto.</returns>
        public override string ToString()
        {
            return $"Guid: {this.InstanceId}, Title: {this.Title}, Status: {this.Status}, Total Time: {this.TotalTaskTime}";
        }
    }
}
