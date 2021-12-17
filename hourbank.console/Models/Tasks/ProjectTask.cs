namespace HourBank.Models.Tasks
{
    class ProjectTask : ProjectActivity
    {
        // The tile of your project as a string.
        public string? Project { get; set; }
/// <summary>
/// This is the empity constructor. When use it you must set the Project and other properties in {}
/// </summary>
        public ProjectTask() {}
/// <summary>
/// Standard constructor.
/// </summary>
/// <param name="title">The title of the task</param>
/// <param name="project">The project name its related to</param>
        public ProjectTask(string title, string project)
        {
            Title = title;
            Project = project;
            Status = BusinessActivityStatus.Created;
            StartDateTime = DateTime.Now;
           
        }
   
        public override string ToString()
        {
            return $"{this.Title}, {this.Status}, {this.Id}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Initialize()
        {
            this.Status = BusinessActivityStatus.Created;
        }
        
        public override void Terminate()
        {
            this.Status = BusinessActivityStatus.Stopped];
        }

        public override void Continue()
        {
            this.Status = BusinessActivityStatus.Running;
        }

        public override void Hold()
        {
            this.Status = BusinessActivityStatus.OnHold;
        }

        public override void Cancel()
        {
            this.Status = BusinessActivityStatus.Canceled;
        }
    }
}
