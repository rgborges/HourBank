using System.Globalization;
namespace HourBank.Models.Tasks
{
    class ProjectTask : ProjectActivity
    {
        // The tile of your project as a string.
        public string Project { get; set; }

        public ProjectTask() {}
  
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
            throw new NotImplementedException();
        }
        
        public override void Terminate()
        {
            throw new NotImplementedException();
        }

        public override void Continue()
        {
            throw new NotImplementedException();
        }

        public override void Hold()
        {
            throw new NotImplementedException();
        }

        public override void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
